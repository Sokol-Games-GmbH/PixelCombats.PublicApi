## Map — карта и ротация

Метаданные и ротация карт.

Основное:
- `Map.MapMeta`, `Map.MapId`, `Map.MapListId`
- `Map.Rotation = true/false`
- `Map.LoadRandomMap()`
- `Map.OnLoad` — событие загрузки карты

Пример:
```javascript
Map.Rotation = GameMode.Parameters.GetBool("MapRotation");
Map.OnLoad.Add(function(){ log.debug("map loaded"); });
```

Смотрите применение ротации в режимах: [TDM](https://github.com/kkohno/PixelCombats.GameModes.TDM), [Parcour](https://github.com/kkohno/PixelCombats.GameModes.Parcour).

