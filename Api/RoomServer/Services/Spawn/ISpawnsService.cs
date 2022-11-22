using System.Runtime.CompilerServices;
using PixelCombats.Api.Basic;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Interfaces;
using PixelCombats.Api.RoomServer.Services.Players;

namespace PixelCombats.Api.RoomServer.Services.Spawn
{
	/// <summary>
	/// логика спавнов
	/// </summary>
	public interface ISpawnContext
	{
		/// <summary>
		/// разрешен ли спавн
		/// <para>по умолчанию разрешен</para>
		/// <para>если запрещен, то игрок или игроки будут задеспавнены</para>
		/// <para>todo реализовано только для контекста комнаты</para>
		/// </summary>
		bool Enable { get; set; }
		/// <summary>
		/// разрешает или запрещает респавн уже заспавненных игроков
		/// <para>по умолчанию true</para>
		/// <para>todo реализовано только для контекста комнаты</para>
		/// </summary>
		bool RespawnEnable { get; set; }
		/// <summary>
		/// время, которое нельзя спавниться после смерти
		/// <para>по умолчанию 5 сек</para>
		/// </summary>
		IApiProp<float, ISpawnContext> RespawnTime { get; }
		/// <summary>
		/// какие группы спавнпоинтов используются для спавна
		/// </summary>
		ISpawnPointsGroupIndexSet SpawnPointsGroups { get; }
		/// <summary>
		/// кастомная группа спавнпоинтов. Если в ней есть хть один элемент, то элементы контекста спавнятся в этой группе а не из базы данных комнаты
		/// </summary>
		ISpawnPointsGroup CustomSpawnPoints { get; }

		/// <summary>
		/// аргументы спавна по умолчанию для конкретного игрока
		/// <para>берется с подобного свойства команды, или если вне команд, то с контекста комнаты</para>
		/// </summary>
		SpawnArgs DefaultSpawnArgs { get; }

		/// <summary>
		/// попытка спавна по правилу <see cref="DefaultSpawnArgs"/>
		/// </summary>
		void Spawn();
		/// <summary>
		/// попытка спавна
		/// </summary>
		/// <param name="args">аргументы спавна</param>
		void Spawn(SpawnArgs args);
		/// <summary>
		/// попытка спавна по правилу <see cref="DefaultSpawnArgs"/>
		/// </summary>
		/// <param name="spawnPoint">позиция спавна</param>
		void Spawn(SpawnPoint spawnPoint);
		/// <summary>
		/// попытка спавна
		/// </summary>
		/// <param name="spawnPoint">позиция спавна</param>
		/// <param name="args">аргументы спавна</param>
		void Spawn(SpawnPoint spawnPoint, SpawnArgs args);
		/// <summary>
		/// принудительный деспавн
		/// </summary>
		void Despawn();
	}

	/// <summary>
	/// контекст спавна в комнате
	/// </summary>
	public interface IRoomSpawnContext : ISpawnContext
	{
		/// <summary>
		/// аргументы спавна по умолчанию в комнате
		/// <para>если не задано то будет использоваться <see cref="SpawnArgs.Default"/></para>
		/// </summary>
		SpawnArgs DefaultSpawnArgs { get; set; }
		/// <summary>
		/// происходит, когда спавнится игрок
		/// </summary>
		ApiEvent<IPlayerApi, SpawnPoint, IRoomSpawnContext> OnSpawn { get; }
		/// <summary>
		/// при деспавне игрока
		/// </summary>
		ApiEvent<IPlayerApi, IRoomSpawnContext> OnDespawn { get; }
	}

	/// <summary>
	/// API спавна для команды
	/// </summary>
	public interface ITeamSpawnContext : ISpawnContext, ITeamContext
	{
		/// <summary>
		/// аргументы спавна по умолчанию в команде
		/// <para>если не задано то будет использоваться <see cref="SpawnArgs.Default"/></para>
		/// </summary>
		SpawnArgs DefaultSpawnArgs { get; set; }
		/// <summary>
		/// происходит, когда спавнится игрок
		/// </summary>
		ApiEvent<IPlayerApi, SpawnPoint, ITeamSpawnContext> OnSpawn { get; }
		/// <summary>
		/// при деспавне игрока
		/// </summary>
		ApiEvent<IPlayerApi, ITeamSpawnContext> OnDespawn { get; }
	}

	/// <summary>
	/// API спавна для игрока
	/// </summary>
	public interface IPlayerSpawnContext : ISpawnContext, IPlayerContext
	{
		/// <summary>
		/// если истина, то игрок заспавнен
		/// </summary>
		bool IsSpawned { get; }

		/// <summary>
		/// сколько времени осталось до спавна
		/// </summary>
		float TimeToSpawn { get; set; }

		/// <summary>
		/// спавнит игрока в указанном месте
		/// <para>может быть выполнена только сервером</para>
		/// </summary>
		/// <param name="spawnPoint">куда заспавнить игрока</param>
		void Spawn(SpawnPoint spawnPoint);
		/// <summary>
		/// происходит, когда спавнится игрок
		/// </summary>
		ApiEvent<IPlayerApi, SpawnPoint, IPlayerSpawnContext> OnSpawn { get; }
		/// <summary>
		/// при деспавне игрока
		/// </summary>
		ApiEvent<IPlayerApi, IPlayerSpawnContext> OnDespawn { get; }
	}

	/// <summary>
	/// сервис спавнов
	/// </summary>
	[ScriptingRoot("Spawns")]
	public interface ISpawnsService :
		IContextedService<IRoomSpawnContext, ITeamSpawnContext, IPlayerSpawnContext>
	{
		/// <summary>
		/// ID группы спавна для внекомандных игроков
		/// </summary>
		int DefaultNoTeamSpawnPointsGroupId { get; }
		/// <summary>
		/// ID группы спавна для красной команды
		/// </summary>
		int DefaultRedTeamSpawnPointsGroupId { get; }
		/// <summary>
		/// ID группы спавнов для синей команды
		/// </summary>
		int DefaultBlueTeamSpawnPointsGroupId { get; }

		/// <summary>
		/// возвращает базу данных спавнпоинтов
		/// </summary>
		ISpawnPointsData SpawnPoints { get; }
		/// <summary>
		/// возвращает угол просмотра для спавна
		/// </summary>
		/// <param name="x">точка x спавна</param>
		/// <param name="z">точка Z спавна</param>
		/// <param name="lookX">точка X куда смотреть</param>
		/// <param name="lookZ">точка Z куда смотреть</param>
		/// <returns></returns>
		float GetSpawnRotation(float x, float z, float lookX, float lookZ);

		/// <summary>
		/// при спавне любого игрока
		/// </summary>
		ApiEvent<IPlayerApi, SpawnPoint, ISpawnsService> OnSpawn { get; }
		/// <summary>
		/// при деспавне игрока
		/// </summary>
		ApiEvent<IPlayerApi, ISpawnsService> OnDespawn { get; }
	}
}