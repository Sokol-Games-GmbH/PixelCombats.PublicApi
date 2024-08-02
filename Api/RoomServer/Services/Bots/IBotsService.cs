using JavaScriptEngine.DataAnnotations;
using PixelCombats.Annotation;
using PixelCombats.Api.Basic.Structures.Math;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Services.Players;
using System;

namespace PixelCombats.Api.RoomServer.Services.Bots
{
	/// <summary>
	/// бот
	/// </summary>
	public interface IBot
	{
		/// <summary>
		/// ID бота
		/// </summary>
		int Id { get; }
		/// <summary>
		/// позиция бота
		/// </summary>
		Vector3 Position { get; set; }
		/// <summary>
		/// вращение бота
		/// </summary>
		Vector2 Rotation { get; set; }
		/// <summary>
		/// ID оружия или 0, если его нет
		/// </summary>
		ushort WeaponId { get; set; }
		/// <summary>
		/// атакует ли бот
		/// </summary>
		bool Attack { get; set; }
		/// <summary>
		/// id скина бота
		/// </summary>
		byte SkinId { get; set; }
		/// <summary>
		/// направление взгляда
		/// </summary>
		Vector3 LookDirection { get; set; }
		/// <summary>
		/// задает точку, в которую смотрит бот
		/// </summary>
		/// <param name="lookPoint">точка, в которую смотрит</param>
		void LookAt(Vector3 lookPoint);
		/// <summary>
		/// задает позицию и вектор взгляда бота
		/// <para>предпочтительно для тех случаев, когда 2 параметра задаются одновременно, например спавн или телепорт</para>
		/// </summary>
		/// <param name="position">позиция бота</param>
		/// <param name="lookDirection">вектор взгляда бота</param>
		void SetPositionAndDirection(Vector3 position, Vector3 lookDirection);
		/// <summary>
		/// уничтожает бота
		/// </summary>
		void Destroy();
	}

	[ScriptType("HumanBotSpawnData", ScriptModuleNames.ROOM_API)]
	[ScriptAllowed]
	[Serializable]
	public class HumanBotSpawnData
	{
		[SerializeMember(1)]
		public Vector3 Position;
		[SerializeMember(2)]
		public Vector2 Rotation;
		[SerializeMember(3)]
		public ushort WeaponId;
		[SerializeMember(4)]
		public byte SkinId = 11;
	}
	/// <summary>
	/// гуманоидный бот
	/// </summary>
	public interface IHumanBot : IBot
	{
	}

	/// <summary>
	/// данные смерти бота
	/// </summary>
	public interface IBotDeathData
	{
		public IBot Bot { get; }
		public IPlayerApi Player { get; }
	}
	/// <summary>
	/// управляет ботами в комнате
	/// </summary>
	[ScriptObject("Bots", ScriptModuleNames.ROOM_API)]
	public interface IBotsService
	{
		/// <summary>
		/// сколько всего создано ботов
		/// </summary>
		int Count { get; }
		/// <summary>
		/// возвращает всех ботов
		/// <para>использование в цикле не рекомендуется. Получайте всех ботов до цикла</para>
		/// </summary>
		IBot[] All();
		/// <summary>
		/// порождает нового гуманоидного бота
		/// </summary>
		/// <returns>гуманоидный бот</returns>
		void CreateHuman(HumanBotSpawnData data);
		/// <summary>
		/// возвращает бота по его ID или null, если такого бота нет
		/// </summary>
		/// <param name="id">ID бота</param>
		IBot Get(int id);

		/// <summary>
		/// создан бот
		/// </summary>
		ApiEvent<IBot, IBotsService> OnNewBot { get; }
		/// <summary>
		/// когда умер бот
		/// </summary>
		ApiEvent<IBotDeathData, IBotsService> OnBotDeath { get; }
		/// <summary>
		/// когда бот удален
		/// </summary>
		ApiEvent<IBot, IBotsService> OnBotRemove { get; }
	}
}