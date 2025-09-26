## Analytics — аналитика режима

Отправка аналитических событий.

API:
- `Analytics.LogEvent(eventName, ...parameters)`

Пример:
```javascript
Analytics.LogEvent("MatchStarted");
Analytics.LogEvent("ZoneCaptured", { Name: "A" }, { Team: "Red" });
```

Смотрите также сценарии матчей в режимах: [TDM](https://github.com/kkohno/PixelCombats.GameModes.TDM), [Capture](https://github.com/kkohno/PixelCombats.GameModes.Capture).

