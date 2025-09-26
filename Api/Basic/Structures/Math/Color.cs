using JavaScriptEngine.DataAnnotations;
using PixelCombats.Annotation;
using System;

namespace PixelCombats.Api.Basic.Structures.Math
{
	/// <summary>
	/// описывает цвет
	/// </summary>
	[Serializable]
	[ScriptAllowed]
	[ScriptType("Color", ScriptModuleNames.BASIC)]
	public struct Color
	{
		/// <summary>
		/// красная составляющая. Диапазон значений [0-1]
		/// </summary>
		[SerializeMember(1)]
		public float r;
		/// <summary>
		/// зеленая составляющая. Диапазон значений [0-1]
		/// </summary>
		[SerializeMember(2)]
		public float g;
		/// <summary>
		/// синяя составляющая. Диапазон значений [0-1]
		/// </summary>
		[SerializeMember(3)]
		public float b;
		/// <summary>
		/// прозрачность. Диапазон значений [0-1]
		/// <para>не везде применяется</para>
		/// </summary>
		[SerializeMember(4)]
		public float a;

		public Color(float r, float g, float b, float a)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		public Color(float r, float g, float b)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = 0;
		}

		public Color(Color color)
		{
			this.r = color.r;
			this.g = color.g;
			this.b = color.b;
			this.a = color.a;
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