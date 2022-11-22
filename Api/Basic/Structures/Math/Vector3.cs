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
	}
}