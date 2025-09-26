## Timers — таймеры

Позволяет создавать и управлять таймерами на уровне комнаты, команды или игрока.

Основные операции:
- `Timers.GetContext()` — контекст таймеров комнаты
- `context.Get(id)` — получить/создать таймер по имени
- `timer.Restart(seconds)` — перезапустить на секунды (однократный)
- `timer.RestartLoop(seconds)` — перезапустить циклический таймер
- `Timers.OnPlayerTimer` — событие таймеров игроков
- `timer.OnTimer.Add(handler)` — событие срабатывания таймера

Примеры (см. также логику таймеров в [TDM](https://github.com/kkohno/PixelCombats.GameModes.TDM) и [Capture](https://github.com/kkohno/PixelCombats.GameModes.Capture)):
```javascript
// главный таймер комнаты
var main = Timers.GetContext().Get("Main");
main.Restart(30);
main.OnTimer.Add(function() {
  Game.RestartGame();
});

// неуязвимость после спавна для игрока 5 секунд
var IMMORTAL = "immortality";
Spawns.GetContext().OnSpawn.Add(function(player) {
  player.Properties.Immortality.Value = true;
  player.Timers.Get(IMMORTAL).Restart(5);
});
Timers.OnPlayerTimer.Add(function(timer) {
  if (timer.Id !== IMMORTAL) return;
  timer.Player.Properties.Immortality.Value = false;
});
```

