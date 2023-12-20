# MakeRequestAsync(IRoomsFilter, Boolean, Boolean, CancellationToken) - метод


начинает поиск комнат в соответствии с фильтром



## Definition
**Пространство имён:** <a href="ae7ef404-1be2-4da8-5f79-9ca48b77858c">PixelCombats.Api.Client.MainMenu.Services.RoomList</a>  
**Сборка:** PixelCombats.PublicAPI (в PixelCombats.PublicAPI.dll) Версия: 1.0.0.0 (1.0.0.0)

**C#**
``` C#
Task<GetRoomsResponce> MakeRequestAsync(
	IRoomsFilter filter,
	bool onlyCompatibleVersions,
	bool includeFullRooms,
	CancellationToken cancellationToken
)
```
**VB**
``` VB
Function MakeRequestAsync ( 
	filter As IRoomsFilter,
	onlyCompatibleVersions As Boolean,
	includeFullRooms As Boolean,
	cancellationToken As CancellationToken
) As Task(Of GetRoomsResponce)
```
**C++**
``` C++
Task<GetRoomsResponce>^ MakeRequestAsync(
	IRoomsFilter^ filter, 
	bool onlyCompatibleVersions, 
	bool includeFullRooms, 
	CancellationToken cancellationToken
)
```
**F#**
``` F#
abstract MakeRequestAsync : 
        filter : IRoomsFilter * 
        onlyCompatibleVersions : bool * 
        includeFullRooms : bool * 
        cancellationToken : CancellationToken -> Task<GetRoomsResponce> 
```



#### Параметры
<dl><dt>  <a href="5d9880d5-e580-114b-ee5a-a785bbf8cca0">IRoomsFilter</a></dt><dd>фильтр комнат. Если null то выводит все комнаты</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a></dt><dd>если истина, то возвращает только совместимые с текущей версией версии комнат</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a></dt><dd>включать ли полные комнаты</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken" target="_blank" rel="noopener noreferrer">CancellationToken</a></dt><dd>токен отмены</dd></dl>

#### Возвращаемое значение
<a href="https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1" target="_blank" rel="noopener noreferrer">Task</a>(<a href="5adcbbbd-44a1-d725-80fb-58112767b2fa">GetRoomsResponce</a>)  
\[&lt;returns&gt; отсутствует в документации для "M:PixelCombats.Api.Client.MainMenu.Services.RoomList.IRoomListService.MakeRequestAsync(PixelCombats.Api.Client.MainMenu.Services.RoomList.IRoomsFilter,System.Boolean,System.Boolean,System.Threading.CancellationToken)"\]

## См. также


#### Ссылки
<a href="2cff7eff-cb27-8e0f-6a91-3c568456424d">IRoomListService - </a>  
<a href="7050db7f-dc67-2b40-7cfe-69b7e5aa9249">MakeRequestAsync - перегрузка</a>  
<a href="ae7ef404-1be2-4da8-5f79-9ca48b77858c">PixelCombats.Api.Client.MainMenu.Services.RoomList - пространство имён</a>  
