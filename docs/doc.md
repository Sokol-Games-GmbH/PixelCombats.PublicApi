## Документация по разработке игровых режимов PixelCombats (JS)

Данная документация описывает только JavaScript-API для создания режимов. Никаких знаний C# не требуется.

### С чего начать
- Пройдите «Быстрый старт»: [guide/quickstart.md](guide/quickstart.md)
- Узнайте структуру репозитория режима: [guide/repo_structure.md](guide/repo_structure.md)
- Описание файла конфигурации `gamemode.json`: [guide/gamemode_json.md](guide/gamemode_json.md)
- Обзор модулей и контекстов: [guide/modules_overview.md](guide/modules_overview.md)
- Справочник сервисов (JS): см. раздел «Сервисы» ниже
- Примеры: [cookbook/index.md](cookbook/index.md)

### Сервисы (JS API)
- Команды: [services/teams.md](services/teams.md)
- Спавн и респавн: [services/spawns.md](services/spawns.md)
- Таймеры: [services/timers.md](services/timers.md)
- Свойства (глобальные/контекстные): [services/properties.md](services/properties.md)
- Урон и события боя: [services/damage.md](services/damage.md)
- Игроки: [services/players.md](services/players.md)
- Карта и постройки: [services/map_build.md](services/map_build.md)
- Области/Триггеры/Визуализация зон: [services/areas_triggers_views.md](services/areas_triggers_views.md)
- Балансировщик команд: [services/teams_balancer.md](services/teams_balancer.md)
- Лидерборды: [services/leaderboard.md](services/leaderboard.md)
- Инвентарь: [services/inventory.md](services/inventory.md)
- UI: [services/ui.md](services/ui.md)
- Игра/перезапуск: [services/game.md](services/game.md)
- Режим и параметры: [services/gamemode.md](services/gamemode.md)

### Официальные примеры режимов
- [TDM](https://github.com/kkohno/PixelCombats.GameModes.TDM)
- [Мир](https://github.com/kkohno/PixelCombats.GameModes.Peace)
- [Редактор Карт](https://github.com/kkohno/PixelCombats.GameModes.Editor)
- [Паркур](https://github.com/kkohno/PixelCombats.GameModes.Parcour)
- [Захват](https://github.com/kkohno/PixelCombats.GameModes.Capture)

### Управление режимом через GitHub
Пошаговая инструкция по созданию и обновлению своего режима через GitHub доступна в разделе «Быстрый старт»: [guide/quickstart.md](guide/quickstart.md)

Полезное:
- [Задавайте официальные карты для режима](GameModeOfficialMaps.md)
