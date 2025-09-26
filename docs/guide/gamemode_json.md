## Формат gamemode.json

Файл задаёт базовую информацию и параметры режима.

Ключи:
- `ApiVersion` (число, опционально) — версия API, если требуется.
- `Name` (строка, обязательно) — системное имя режима.
- `Description` (строка) — описание для UI.
- `StartClientVersion` (число) — минимальная версия клиента.
- `MapFilter` (объект, опционально) — фильтры для карт (например `HasParcourEnd`).
- `MapLists` (массив объектов) — списки карт для выбора.
  - `MapListId` (число) — идентификатор списка карт.
  - `Name` (строка, опционально) — отображаемое имя списка.
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

Полные примеры смотрите в официальных режимах и в файлах:
- `PixelCombats.GameModes.TDM/gamemode.json`
- `PixelCombats.GameModes.Peace/gamemode.json`
- `PixelCombats.GameModes.Editor/gamemode.json`
- `PixelCombats.GameModes.Parcour/gamemode.json`
- `PixelCombats.GameModes.Capture/gamemode.json`

