using PixelCombats.Annotation;
using System;

namespace PixelCombats.Api.Basic.Structures.Math
{
	[Serializable]
	public struct Color
	{
		[SerializeMember(1)]
		public float r;
		[SerializeMember(2)]
		public float g;
		[SerializeMember(3)]
		public float b;
		[SerializeMember(4)]
		public float a;

		public Color(float r, float g, float b, float a)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		public bool Equals(Color other)
		{
			return r.Equals(other.r) && g.Equals(other.g) && b.Equals(other.b) && a.Equals(other.a);
		}
		public override bool Equals(object obj)
		{
			return obj is Color other && Equals(other);
		}
		public override int GetHashCode()
		{
			unchecked {
				var hashCode = r.GetHashCode();
				hashCode = (hashCode * 397) ^ g.GetHashCode();
				hashCode = (hashCode * 397) ^ b.GetHashCode();
				hashCode = (hashCode * 397) ^ a.GetHashCode();
				return hashCode;
			}
		}

		public static bool operator ==(Color c1, Color c2)
		{
			return c1.r == c2.r && c1.g == c2.g && c1.b == c2.b && c1.a == c2.a;
		}
		public static bool operator !=(Color c1, Color c2)
		{
			return !(c1 == c2);
		}
		public int ToInt32()
		{
			return ((byte)(255 * r) << 24) | ((byte)(255 * g) << 16) | ((byte)(255 * b) << 8) | (byte)(255 * a);
		}
		public static Color FromInt32(int color)
		{
			var a = (byte)color / 255.0f;
			color >>= 8;
			var b = (byte)color / 255.0f;
			color >>= 8;
			var g = (byte)color / 255.0f;
			color >>= 8;
			var r = (byte)color / 255.0f;

			return new Color(r, g, b, a);
		}

		public override string ToString()
		{
			return $"[{r};{g};{b};{a}]";
		}
	}
}