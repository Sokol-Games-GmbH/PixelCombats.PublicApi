using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Interfaces;
using System.Collections.Generic;

namespace PixelCombats.Api.RoomServer.Services.Timers
{
	/// <summary>
	/// контекст таймеров в комнате
	/// </summary>
	public interface ITimersContext : IEnumerable<ITimerApi>
	{
		/// <summary>
		/// возвращает массив всех таймеров
		/// <para>Не рекомендуется использовать каждый раз в цикле. Выностие за цикл</para>
		/// </summary>
		ITimerApi[] All { get; }
		/// <summary>
		/// возвращает API для работы с таймером.
		/// <para>если таймер еще небыл добавлен, то всеравно вернет таймер, но он будет не активным (см. <see cref="ITimerApi.IsStarted"/>)</para>
		/// </summary>
		/// <param name="id">ID таймера</param>
		ITimerApi Get(string id);
	}

	/// <summary>
	/// контекст таймеров комнаты
	/// </summary>
	public interface IRoomTimersContext : ITimersContext, ITimerEvents { }

	/// <summary>
	/// контекст таймеров игрока
	/// </summary>
	public interface IPlayerTimersContext : ITimersContext, IPlayerContext, ITimerEvents { }

	/// <summary>
	/// контекст таймеров команды
	/// </summary>
	public interface ITeamTimersContext : ITimersContext, ITeamContext, ITimerEvents { }

	/// <summary>
	/// сервис таймеров в комнате
	/// </summary>
	[ScriptObject("Timers", ScriptModuleNames.ROOM_API)]
	public interface ITimersService :
		IContextedService<IRoomTimersContext, ITeamTimersContext, IPlayerTimersContext>
	{
		/// <summary>
		/// при выполнении любого таймера любой команды
		/// </summary>
		ApiEvent<ITimerApi> OnTeamTimer { get; }
		/// <summary>
		/// при выполнении любого таймера любого игрока
		/// </summary>
		ApiEvent<ITimerApi> OnPlayerTimer { get; }
	}
}