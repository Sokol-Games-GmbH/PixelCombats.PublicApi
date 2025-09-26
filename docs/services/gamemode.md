## GameMode — параметры режима

Позволяет читать значения, заданные в `gamemode.json`.

Основное:
- `GameMode.Parameters.GetBool(name)` — булево значение
- `GameMode.Parameters.Get(name)` — строка/значение (например из `Dropdown`)

Пример:
```javascript
Map.Rotation = GameMode.Parameters.GetBool("MapRotation");
var length = GameMode.Parameters.Get("default_game_mode_length");
```

Смотрите примеры использования параметров в режимах: 
[TDM](https://github.com/kkohno/PixelCombats.GameModes.TDM) и 
[Peace](https://github.com/kkohno/PixelCombats.GameModes.Peace).

