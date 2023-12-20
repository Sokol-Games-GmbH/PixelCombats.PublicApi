# ITimersContext - интерфейс


контекст таймеров в комнате



## Definition
**Пространство имён:** <a href="371274c7-7cea-bcb1-e32d-9fb1e088bb07">PixelCombats.Api.RoomServer.Services.Timers</a>  
**Сборка:** PixelCombats.PublicAPI (в PixelCombats.PublicAPI.dll) Версия: 1.0.0.0 (1.0.0.0)

**C#**
``` C#
public interface ITimersContext : IEnumerable<ITimerApi>, 
	IEnumerable
```
**VB**
``` VB
Public Interface ITimersContext
	Inherits IEnumerable(Of ITimerApi), IEnumerable
```
**C++**
``` C++
public interface class ITimersContext : IEnumerable<ITimerApi^>, 
	IEnumerable
```
**F#**
``` F#
type ITimersContext = 
    interface
        interface IEnumerable<ITimerApi>
        interface IEnumerable
    end
```

<table><tr><td><strong>Implements</strong></td><td><a href="https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1" target="_blank" rel="noopener noreferrer">IEnumerable</a>(<a href="04f31ee0-1099-1958-764e-858007901ce7">ITimerApi</a>), <a href="https://learn.microsoft.com/dotnet/api/system.collections.ienumerable" target="_blank" rel="noopener noreferrer">IEnumerable</a></td></tr>
</table>



## Методы
<table>
<tr>
<td><a href="f1c9c639-5aa4-33eb-68c3-18303fec89f1">Get</a></td>
<td>возвращает API для работы с таймером. <p>если таймер еще небыл добавлен, то всеравно вернет таймер, но он будет не активным (см. <a href="0083c643-d2ac-f07c-66d2-1fb6a6df7945">IsStarted</a>)</p></td></tr>
<tr>
<td><a href="https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1.getenumerator#system-collections-generic-ienumerable-1-getenumerator" target="_blank" rel="noopener noreferrer">GetEnumerator</a></td>
<td>Возвращает перечислитель, выполняющий перебор элементов в коллекции.<br />(Унаследован от <a href="https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1" target="_blank" rel="noopener noreferrer">IEnumerable</a>(<a href="04f31ee0-1099-1958-764e-858007901ce7">ITimerApi</a>))</td></tr>
</table>

## См. также


#### Ссылки
<a href="371274c7-7cea-bcb1-e32d-9fb1e088bb07">PixelCombats.Api.RoomServer.Services.Timers - пространство имён</a>  
