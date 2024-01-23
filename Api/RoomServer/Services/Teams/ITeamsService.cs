using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.Basic.Structures.Math;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Services.Players;
using System.Collections.Generic;

namespace PixelCombats.Api.RoomServer.Services.Teams
{
	/// <summary>
	/// Сервис работы с командами
	/// </summary>
	[ScriptObject("Teams", ScriptModuleNames.ROOM_API)]
	public interface ITeamsService : IEnumerable<ITeamApi>
	{
		/// <summary>
		/// сколько всего имеется команд
		/// </summary>
		int TeamsCount { get; }
		/// <summary>
		/// добавляет команду.
		/// <para>Если такая команда уже существует то ничего не происходит</para>
		/// </summary>
		/// <param name="newTeamData">описание команды</param>
		/// <param name="id">ID команды, по которому к ней можно обращаться</param>
		/// <param name="name">имя команды, которое видят игроки (пропускается через локализацию)</param>
		/// <param name="color">цвет команды</param>
		void Add(string id, string name, Color color);
		/// <summary>
		/// проверяет наличие указанной команды
		/// </summary>
		/// <param name="teamId">ID команды</param>
		/// <returns>истина, если команда существует</returns>
		bool Contains(string teamId);
		/// <summary>
		/// возвращает команду по ее ID.
		/// <para>если команды нет, то выдаст неактивную команду, причем события о том, что создана неактивная команда не будет</para>
		/// </summary>
		/// <param name="teamId">ID команды</param>
		ITeamApi Get(string teamId);
		/// <summary>
		/// попытка получить команду
		/// </summary>
		/// <param name="teamId">ID команды</param>
		/// <param name="team">командыа</param>
		/// <returns>истина, если команда была получена</returns>
		bool TryGetTeam(string teamId, out ITeamApi team);

		/// <summary>
		/// когда какой-либо игрок сменил команду
		/// </summary>
		ApiEvent<IPlayerApi, ITeamsService> OnPlayerChangeTeam { get; }
		/// <summary>
		/// если команда добавлена
		/// </summary>
		ApiEvent<ITeamApi, ITeamsService> OnAddTeam { get; }
		/// <summary>
		/// происходит, когда команда удалилась
		/// </summary>
		ApiEvent<ITeamApi, ITeamsService> OnRemoveTeam { get; }
		/// <summary>
		/// если игрок запросил переход в указанную команду
		/// </summary>
		ApiEvent<IPlayerApi, ITeamApi, ITeamsService> OnRequestJoinTeam { get; }
	}
}