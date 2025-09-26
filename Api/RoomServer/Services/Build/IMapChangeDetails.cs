using PixelCombats.Api.RoomServer.Services.Players;
using System.Collections.Generic;
using PixelCombats.Api.Basic;

namespace PixelCombats.Api.RoomServer.Services.Build
{
	/// <summary>
	/// Данные о редактировании блока на карте
	/// </summary>
	public interface IMapChangeDetails
	{
		/// <summary>
		/// Игрок, который выполнил редактирование
		/// </summary>
		IPlayerApi Player { get; }
		
		/// <summary>
		/// Изменение на карте (область изменения)
		/// </summary>
		IMapChange MapChange { get; }
		
		/// <summary>
		/// Список того, что было на карте до изменения
		/// </summary>
		IList<IMapChange> OldMapData { get; }
	}
}

