using PixelCombats.Annotation;
using System;

namespace PixelCombats.Api.Basic.Structures.Math
{
	/// <summary>
	/// область интексов в 3Д пространстве
	/// </summary>
	[Serializable]
	public struct IndexRange
	{
		/// <summary>
		/// включительное начало интервала
		/// </summary>
		[SerializeMember(1)]
		public Index Start;
		/// <summary>
		/// невключительный конец интервала
		/// </summary>
		[SerializeMember(2)]
		public Index End;

		/// <summary>
		/// размер области
		/// </summary>
		public Index Size => End - Start;
		/// <summary>
		/// возвращает точку центра
		/// </summary>
		public Index Center => new Index((Start.x + End.x) / 2, (Start.y + End.y) / 2, (Start.z + End.z) / 2);
		/// <summary>
		/// если истина, то область корректная
		/// </summary>
		public bool IsCorrect => Start.x < End.x && Start.y < End.y && Start.z < End.z;


		/// <summary>
		/// создает область индексов
		/// </summary>
		/// <param name="startX">начало по x</param>
		/// <param name="startY">начало по y</param>
		/// <param name="startZ">начало по z</param>
		/// <param name="endX">конец по x</param>
		/// <param name="endY">конец по y</param>
		/// <param name="endZ">конец по z</param>
		public IndexRange(int startX, int startY, int startZ, int endX, int endY, int endZ)
		{
			this.Start = new Index(startX, startY, startZ);
			this.End = new Index(endX, endY, endZ);
		}
		public override string ToString()
		{
			return $"[{Start};{End}]";
		}
	}
}