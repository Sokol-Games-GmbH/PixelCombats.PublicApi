## Popups — всплывающие окна

Показывает всплывающее окно игроку/сущности.

Основное:
- `player.PopUp("text")` или любой объект, реализующий `IPopups`.

Пример:
```javascript
Players.OnPlayerConnected.Add(function(p){
  p.PopUp("Добро пожаловать в режим!");
});
```

