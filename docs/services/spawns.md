## Spawns — спавн и респавн

Управляет точками появления и временем респавна.

Частые операции:
- `Spawns.GetContext()` — общий контекст спавнов комнаты
  - `RespawnTime.Value` — время респавна в секундах
  - `enable` — включение/выключение спавнов
  - `Despawn()` — убрать всех
  - `Spawn()` — заспавнить всех (для контекста), или `Spawns.GetContext(team).Spawn()`
- `Spawns.OnSpawn` — событие спавна игрока
- `player.Spawns.Spawn()` — заспавнить конкретного игрока

Пример (аналогичные настройки есть в [Editor](https://github.com/kkohno/PixelCombats.GameModes.Editor) и [TDM](https://github.com/kkohno/PixelCombats.GameModes.TDM)):
```javascript
// моментальный респавн и стартовое появление
Spawns.GetContext().RespawnTime.Value = 0;
Teams.OnPlayerChangeTeam.Add(function(player) { player.Spawns.Spawn(); });

// добавление кастомных точек спавна из области
var spawns = Spawns.GetContext(Teams.Get("Blue"));
spawns.CustomSpawnPoints.Add(10, 50, 10, 0);
```

