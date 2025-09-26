## Properties — свойства

Глобальные и контекстные свойства для хранения значений состояния.

Частые операции:
- `Properties.GetContext()` — свойства комнаты
- `Properties.GetContext(team)` — свойства команды
- `player.Properties` — свойства игрока
- `context.Get(name)` — получить/создать свойство по имени
- `prop.Value` — значение свойства; `prop.OnValue.Add(handler)` — событие изменения

Примеры:
```javascript
// свойство состояния игры
var stateProp = Properties.GetContext().Get("State");
stateProp.Value = "Waiting";
stateProp.OnValue.Add(function(p) { log.debug("state=" + p.Value); });

// счётчики на игроке
Damage.OnDeath.Add(function(player) { ++player.Properties.Deaths.Value; });
Damage.OnKill.Add(function(player, killed) {
  if (killed.Team && killed.Team !== player.Team) {
    ++player.Properties.Kills.Value;
    player.Properties.Scores.Value += 100;
  }
});
```

