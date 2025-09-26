## Быстрый старт

Ниже краткая инструкция, как создать и запустить свой режим, используя JavaScript.

1) Создайте репозиторий на GitHub (публичный или приватный).
2) В игре создайте новый режим и привяжите к нему свой GitHub-аккаунт и репозиторий.
3) В корень репозитория добавьте файл `gamemode.json` и папку `client/room/` с JS-файлами.
4) Нажмите в игре «Обновить с GitHub», чтобы применить изменения.

Минимальный пример структуры:

```
gamemode.json
client/
  room/
    gamemode.js
```

Пример простого `gamemode.js`:

```javascript
// входим в команду по запросу и сразу спавнимся
Teams.OnRequestJoinTeam.Add(function(player, team) { team.Add(player); });
Teams.OnPlayerChangeTeam.Add(function(player) { player.Spawns.Spawn(); });

// создаем 2 команды и группы спавна
Teams.Add("Blue", "Teams/Blue", { b: 1 });
Teams.Add("Red", "Teams/Red", { r: 1 });
Teams.Get("Blue").Spawns.SpawnPointsGroups.Add(1);
Teams.Get("Red").Spawns.SpawnPointsGroups.Add(2);

// включаем моментальный респавн
Spawns.GetContext().RespawnTime.Value = 0;

// простая подсказка
Ui.GetContext().Hint.Value = "Hint/AttackEnemies";
```

Далее изучайте:
- `gamemode.json` и параметры: [gamemode_json.md](gamemode_json.md)
- Обзор модулей и контекстов: [modules_overview.md](modules_overview.md)
- Сервисы (справочник): см. раздел «Сервисы» в главной документации
- Примеры в официальных режимах: [TDM](https://github.com/kkohno/PixelCombats.GameModes.TDM), [Peace](https://github.com/kkohno/PixelCombats.GameModes.Peace), [Editor](https://github.com/kkohno/PixelCombats.GameModes.Editor), [Parcour](https://github.com/kkohno/PixelCombats.GameModes.Parcour), [Capture](https://github.com/kkohno/PixelCombats.GameModes.Capture)

