using PixelCombats.Api.RoomServer.Services.Players;
using System.Collections.Generic;
using PixelCombats.Api.Basic;

namespace PixelCombats.Api.RoomServer.Services.Build
{
	/// <summary>
	/// Данные о редактировании блока
	/// </summary>
	public interface IBlockEditData
	{
		/// <summary>
		/// Игрок, который выполнил редактирование
		/// </summary>
		IPlayerApi Player { get; }
		
		/// <summary>
		/// Изменение блоков - общее изменение
		/// </summary>
		IMapChange MapChange { get; }
		
		/// <summary>
		/// Список измененных блоков (для детального отслеживания)
		/// </summary>
		IReadOnlyList<IMapChange> BlockChanges { get; }
	}
}

