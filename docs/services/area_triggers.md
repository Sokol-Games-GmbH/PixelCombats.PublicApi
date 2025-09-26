## AreaPlayerTriggerService — триггеры игроков по зонам

Создание и обработка триггеров по зонам и тегам.

Основное:
- `AreaPlayerTriggerService.Get(id)` — получить/создать триггер
- `trigger.Area` или `trigger.Tags = ["tag1", ...]`
- `trigger.Enable = true/false`
- `trigger.GetPlayers()`, `trigger.Contains(player)`, `trigger.Count`
- События: `trigger.OnEnter`, `trigger.OnExit`, `trigger.OnData`, `trigger.OnArea`

Пример (подсчёт игроков в триггере): см. [режим Capture](https://github.com/kkohno/PixelCombats.GameModes.Capture).

