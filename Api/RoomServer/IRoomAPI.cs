using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Services.Game;
using PixelCombats.Api.RoomServer.Services.Inventory;
using PixelCombats.Api.RoomServer.Services.LeaderBoard;
using PixelCombats.Api.RoomServer.Services.Players;
using PixelCombats.Api.RoomServer.Services.Popups;
using PixelCombats.Api.RoomServer.Services.Properties;
using PixelCombats.Api.RoomServer.Services.Spawn;
using PixelCombats.Api.RoomServer.Services.Teams;
using PixelCombats.Api.RoomServer.Services.TeamsBalancer;
using PixelCombats.Api.RoomServer.Services.Timers;
using PixelCombats.Api.RoomServer.Services.Ui;

namespace PixelCombats.Api.RoomServer
{
	/// <summary>
	/// API для работы с комнатой
	/// </summary>
	[ScriptObject("room", ScriptModuleNames.ROOM_API)]
	public interface IRoomApi : IPopups // todo упразднить попуп перенести в отдельный объект
	{
		/// <summary>
		/// включает или выключает в комнате возможность отправки всплывающих сообщений
		/// <para>задавать можно только в момент инициализации</para>
		/// <para>по умолчанию выключено</para>
		/// </summary>
		bool PopupsEnable { get; set; }

		IPropertiesService Properties { get; }
		IPlayersService Players { get; }
		ITeamsService Teams { get; }
		ITimersService Timers { get; }
		ISpawnsService Spawns { get; }
		IInventoryService Inventory { get; }
		ITeamsBalancerService TeamsBalancer { get; }
		IGameService Game { get; }
		ILeaderBoardService LeaderBoard { get; }
		IUiService Ui { get; }
	}
}