## Формат gamemode.json

Файл задаёт базовую информацию и параметры режима.

Ключи:
- `ApiVersion` (число, опционально) — версия API, если требуется.
- `Name` (строка, обязательно) — может быть обычным текстом или ключом локализации.
- `Description` (строка) — может быть обычным текстом или ключом локализации.
- `DefaultLang` (строка, опционально) — базовый язык локализации (первые 2 буквы, например `en`, `ru`). Используется при валидации и выборе базового словаря.
- `PopupsEnabled` (bool, опционально) — включает поддержку `PopUp` в режиме (по умолчанию `false`).
- `StartClientVersion` (число) — минимальная версия клиента.
- `MapFilter` (объект, опционально) — фильтры для карт (например `HasParcourEnd`).
- `MapLists` (массив объектов) — списки карт для выбора.
  - `MapListId` (число) — идентификатор списка карт.
  - `Name` (строка, опционально) — отображаемое имя списка: текст или ключ локализации.
- `Parameters` (объект) — параметры режима, отображаемые в UI комнаты.
  - `Bool` (массив) — булевы параметры.
  - `Dropdown` (массив) — выпадающие списки.

Схемы параметров:
```json
{
  "Parameters": {
    "Bool": [
      {
        "Name": "MapRotation",
        "DisplayName": "GmParams/MapRotation",
        "Default": true,
        "Order": 1
      }
    ],
    "Dropdown": [
      {
        "Name": "default_game_mode_length",
        "DisplayName": "GmParams/Length",
        "Default": "Length_XL",
        "Order": 6,
        "Variants": [
          { "Name": "Length_S",  "DisplayName": "GmParams/Length_S" },
          { "Name": "Length_M",  "DisplayName": "GmParams/Length_M" },
          { "Name": "Length_L",  "DisplayName": "GmParams/Length_L" },
          { "Name": "Length_XL", "DisplayName": "GmParams/Length_XL" }
        ]
      }
    ]
  }
}
```

Как читать параметры в JS:
```javascript
// булево
var rotate = GameMode.Parameters.GetBool("MapRotation");
// дропдаун (строка)
var length = GameMode.Parameters.Get("default_game_mode_length");
```

Попапы включаются в коде режима при инициализации через `IRoomAPI.PopupsEnable`.

### Локализация полей gamemode.json

Подробности см. в руководстве по локализации: [Localization](./localization.md).

- Какие поля принимают ключи локализации:
  - **Name** и **Description**.
  - **MapLists[].Name**.
  - **Parameters.Bool[].DisplayName**, **Parameters.Dropdown[].DisplayName**, а также **DisplayName** у вариантов дропдаунов.
- Размещение словарей: `client/localization/{lang}.json` (где `{lang}` — 2‑буквенный код языка в нижнем регистре, например `en`, `ru`).
- Ключи чувствительны к регистру (case‑sensitive).
- Фолбэк-порядок разрешения переводов: запрошенный язык → `en` → любой доступный язык → исходное значение поля.

Пример использования ключей в `gamemode.json`:
```json
{
  "ApiVersion": 2,
  "DefaultLang": "en",
  "PopupsEnabled": true,
  "Name": "mode.name",
  "Description": "mode.description",
  "MapLists": [
    { "MapListId": 1, "Name": "MapList/AllMaps" }
  ],
  "Parameters": {
    "Bool": [
      { "Name": "MapRotation", "DisplayName": "GmParams/MapRotation", "Default": true }
    ],
    "Dropdown": [
      {
        "Name": "default_game_mode_length",
        "DisplayName": "GmParams/Length",
        "Default": "Length_XL",
        "Order": 6,
        "Variants": [
          { "Name": "Length_S",  "DisplayName": "GmParams/Length_S" },
          { "Name": "Length_M",  "DisplayName": "GmParams/Length_M" },
          { "Name": "Length_L",  "DisplayName": "GmParams/Length_L" },
          { "Name": "Length_XL", "DisplayName": "GmParams/Length_XL" }
        ]
      }
    ]
  }
}
```

Полные примеры смотрите в официальных репозиториях режимов:
- [TDM](https://github.com/kkohno/PixelCombats.GameModes.TDM)
- [Мир (Peace)](https://github.com/kkohno/PixelCombats.GameModes.Peace)
- [Редактор (Editor)](https://github.com/kkohno/PixelCombats.GameModes.Editor)
- [Паркур (Parcour)](https://github.com/kkohno/PixelCombats.GameModes.Parcour)
- [Захват (Capture)](https://github.com/kkohno/PixelCombats.GameModes.Capture)

### Стандартный параметр размеров карт: GameLength

Система поддерживает стандартный параметр `GameLength`, который определяет «длину» (размер) партии на карте. Этот параметр:

- распознаётся системой автоматически, если объявлен в `ParametersDeclaration` как строковый `Name = "GameLength"`;
- отображается в списках комнат (S/M/L/XL);
- доступен в API сценариев режима через `GameMode.Parameters.GetString('GameLength')`;

Поддерживаемые значения:
- `Length_S` — короткая сессия
- `Length_M` — средняя сессия
- `Length_L` — длинная сессия
- `Length_XL` — очень длинная сессия

Объявление в `ParametersDeclaration` (пример):
```json
{
  "ParametersDeclaration": [
    {
      "Name": "GameLength",
      "Type": "String",
      "Default": "Length_M"
    }
  ]
}
```

Доступ из сценария режима (JS):
```javascript
// получить текущую длину из параметров режима
const length = GameMode.Parameters.GetString('GameLength');
```

Пример использования в режиме TDM (фрагмент `gamemode.json`):
```json
{
  "MapLists": [
    { "MapListId": 24854, "Name": "S",  "Parameters": { "GameLength": "Length_S"  } },
    { "MapListId": 24855, "Name": "M",  "Parameters": { "GameLength": "Length_M"  } },
    { "MapListId": 24856, "Name": "L",  "Parameters": { "GameLength": "Length_L"  } },
    { "MapListId": 24857, "Name": "XL", "Parameters": { "GameLength": "Length_XL" } }
  ]
}
```

Таким образом, при выборе соответствующего списка карт в лобби значение `GameLength` переопределяется, и сценарии/системы (например, миссии) могут подстраивать логику под длину матча.

В референсных скриптах вы можете увидеть прямое использование значения длины, например, в расчётах очков (JS):
```javascript
// см. damage_scores.js
const length = GameMode.Parameters.GetString('GameLength');
```

