using System;
using PixelCombats.Annotation;

namespace PixelCombats.Api.Basic.Structures.Math
{
	[Serializable]
	public struct Vector3
	{
		[SerializeMember(1)]
		public float x;
		[SerializeMember(2)]
		public float y;
		[SerializeMember(3)]
		public float z;

		public Vector3(float x, float y , float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		/// <summary>
		/// преобразует координату в индексное пространство
		/// <para>используется, когда например нужно преобразовать координаты игрока в индекс блока на карте</para>
		/// </summary>
		public Index ToIndex()
		{
			return new Index(
				(int)x < 0 ? (int)x - 1 : (int)x,
				(int)y < 0 ? (int)y - 1 : (int)y,
				(int)z < 0 ? (int)z - 1 : (int)z
			);
		}
		public override string ToString()
		{
			return $"({x},{y},{z})";
		}

		public static bool operator ==(Vector3 a, Vector3 b)
		{
			return a.x == b.x && a.y == b.y && a.z == b.z;
		}
		public static bool operator !=(Vector3 a, Vector3 b)
		{
			return !(a == b);
		}
		public static Vector3 operator +(Vector3 i1, Vector3 i2)
		{
			return new Vector3 {
				x = i1.x + i2.x,
				y = i1.y + i2.y,
				z = i1.z + i2.z
			};
		}
		public static Vector3 operator -(Vector3 i1, Vector3 i2)
		{
			return new Vector3 {
				x = i1.x - i2.x,
				y = i1.y - i2.y,
				z = i1.z - i2.z
			};
		}
	}
}