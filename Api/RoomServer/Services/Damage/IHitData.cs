using PixelCombats.Api.Basic.Structures.Math;

namespace PixelCombats.Api.RoomServer.Services.Damage
{
	/// <summary>
	/// Интерфейс данных попадания по игроку.
	/// </summary>
	public interface IHitData
	{
		/// <summary>
		/// Нанесенный урон.
		/// </summary>
		float Damage { get; }

		/// <summary>
		/// ID оружия, которым нанесли урон.
		/// </summary>
		ushort WeaponID { get; }

		/// <summary>
		/// Точка, с которой был послан урон (откуда стреляли, резали или где лежала граната).
		/// </summary>
		Vector3 ShootPoint { get; }

		/// <summary>
		/// ID коллайдера аватара, по которому нанесли урон.
		/// </summary>
		byte ColliderID { get; }

		/// <summary>
		/// Истина, если это смертельное попадание.
		/// </summary>
		bool Death { get; }

		/// <summary>
		/// Истина, если попадание в голову.
		/// </summary>
		bool IsHeadShot { get; }
	}
}


