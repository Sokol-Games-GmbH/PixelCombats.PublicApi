using PixelCombats.Api.Basic;
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
	[ScriptingRoot("room")]
	public interface IRoomApi : IPopups
	{
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