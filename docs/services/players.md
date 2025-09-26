## Players — игроки

Перечень игроков, события входа/выхода.

Частое:
- `Players.OnPlayerDisconnected.Add(function(player){ ... })`
- `Teams.OnPlayerChangeTeam.Add(function(player){ ... })` — смена команды
- Свойства игрока через `player.Properties`
- Таймеры игрока `player.Timers`
- UI игрока `player.Ui`

Пример:
```javascript
Players.OnPlayerDisconnected.Add(function(player){
  log.debug("disconnect: " + player);
});
```

