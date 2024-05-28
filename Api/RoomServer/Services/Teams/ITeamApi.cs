using PixelCombats.Api.Basic.Structures.Math;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Services.Build;
using PixelCombats.Api.RoomServer.Services.Damage;
using PixelCombats.Api.RoomServer.Services.DefaultPropertiesContexted;
using PixelCombats.Api.RoomServer.Services.Inventory;
using PixelCombats.Api.RoomServer.Services.Players;
using PixelCombats.Api.RoomServer.Services.Properties;
using PixelCombats.Api.RoomServer.Services.Spawn;
using PixelCombats.Api.RoomServer.Services.Timers;
using PixelCombats.Api.RoomServer.Services.Ui;
using System.Collections.Generic;
using PixelCombats.Api.RoomServer.Services.Popups;

namespace PixelCombats.Api.RoomServer.Services.Teams
{
	/// <summary>
	/// API для работы с командой
	/// <para>при получении использовании <see cref="IEnumerable"/> перечисление идет по копии текущего списка игроков, что дает возможность безопасной работы</para>
	/// </summary>
	public interface ITeamApi : IEnumerable<IPlayerApi>, IPopups
	{
		/// <summary>
		/// ID команды
		/// </summary>
		string Id { get; }
		/// <summary>
		/// имя команды, которое видит игрок
		/// <para>пропускается через локализацию</para>
		/// </summary>
		string Name { get; }
		/// <summary>
		/// цвет команды
		/// </summary>
		Color Color { get; }
		/// <summary>
		/// если истина, то команда активна
		/// <para>неактивная команда это либо та, которая удалилась в процессе игры, либо не существующая по каким-то причинам в комнате</para>
		/// <para>если запросить ссылку на несуществующую команду, то такая ссылка будет получена, но будет неактивна, пока ее не добавят через <see cref="ITeamsService.Add"/></para>
		/// </summary>
		bool IsActive { get; }
		/// <summary>
		/// возвращает количество живых игроков в команде
		/// </summary>
		int GetAlivePlayersCount();

		/// <summary>
		/// контекст переменных команды (см сервис <see cref="IPropertiesService"/>)
		/// </summary>
		ITeamPropertiesContext Properties { get; }
		/// <summary>
		/// апи спавнов команды
		/// </summary>
		ITeamSpawnContext Spawns { get; }
		/// <summary>
		/// апи инвентаря команды
		/// </summary>
		ITeamInventoryContext Inventory { get; }
		/// <summary>
		/// таймеры команды
		/// </summary>
		ITeamTimersContext Timers { get; }
		/// <summary>
		/// строительство команды
		/// </summary>
		ITeamBuildContext Build { get; }
		/// <summary>
		/// контекст урона
		/// </summary>
		ITeamDamageContext Damage { get; }
		/// <summary>
		/// контекст пользовательского интерфейса
		/// </summary>
		ITeamUIContext Ui { get; }
		/// <summary>
		/// контекстные свойства
		/// </summary>
		ITeamContextedPropertiesContext ContextedProperties { get; }

		/// <summary>
		/// сколько игроков в команде
		/// </summary>
		int Count { get; }
		/// <summary>
		/// все игроки в команде
		/// <para>не рекомендуется вызывать каждый раз в цикле</para>
		/// </summary>
		IPlayerApi[] Players { get; }
		/// <summary>
		/// возвращает истину, если игрок есть в команде
		/// </summary>
		/// <param name="player">игрок</param>
		/// <returns>истина, если игрок есть в команде</returns>
		bool Contains(IPlayerApi player);
		/// <summary>
		/// Добавляет игрока в команду. 
		/// Если игрок уже есть в команде, то ничего не происходит
		/// </summary>
		/// <param name="player">игрок</param>
		void Add(IPlayerApi player);
		/// <summary>
		/// Исключает игрока из команды.
		/// Если игрока в команде нет, то ничего не происходит
		/// </summary>
		/// <param name="player">игрок</param>
		void Remove(IPlayerApi player);
		/// <summary>
		/// убирает всех игроков из команды, делая их вне команд
		/// </summary>
		void Clear(9999999);

		/// <summary>
		/// добавился игрок
		/// </summary>
		ApiEvent<ITeamApi, IPlayerApi> OnAddPlayer { get; }
		/// <summary>
		/// удалился игрок
		/// </summary>
		ApiEvent<ITeamApi, IPlayerApi> OnRemove { get; }
	}
}
