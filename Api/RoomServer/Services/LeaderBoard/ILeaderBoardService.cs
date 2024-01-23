using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Services.Players;
using PixelCombats.Api.RoomServer.Services.Teams;
using System.Collections.Generic;

namespace PixelCombats.Api.RoomServer.Services.LeaderBoard
{
	/// <summary>
	/// лидерборд - определяет списки лидирующих игроков и команд
	/// </summary>
	[ScriptObject("LeaderBoard", ScriptModuleNames.ROOM_API)]
	public interface ILeaderBoardService : IComparer<IPlayerApi>
	{
		/// <summary>
		/// функция сравнения игроков
		/// <para>Принимает игрока, возвращает значение веса игрока в лидерборде.</para>
		/// </summary>
		ApiFunc<IPlayerApi, int> PlayersWeightGetter { get; set; }
		/// <summary>
		/// функция сравнения команд
		/// <para>Принимает команду, возвращает значение веса команды в лидерборде.</para>
		/// </summary>
		ApiFunc<ITeamApi, int> TeamWeightGetter { get; set; }

		/// <summary>
		/// возвращает всех игроков в команде, в отсортированном порядке
		/// </summary>
		/// <param name="team">команда</param>
		IList<IPlayerApi> GetPlayers(ITeamApi team);

		/// <summary>
		/// имя значения, которые следует выводить в лидерборде для игрока
		/// </summary>
		DisplayValueHeader[] PlayerLeaderBoardValues { get; set; }
		/// <summary>
		/// имя значение, которое необходимо выводить для лидерборда команд
		/// </summary>
		DisplayValueHeader TeamLeaderBoardValue { get; set; }

		/// <summary>
		/// возвращает лидерборд команд в комнате
		/// </summary>
		IList<LeaderBoardTeamItem> GetTeams();
		/// <summary>
		/// возвращает лидерборд игроков в комнате
		/// </summary>
		IList<LeaderBoardPlayerItem> GetPlayers();
	}
}