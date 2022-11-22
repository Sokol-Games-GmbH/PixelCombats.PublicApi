using PixelCombats.Api.RoomServer.Interfaces;
using PixelCombats.Api.RoomServer.Services.Players;

namespace PixelCombats.Api.RoomServer.Services.LeaderBoard
{
	/// <summary>
	/// элемент лидерборда для игроков
	/// </summary>
	public struct LeaderBoardPlayerItem: IPlayerContext
	{
		/// <summary>
		/// игрок
		/// </summary>
		public IPlayerApi Player { get; set; }
		/// <summary>
		/// какой вес у игрока в лидерборде
		/// </summary>
		public int Weight;
	}
}