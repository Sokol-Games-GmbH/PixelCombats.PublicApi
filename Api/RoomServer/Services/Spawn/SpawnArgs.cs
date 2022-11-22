using PixelCombats.Annotation;
using System;

namespace PixelCombats.Api.RoomServer.Services.Spawn
{
	/// <summary>
	/// аргументы спавна игрока
	/// </summary>
	[Serializable]
	public struct SpawnArgs // todo удалить
	{
		/// <summary>
		/// если задано, то будет учитывать <see cref="ISpawnContext.Enable"/>
		/// <para>по умолчанию true</para>
		/// </summary>
		[SerializeMember(1)]
		public bool Enable;
		/// <summary>
		/// если задано, то будет учитывать <see cref="IPlayerSpawnContext.TimeToSpawn"/>
		/// </summary>
		[SerializeMember(2)]
		public bool TimeToSpawn;
		/// <summary>
		/// если истина, то будет приплюсовывать счетчик спавнов
		/// </summary>
		[SerializeMember(3)]
		public bool AddSpawns;
		/// <summary>
		/// если истина, то в случае невозможности получения спавнпоинта будет спавн в случайном месте
		/// </summary>
		[SerializeMember(4)]
		public bool DefaultSpawnPoint;
		/// <summary>
		/// если истина, то учитывается попытка спавна с настроек игрока
		/// </summary>
		[SerializeMember(5)]
		public bool Player;
		/// <summary>
		/// если истина, то учитывается попытка спавна с настроек команды игрока
		/// </summary>
		[SerializeMember(6)]
		public bool Team;
		/// <summary>
		/// если истина, то учитывается попытка спавна с настроек комнаты
		/// </summary>
		[SerializeMember(7)]
		public bool Room;

		/// <summary>
		/// параметры спавна по умолчанию
		/// </summary>
		public static readonly SpawnArgs Default = new SpawnArgs {
			Enable = true,
			TimeToSpawn = true,
			AddSpawns = true,
			Player = true,
			Team = true,
			Room = true,
			DefaultSpawnPoint = true
		};

		public override string ToString()
		{
			return $"spawn args: [Enable: {Enable}, Delay: {TimeToSpawn}, AddSpawn: {AddSpawns}]";
		}
	}
}