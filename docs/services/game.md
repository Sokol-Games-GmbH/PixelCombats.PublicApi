## Game — управление матчем

Перезапуск матча, завершение и выдача победителей.

Основное:
- `Game.RestartGame()` — перезапустить матч
- `Game.GameOver(winner)` — завершить матч, где winner — команда или массив команд

Пример:
```javascript
var main = Timers.GetContext().Get("Main");
main.OnTimer.Add(function(){
  Game.RestartGame();
});

// при условии победы красной команды
// Game.GameOver(Teams.Get("Red"));
```

