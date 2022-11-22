using PixelCombats.Api.RoomServer.Services.Teams;

namespace PixelCombats.Api.RoomServer.Interfaces
{
	/// <summary>
	/// контекст команды
	/// </summary>
	public interface ITeamContext
	{
		/// <summary>
		/// команда
		/// </summary>
		ITeamApi Team { get; }
	}
}