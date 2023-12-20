# IAreaTrigger - интерфейс


триггер для зон



## Definition
**Пространство имён:** <a href="4f427198-2b1e-a053-5a6c-40f068fcb995">PixelCombats.Api.RoomServer.Services.Areas.Triggers</a>  
**Сборка:** PixelCombats.PublicAPI (в PixelCombats.PublicAPI.dll) Версия: 1.0.0.0 (1.0.0.0)

**C#**
``` C#
public interface IAreaTrigger
```
**VB**
``` VB
Public Interface IAreaTrigger
```
**C++**
``` C++
public interface class IAreaTrigger
```
**F#**
``` F#
type IAreaTrigger = interface end
```



## Свойства
<table>
<tr>
<td><a href="010d756d-267f-3111-d3ef-a261bb689c9f">Area</a></td>
<td>зона, с которой работает</td></tr>
<tr>
<td><a href="44dd4949-957a-13df-6f3c-6af4cd86db95">Enable</a></td>
<td>включен ли триггер <p>когда выключен - не работают события и не идет никакой учет (экономится производительность)</p></td></tr>
<tr>
<td><a href="7b7fddcb-fd83-e854-1053-086171943009">Name</a></td>
<td>имя триггера</td></tr>
<tr>
<td><a href="7356f6c9-a84b-7c2b-470e-c6d3ca02a46c">OnArea</a></td>
<td>если изменилась одна из зон</td></tr>
<tr>
<td><a href="8d8e3957-2efa-093e-6778-d898813731e4">OnData</a></td>
<td>изменились настройки триггера</td></tr>
<tr>
<td><a href="15c079ae-f198-4f72-d273-adb7881d3ddb">Tags</a></td>
<td>тэги зон, с которыми работает</td></tr>
</table>

## Методы
<table>
<tr>
<td><a href="b263ec07-12ce-20f7-d4dc-ee4da0c7c0db">GetAreas</a></td>
<td>возвращает массив всех зон, с которыми работает</td></tr>
</table>

## См. также


#### Ссылки
<a href="4f427198-2b1e-a053-5a6c-40f068fcb995">PixelCombats.Api.RoomServer.Services.Areas.Triggers - пространство имён</a>  
