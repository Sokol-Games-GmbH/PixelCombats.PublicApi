## UI — интерфейс игрока и комнаты

Показывает подсказки, таймеры, счётчики и т.д.

Частое:
- `Ui.GetContext().Hint.Value = "Hint/AttackEnemies"` — общая подсказка
- `Ui.GetContext().MainTimerId.Value = timer.Id` — привязка таймера к UI
- `Ui.GetContext().QuadsCount.Value = true` — показывать количество квадов
- Для команд: `team.Ui.Hint.Value = ...`
- Для игрока: `player.Ui.Hint.Value = ...`

Сервисные настройки:
- `Ui.ScoresTopViewEnable = true` — включить отображение изменения набранных очков над прицелом.
  - По умолчанию: `false`.
  - Важно: задаётся только при инициализации (до старта матча/ранней инициализации режима).

Пример:
```javascript
var main = Timers.GetContext().Get("Main");
Ui.GetContext().MainTimerId.Value = main.Id;
main.Restart(120);
Ui.GetContext().Hint.Value = "Hint/BuildBase";
```

Пример включения отображения очков над прицелом при инициализации режима:
```javascript
// вызывайте на стадии инициализации режима/комнаты
Ui.ScoresTopViewEnable = true;
```

