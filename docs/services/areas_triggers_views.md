## Areas, Triggers, Views — зоны, триггеры и визуализация

Позволяют работать с отмеченными на карте зонами (по тегам), реагировать на вход/выход игроков и подсвечивать зоны.

Основные сервисы:
- `AreaService` — доступ к зонам: `GetByTag(tag)`, `GetEnumerator()`
- `AreaPlayerTriggerService` — триггеры по зонам; `Get(id)` возвращает триггер
  - `trigger.Tags = [tag1, tag2]` или `trigger.Area = area`
  - `trigger.OnEnter.Add(handler)`, `trigger.OnExit.Add(handler)`
  - `trigger.GetPlayers()` — текущие игроки в триггере
- `AreaViewService` — визуализаторы зон; `GetContext().Get(id)`
  - `view.Color = {r:1,g:1,b:1}`, `view.Enable = true`, `view.Tags = [tag]` или `view.Area = area`

Пример (захват зон):
```javascript
var captureAreas = AreaService.GetByTag("capture");
var captureTriggers = [];
var captureViews = [];
var captureProps = [];

// инициализация
for (var i = 0; i < captureAreas.length; ++i) {
  var area = captureAreas[i];
  var view = AreaViewService.GetContext().Get(area.Name + "View");
  var trigger = AreaPlayerTriggerService.Get(area.Name + "Trigger");
  var prop = Properties.GetContext().Get(area.Name + "Pts");
  view.Enable = i === 0; trigger.Area = area; prop.Value = 0;
  captureViews.push(view); captureTriggers.push(trigger); captureProps.push(prop);
}

// подсчёт игроков в зоне и изменение очков
Timers.GetContext().Get("Tick").RestartLoop(1);
Timers.GetContext().Get("Tick").OnTimer.Add(function(){
  for (var i = 0; i < captureTriggers.length; ++i) {
    var players = captureTriggers[i].GetPlayers();
    var change = 0; // вычислите по своей логике
    var v = captureProps[i].Value + change;
    captureProps[i].Value = Math.max(0, Math.min(15, v));
  }
});
```

