using System;
using JavaScriptEngine.DataAnnotations;
using PixelCombats.Annotation;

namespace PixelCombats.Api.Basic.Structures.Math
{
	[Serializable]
	[ScriptAllowed]
	[ScriptType("Vector2", ScriptModuleNames.BASIC)]
	public struct Vector2
	{
		[SerializeMember(1)]
		public float x;
		[SerializeMember(2)]
		public float y;

		public Vector2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}
		public override string ToString()
		{
			return $"({x},{y})";
		}

		public static bool operator ==(Vector2 a, Vector2 b)
		{
			return a.x == b.x && a.y == b.y;
		}
		public static bool operator !=(Vector2 a, Vector2 b)
		{
			return !(a == b);
		}
		public static Vector2 operator +(Vector2 i1, Vector2 i2)
		{
			return new Vector2 {
				x = i1.x + i2.x,
				y = i1.y + i2.y
			};
		}
		public static Vector2 operator -(Vector2 i1, Vector2 i2)
		{
			return new Vector2 {
				x = i1.x - i2.x,
				y = i1.y - i2.y
			};
		}
	}
}