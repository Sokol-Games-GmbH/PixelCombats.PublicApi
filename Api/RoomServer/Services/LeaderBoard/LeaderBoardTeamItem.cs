using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Interfaces;
using PixelCombats.Api.RoomServer.Services.Teams;

namespace PixelCombats.Api.RoomServer.Services.LeaderBoard
{
	/// <summary>
	/// элемент лидерборда для команды
	/// </summary>
	[ScriptAllowed]
	public struct LeaderBoardTeamItem: ITeamContext
	{
		/// <summary>
		/// команда
		/// </summary>
		public ITeamApi Team { get; set; }
		/// <summary>
		/// какой вес у команды в лидерборде
		/// </summary>
		public int Weight { get; set; }
	}
}