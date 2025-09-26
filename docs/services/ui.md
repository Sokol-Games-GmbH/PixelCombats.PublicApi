## UI — интерфейс игрока и комнаты

Показывает подсказки, таймеры, счётчики и т.д.

Частое:
- `Ui.GetContext().Hint.Value = "Hint/AttackEnemies"` — общая подсказка
- `Ui.GetContext().MainTimerId.Value = timer.Id` — привязка таймера к UI
- `Ui.GetContext().QuadsCount.Value = true` — показывать количество квадов
- Для команд: `team.Ui.Hint.Value = ...`
- Для игрока: `player.Ui.Hint.Value = ...`

Пример:
```javascript
var main = Timers.GetContext().Get("Main");
Ui.GetContext().MainTimerId.Value = main.Id;
main.Restart(120);
Ui.GetContext().Hint.Value = "Hint/BuildBase";
```

