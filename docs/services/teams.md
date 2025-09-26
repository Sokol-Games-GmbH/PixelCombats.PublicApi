## Teams — команды

Создание и управление командами игроков.

Основные методы и объекты:
- `Teams.Add(id, display, color)` — создать команду. Пример: `Teams.Add("Blue", "Teams/Blue", { b: 1 })`.
- `Teams.Get(id)` — получить команду.
- `Teams.GetEnumerator()` — перечисление команд.
- События: `Teams.OnRequestJoinTeam`, `Teams.OnPlayerChangeTeam`.

Примеры:
```javascript
// создание 2 команд и настройка спавнов
Teams.Add("Blue", "Teams/Blue", { b: 1 });
Teams.Add("Red", "Teams/Red", { r: 1 });
Teams.Get("Blue").Spawns.SpawnPointsGroups.Add(1);
Teams.Get("Red").Spawns.SpawnPointsGroups.Add(2);

// авто-вступление по запросу и авто-спавн
Teams.OnRequestJoinTeam.Add(function(player, team) { team.Add(player); });
Teams.OnPlayerChangeTeam.Add(function(player) { player.Spawns.Spawn(); });
```

Свойства команды (примеры):
- `team.Properties.Get(name)` — контекстные свойства команды
- `team.Spawns`, `team.Ui`, `team.Inventory`, `team.Build` — контексты сервисов для команды

