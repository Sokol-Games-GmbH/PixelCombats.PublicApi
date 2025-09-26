## BreackGraph — разрушаемость блоков

Настройки поведения ломаемости блоков.

Основные поля:
- `BreackGraph.Damage` — можно ли ломать блоки
- `BreackGraph.PlayerBlockDmg` — можно ли ломать блоки игроков
- `BreackGraph.PlayerBlockBoost` — усиление блоков игроков
- `BreackGraph.WeakBlocks` — ослабленные блоки
- `BreackGraph.BreackAll` — можно ломать любые блоки (металл, лава)
- `BreackGraph.OnlyPlayerBlocksDmg` — ломать только блоки игроков
- `BreackGraph.BlockRoot(blockId)` — исходный блок для сломанного

Пример:
```javascript
// редактор: позволяем ломать всё и показываем количество квадов
BreackGraph.BreackAll = true;
BreackGraph.WeakBlocks = true;
Ui.GetContext().QuadsCount.Value = true;
```

Смотрите примеры в режимах: [Editor](https://github.com/kkohno/PixelCombats.GameModes.Editor), [Peace](https://github.com/kkohno/PixelCombats.GameModes.Peace).

