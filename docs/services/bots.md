## Bots — боты

Создание и управление ботами (если включено на сервере).

Основное:
- `Bots.PoolSize` — размер пула (подготовить заранее)
- `Bots.CreateHuman({ Position, Rotation, WeaponId, SkinId, LookAt })` — создать
- `Bots.Get(id)`, `Bots.All`, `Bots.Alive`, `Bots.Count`
- События: `Bots.OnNewBot`, `Bots.OnBotDeath`, `Bots.OnBotRemove`

Пример:
```javascript
Bots.PoolSize = 4;
var bot = Bots.CreateHuman({ Position: {x:10,y:50,z:10}, Rotation: {x:0,y:0} });
if (bot) { bot.Attack = true; }
```

Смотрите идеи использования в режимах: [TDM](https://github.com/kkohno/PixelCombats.GameModes.TDM).

