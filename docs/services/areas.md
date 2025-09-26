## AreaService — зоны на карте

Доступ к зонам по имени и тегам.

Основное:
- `AreaService.All`, `AreaService.Get(name)`, `AreaService.GetByTag(tag)`
- `area.Name`, `area.Tags`, `area.Ranges`, `area.Contains(index)`, `area.IsEmpty`
- События: `AreaService.OnArea`, `area.OnEmpty`, `area.OnData`

Пример — выбор зон по тегу и сортировка:
```javascript
var captureAreas = AreaService.GetByTag("capture");
captureAreas.sort(function(a, b) { return a.Name > b.Name ? 1 : (a.Name < b.Name ? -1 : 0); });
```

Смотрите использование зон в режиме [Capture](https://github.com/kkohno/PixelCombats.GameModes.Capture).

