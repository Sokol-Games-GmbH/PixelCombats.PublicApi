## AreaViewService — визуализация зон

Подсветка зон и работа по тегам/конкретным областям.

Основное:
- `AreaViewService.GetContext().Get(id)` — получить визуализатор в контексте
- `view.Enable`, `view.Color = {r,g,b}`, `view.Area`, `view.Tags = [tag]`
- `view.GetAreas()` — зоны, которые визуализирует
- События: `view.OnData`, `view.OnArea`

Пример — подсветить зону защиты синих:
```javascript
var defView = AreaViewService.GetContext().Get("DefView");
defView.Color = { b: 1 };
defView.Tags = ["def"];
defView.Enable = true;
```

Смотрите примеры в режимах: [Capture](https://github.com/kkohno/PixelCombats.GameModes.Capture).

