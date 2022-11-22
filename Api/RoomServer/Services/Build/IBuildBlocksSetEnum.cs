using PixelCombats.Api.Basic;

namespace PixelCombats.Api.RoomServer.Services.Build
{
	/// <summary>
	/// набор всех пресетов наборов блоков
	/// </summary>
	[ScriptingRoot("BuildBlocksSet")]
	public interface IBuildBlocksSetEnum
	{
		/// <summary>
		/// пустой набор блоков
		/// </summary>
		IBlocksSet NullSet { get; }
		/// <summary>
		/// набор всех блоков
		/// </summary>
		IBlocksSet All { get; }
		/// <summary>
		/// набор всех чистых блоков (которые не сломанные)
		/// </summary>
		IBlocksSet AllClear { get; }
		/// <summary>
		/// набор блоков для красной команды
		/// </summary>
		IBlocksSet Blue { get; }
		/// <summary>
		/// набор блоков для синей команды
		/// </summary>
		IBlocksSet Red { get; }

		/// <summary>
		/// возвращает набор блоков по его ID
		/// <para>если набора с указанным ID не существует то выдаст пустой набор</para>
		/// </summary>
		/// <param name="id">ID набора блоков</param>
		IBlocksSet Get(int id);
	}
}