using PixelCombats.Api.Basic;
using PixelCombats.Api.Basic.Structures.Math;
using PixelCombats.Api.RoomServer.Services.Areas;

namespace PixelCombats.Api.RoomServer.Services.MapEditor
{
	/// <summary>
	/// редактор карт
	/// </summary>
	[ScriptingRoot("MapEditor")]
	public interface IMapEditorService
	{
		/// <summary>
		/// задает блок в указанной точке
		/// </summary>
		/// <param name="x">координата x</param>
		/// <param name="y">координата y</param>
		/// <param name="z">координата z</param>
		/// <param name="blockId">id блока. 0 - стирает блоки</param>
		void SetBlock(int x, int y, int z, ushort blockId);
		/// <summary>
		/// задает блок в указанной точке
		/// </summary>
		/// <param name="index">индекс точки</param>
		/// <param name="blockId">id блока. 0 - стирает блоки</param>
		void SetBlock(Index index, ushort blockId);
		/// <summary>
		/// закрашивает облать
		/// </summary>
		/// <param name="range">область</param>
		/// <param name="blockId">id блока. 0 - стирает блоки</param>
		void SetBlock(IndexRange range, ushort blockId);
		/// <summary>
		/// закрашивает зону
		/// </summary>
		/// <param name="area">зона</param>
		/// <param name="blockId">id блока. 0 - стирает блоки</param>
		void SetBlock(IArea area, ushort blockId);
		/// <summary>
		/// закрашивает область
		/// </summary>
		/// <param name="xStart">x начала</param>
		/// <param name="yStart">y начала</param>
		/// <param name="zStart">z начала</param>
		/// <param name="xEnd">x конца (включительно)</param>
		/// <param name="yEnd">y конца (включительно)</param>
		/// <param name="zEnd">z конца (включительно)</param>
		/// <param name="blockId">id блока. 0 - стирает блоки</param>
		void SetBlockRange(int xStart, int yStart, int zStart, int xEnd, int yEnd, int zEnd, ushort blockId);
		/// <summary>
		/// возвращает ID блока в указанной точке
		/// </summary>
		/// <param name="x">координата x</param>
		/// <param name="y">координата y</param>
		/// <param name="z">координата z</param>
		/// <returns>ID блока или 0, если в точке пусто</returns>
		ushort GetBlockId(int x, int y, int z);
		/// <summary>
		/// возвращает ID блока в указанной точке
		/// </summary>
		/// <param name="index">индекс точки пространства</param>
		/// <returns>ID блока или 0, если в точке пусто</returns>
		ushort GetBlockId(Index index); 
	}
}