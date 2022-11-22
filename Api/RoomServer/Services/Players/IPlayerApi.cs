using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Services.Build;
using PixelCombats.Api.RoomServer.Services.Damage;
using PixelCombats.Api.RoomServer.Services.Inventory;
using PixelCombats.Api.RoomServer.Services.Properties;
using PixelCombats.Api.RoomServer.Services.Spawn;
using PixelCombats.Api.RoomServer.Services.Teams;
using PixelCombats.Api.RoomServer.Services.Timers;
using PixelCombats.Api.RoomServer.Services.Ui;

namespace PixelCombats.Api.RoomServer.Services.Players
{
	/// <summary>
	/// API для работы с игроком
	/// </summary>
	public interface IPlayerApi
	{
		/// <summary>
		/// ID игрока
		/// <para>этот идентиффикатор всегда постоянный для игрока</para>
		/// </summary>
		string Id { get; }
		/// <summary>
		/// целочисленный идентиффикатор игрока в комнате
		/// </summary>
		int IdInRoom { get; }
		/// <summary>
		/// ник игрока
		/// </summary>
		string NickName { get; }
		/// <summary>
		/// истина, если данный игрок онлайн
		/// </summary>
		bool IsOnline { get; }
		/// <summary>
		/// содержит ссылку на команду, в которой содержится игрок или null, если игрок не находится ни в одной команде
		/// </summary>
		ITeamApi Team { get; }
		/// <summary>
		/// жив игрок или нет
		/// <para>пока не заспванится false</para>
		/// </summary>
		bool IsAlive { get; }

		/// <summary>
		/// контекст переменных игрока (см сервис <see cref="IPropertiesService"/>)
		/// </summary>
		IPlayerPropertiesContext Properties { get; }
		/// <summary>
		/// апи спавнов игрока
		/// </summary>
		IPlayerSpawnContext Spawns { get; }
		/// <summary>
		/// апи инвентаря игрока
		/// </summary>
		IPlayerInventoryContext Inventory { get; }
		/// <summary>
		/// таймеры игрока
		/// </summary>
		IPlayerTimersContext Timers { get; }
		/// <summary>
		/// строительство игрока
		/// </summary>
		IPlayerBuildContext Build { get; }
		/// <summary>
		/// контекст урона
		/// </summary>
		IPlayerDamageContext Damage { get; }
		/// <summary>
		/// контекст пользовательского интерфейса
		/// </summary>
		IPlayerUIContext Ui { get; }

		/// <summary>
		/// сменился онлайн
		/// </summary>
		ApiEvent<IPlayerApi> OnIsOnline { get; }
		/// <summary>
		/// сменилась команда
		/// </summary>
		ApiEvent<IPlayerApi> OnTeam { get; }
		/// <summary>
		/// сменился ник
		/// </summary>
		ApiEvent<IPlayerApi> OnNickName { get; }
		/// <summary>
		/// сменилось состояние жив или мертв
		/// </summary>
		ApiEvent<IPlayerApi> OnIsAlive { get; }
	}
}