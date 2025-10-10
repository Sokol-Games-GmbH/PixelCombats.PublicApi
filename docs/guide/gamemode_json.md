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

