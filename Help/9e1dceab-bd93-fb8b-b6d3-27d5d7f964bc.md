# IMapService - интерфейс


сервис работы с картой



## Definition
**Пространство имён:** <a href="47d42150-1863-9bd0-b023-1ed80dc2abca">PixelCombats.Api.RoomServer.Services.Map</a>  
**Сборка:** PixelCombats.PublicAPI (в PixelCombats.PublicAPI.dll) Версия: 1.0.0.0 (1.0.0.0)

**JavaScript**
``` JavaScript
PixelCombats.Api.RoomServer.Services.Map.IMapService = function();
PixelCombats.Api.RoomServer.Services.Map.IMapService.createInterface('PixelCombats.Api.RoomServer.Services.Map.IMapService');
```



## Свойства
<table>
<tr>
<td><a href="9f2d6238-de62-fbe1-4fcb-9075140b5e14">MapMeta</a></td>
<td>возвращает метаданные текущей карты. при смене меты происходит перезагрузка комнаты</td></tr>
<tr>
<td><a href="1fabf1c0-ecac-f618-4788-e9108d78f07b">OnLoad</a></td>
<td>происходит, если загрузилась карта</td></tr>
<tr>
<td><a href="06dea7cd-9f29-9d03-ee4c-7f5c2715bd5d">Rotation</a></td>
<td>нужно ли менять карту, когда начинается новая игра <p>карта может быть изменена только на случайную, из списка стандартных карт</p><p>

по умолчанию [!:false]</p></td></tr>
</table>

## Методы
<table>
<tr>
<td><a href="86b1bd26-a0a7-a99a-8c8c-0104e6888003">LoadRandomMap</a></td>
<td>если это возможно, то включит случайную карту из текущего списка карт</td></tr>
</table>

## См. также


#### Ссылки
<a href="47d42150-1863-9bd0-b023-1ed80dc2abca">PixelCombats.Api.RoomServer.Services.Map - пространство имён</a>  
