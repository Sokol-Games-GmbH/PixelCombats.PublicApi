using PixelCombats.Api.RoomServer.Services.Players;
using PixelCombats.Api.RoomServer.Services.Teams;

namespace PixelCombats.Api.RoomServer.Interfaces
{
	/// <summary>
	/// интерфейс контекстного сервиса, разбиторо на 3 типа иерархических контекстов
	/// </summary>
	/// <typeparam name="TRoomContext">тип контекста комнаты</typeparam>
	/// <typeparam name="TTeamContext">тип контекста команды</typeparam>
	/// <typeparam name="TPlayerContext">тип контекста игрока</typeparam>
	public interface IContextedService<out TRoomContext, out TTeamContext, out TPlayerContext>
		where TTeamContext : ITeamContext
		where TPlayerContext : IPlayerContext
	{
		/// <summary>
		/// возвращает контекст комнаты
		/// </summary>
		/// <returns></returns>
		TRoomContext GetContext();
		/// <summary>
		/// возвращает контекст команды
		/// </summary>
		/// <param name="team">команда</param>
		TTeamContext GetContext(ITeamApi team);
		/// <summary>
		/// возвращает контекст игрока
		/// </summary>
		/// <param name="player">игрок</param>
		TPlayerContext GetContext(IPlayerApi player);
	}
}