## LeaderBoard — таблицы лидеров

Отображение статистики игроков и команд.

Основные поля:
- `LeaderBoard.PlayerLeaderBoardValues = [ { Value, DisplayName, ShortDisplayName }, ... ]`
- `LeaderBoard.TeamLeaderBoardValue = { Value, DisplayName, ShortDisplayName }`
- `LeaderBoard.PlayersWeightGetter.Set(function(player){ ... })`
- `LeaderBoard.TeamWeightGetter.Set(function(team){ ... })`

Пример:
```javascript
LeaderBoard.PlayerLeaderBoardValues = [
  { Value: "Kills", DisplayName: "Statistics/Kills", ShortDisplayName: "Statistics/KillsShort" },
  { Value: "Deaths", DisplayName: "Statistics/Deaths", ShortDisplayName: "Statistics/DeathsShort" },
  { Value: "Scores", DisplayName: "Statistics/Scores", ShortDisplayName: "Statistics/ScoresShort" }
];

LeaderBoard.TeamLeaderBoardValue = { Value: "Scores", DisplayName: "Statistics/Scores", ShortDisplayName: "Statistics/ScoresShort" };

LeaderBoard.PlayersWeightGetter.Set(function(player) {
  return player.Properties.Get("Kills").Value;
});
```

