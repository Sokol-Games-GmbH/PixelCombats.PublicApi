using PixelCombats.Api.Basic.Structures.Math;

namespace PixelCombats.Api.Basic
{
	/// <summary>
	/// Информация об изменении прямоугольной области в карте
	/// </summary>
	public interface IMapChange
	{		
		/// <summary>
		/// ID блока (0 означает удаление)
		/// </summary>
		ushort BlockId { get; }

		/// <summary>
		/// Область изменения (для массового изменения)
		/// </summary>
		IndexRange Range { get; }
	}
}