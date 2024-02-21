using PixelCombats.Api.Basic.Structures.Math;
using System.Collections.Generic;

namespace PixelCombats.Api.RoomServer.Services.Areas
{
	/// <summary>
	/// набор зон
	/// </summary>
	public interface IRangesSet : IEnumerable<IndexRange>
	{
		/// <summary>
		/// набор областей, к которой относится
		/// </summary>
		IArea Area { get; }

		/// <summary>
		/// общее количество областей
		/// </summary>
		int Count { get; }
		/// <summary>
		/// возвраает все области
		/// <para>Не рекомендуется использовать каждый раз в цикле. Выностие за цикл</para>
		/// </summary>
		IndexRange[] All { get; }
		/// <summary>
		/// удаляет все области
		/// </summary>
		void Clear();
		/// <summary>
		/// добавляет область
		/// </summary>
		/// <param name="range">область</param>
		bool Add(IndexRange range);
		/// <summary>
		/// удаляет область
		/// </summary>
		/// <param name="range">область</param>
		bool Remove(IndexRange range);
		/// <summary>
		/// проверяет наличие указанной области
		/// </summary>
		/// <param name="range">область</param>
		bool Contains(IndexRange range);
		/// <summary>
		/// возвращает среднюю позицию всех зон
		/// <para>если зон нет то даст 0</para>
		/// </summary>
		/// <returns>индекс средней позиции</returns>
		public Index GetAveragePosition();
	}
}