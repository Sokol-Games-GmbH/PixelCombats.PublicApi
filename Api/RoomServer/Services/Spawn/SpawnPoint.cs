using System;
using PixelCombats.Annotation;
using Index = PixelCombats.Api.Basic.Structures.Math.Index;

namespace PixelCombats.Api.RoomServer.Services.Spawn
{
	/// <summary>
	/// описывает точку спавна
	/// </summary>
	[Serializable]
	public struct SpawnPoint
	{
		/// <summary>
		/// координата
		/// </summary>
		[SerializeMember(1)]
		public Index Position;
		/// <summary>
		/// угол вращения в градусах
		/// </summary>
		[SerializeMember(2)]
		public float Angle;

		public override string ToString()
		{
			return $"{Position},{Angle}";
		}
		public static bool operator ==(SpawnPoint a, SpawnPoint b)
		{
			return a.Angle == b.Angle && a.Position == b.Position;
		}
		public static bool operator !=(SpawnPoint a, SpawnPoint b)
		{
			return !(a == b);
		}
	}
}