## MapEditor — редактирование карты

Изменение блоков точечно, по диапазону, по зоне.

Основное:
- `MapEditor.SetBlock(x, y, z, blockId)`
- `MapEditor.SetBlock(index, blockId)`
- `MapEditor.SetBlock(range, blockId)`
- `MapEditor.SetBlock(area, blockId)`
- `MapEditor.SetBlockRange(x1,y1,z1,x2,y2,z2, blockId)`
- `MapEditor.GetBlockId(x,y,z)` / `GetBlockId(index)`
- `MapEditor.GetBlockAreas(range)`
- `MapEditor.OnMapEdited` — событие изменения карты

Пример:
```javascript
block = 1;
var iter = AreaService.GetEnumerator();
while (iter.MoveNext()) {
  MapEditor.SetBlock(iter.Current, block);
}
```

Смотрите примеры: `Examples/BlockAllAreasFill.js`, `Examples/BlockEdit.js`, и режим [Editor](https://github.com/kkohno/PixelCombats.GameModes.Editor).

