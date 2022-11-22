using PixelCombats.Api.RoomServer.Services.Players;

namespace PixelCombats.Api.RoomServer.Interfaces
{
	/// <summary>
	/// контекст игрока
	/// </summary>
	public interface IPlayerContext
	{
		/// <summary>
		/// игрок
		/// </summary>
		IPlayerApi Player { get; }
	}
}