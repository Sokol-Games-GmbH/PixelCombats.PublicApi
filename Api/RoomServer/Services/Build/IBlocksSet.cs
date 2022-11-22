namespace PixelCombats.Api.RoomServer.Services.Build
{
	/// <summary>
	/// набор блоков
	/// </summary>
	public interface IBlocksSet
	{
		/// <summary>
		/// идентиффикатор набора блоков
		/// </summary>
		int Id { get; }
		/// <summary>
		/// сколько всего блоков в наборе
		/// </summary>
		int Count { get; }
		/// <summary>
		/// проверяет наличие в наборе указанного блока
		/// </summary>
		/// <param name="id">ID блока</param>
		bool Contains(ushort id);
		/// <summary>
		/// возвращает блок по его индексу
		/// </summary>
		/// <param name="index">индекс блока</param>
		ushort GetByIndex(int index);
	}
}