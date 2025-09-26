## Поваренная книга (Cookbook)

Готовые рецепты с короткими примерами:

- Включить режим строительства (как в редакторе): см. `services/map_build.md`
- Сделать матч TDM с подсчётом убийств/смертей: см. `services/damage.md`, `services/leaderboard.md`
- Захват точек по зонам: см. `services/areas_triggers_views.md`
- Неуязвимость после спавна: см. `services/timers.md`

Примеры из папки `Examples`:

```1:7:Examples/BlockAllAreasFill.js
block=1

var iter=AreaService.GetEnumerator();
while(iter.MoveNext()){
  MapEditor.SetBlock(iter.Current,block);
}
```

```1:6:Examples/BlockEdit.js
block=1

MapEditor.SetBlock(50,50,75,block);
MapEditor.SetBlock(51,50,75,block);
MapEditor.SetBlockRange(25,25,25,100,100,100,block);
```

