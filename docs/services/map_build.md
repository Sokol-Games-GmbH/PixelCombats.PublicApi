## Map и Build — работа с картой и строительством

Позволяет менять блоки, включать редакторские функции, управлять генерацией и прочим.

Полезное:
- `Map.OnLoad.Add(handler)` — событие загрузки карты
- `Map.Rotation` — включить/отключить ротацию карт
- `Build.GetContext()` — контекст редакторских настроек (пипетка, заливка и т.д.)
- `MapEditor.SetBlock(x, y, z, blockId)` и `MapEditor.SetBlockRange(x1,y1,z1,x2,y2,z2, blockId)` — массовые изменения
- `BreackGraph` — параметры разрушаемости

Примеры:
```javascript
// включаем инструменты редактора
var b = Build.GetContext();
b.BuildModeEnable.Value = true;
b.Pipette.Value = true;
b.FloodFill.Value = true;
b.FillQuad.Value = true;
b.RemoveQuad.Value = true;
b.BalkLenChange.Value = true;
b.FlyEnable.Value = true;

// запрет урона и ломаемости
Damage.GetContext().DamageOut.Value = false;
BreackGraph.BreackAll = true;

// пример заливки области блоком 1
var iter = AreaService.GetEnumerator();
while (iter.MoveNext()) {
  MapEditor.SetBlock(iter.Current, 1);
}
```

