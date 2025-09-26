## Структура репозитория режима

Рекомендуемая структура файлов Вашего режима:

```
gamemode.json                // описание режима (название, описание, параметры, карты)
client/
  room/
    gamemode.js              // главный сценарий комнаты (обязателен)
    default_teams.js         // (опционально) конфигурация команд
    options.js               // (опционально) обработка параметров режима
    ...                      // любые дополнительные скрипты
```

Пояснения:
- `gamemode.json` — конфигурация режима, отображается в игре и влияет на UI/фильтры карт.
- `client/room/` — здесь лежат JS-скрипты, исполняемые в контексте комнаты.
- Разбивайте логику по модулям, чтобы код был понятнее.

Смотрите примеры в предоставленных репозиториях режимов:
- [TDM](https://github.com/kkohno/PixelCombats.GameModes.TDM)
- [Мир (Peace)](https://github.com/kkohno/PixelCombats.GameModes.Peace)
- [Редактор (Editor)](https://github.com/kkohno/PixelCombats.GameModes.Editor)
- [Паркур (Parcour)](https://github.com/kkohno/PixelCombats.GameModes.Parcour)
- [Захват (Capture)](https://github.com/kkohno/PixelCombats.GameModes.Capture)

