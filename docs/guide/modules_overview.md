## Обзор модулей и контекстов (JS)

Скрипты выполняются в интерпретаторе Jint и имеют доступ к модулям API. Основные сущности:

- Глобальные объекты-сервисы: `Teams`, `Spawns`, `Timers`, `Properties`, `GameMode`, `Damage`, `Inventory`, `Map`, `Build`, `BreackGraph`, `LeaderBoard`, `Ui`, `Game`, `Players`, `Validate`, `AreaService`, `AreaViewService`, `AreaPlayerTriggerService`, и др.
- Контексты: многие сервисы имеют метод `GetContext([scope])`, возвращающий объект контекста для всей комнаты или для конкретной команды/игрока. Примеры:
  - `Timers.GetContext()` — общий набор таймеров комнаты
  - `Timers.GetContext(team)` — таймеры для конкретной команды
  - `player.Timers.Get("MyTimer")` — таймер на игроке
- События: `On...` коллекции, к которым можно добавлять обработчики через `.Add(function(...) { ... })`.

Примеры:
```javascript
// общий таймер комнаты
var main = Timers.GetContext().Get("Main");
main.Restart(30);
main.OnTimer.Add(function() { Game.RestartGame(); });

// свойство комнаты
var stateProp = Properties.GetContext().Get("State");
stateProp.Value = "Game";

// событие смерти
Damage.OnDeath.Add(function(player) {
  ++player.Properties.Deaths.Value;
});
```

Смотрите подробности в разделах «Сервисы» и «Поваренная книга».

