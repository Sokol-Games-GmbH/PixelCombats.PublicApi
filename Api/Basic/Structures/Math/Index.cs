using PixelCombats.Annotation;
using System;

namespace PixelCombats.Api.Basic.Structures.Math
{
	/// <summary>
	/// индекс или воксельная координата
	/// </summary>
	[Serializable]
	public struct Index : IComparable<Index> // todo сделать общую математическую библиотеку и вынести это туда
	{
		/// <summary>
		/// координата X
		/// </summary>
		[SerializeMember(1)]
		public int x;
		/// <summary>
		/// координата Y
		/// </summary>
		[SerializeMember(2)]
		public int y;
		/// <summary>
		/// координата Z
		/// </summary>
		[SerializeMember(3)]
		public int z;

		public Index(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public Vector3 ToVector()
		{
			return new Vector3(x, y, z);
		}
		public static bool operator ==(Index a, Index b)
		{
			return a.x == b.x && a.y == b.y && a.z == b.z;
		}
		public static bool operator !=(Index a, Index b)
		{
			return !(a == b);
		}
		public static Index operator +(Index i1, Index i2)
		{
			return new Index {
				x = i1.x + i2.x,
				y = i1.y + i2.y,
				z = i1.z + i2.z
			};
		}
		public static Index operator -(Index i1, Index i2)
		{
			return new Index {
				x = i1.x - i2.x,
				y = i1.y - i2.y,
				z = i1.z - i2.z
			};
		}
		public int CompareTo(Index other)
		{
			var xComparison = x.CompareTo(other.x);
			if (xComparison != 0) return xComparison;
			var yComparison = y.CompareTo(other.y);
			if (yComparison != 0) return yComparison;
			return z.CompareTo(other.z);
		}
		public override string ToString()
		{
			return $"({x},{y},{z})";
		}
	}
}