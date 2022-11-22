using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Services.Players;

namespace PixelCombats.Api.Basic.Skin.Player
{
	/// <summary>
	/// отвечает за скины игроков
	/// </summary>
	public interface IPlayersSkinService
	{
		/// <summary>
		/// ID локального скина
		/// </summary>
		int LocalSkinId { get; set; }

		/// <summary>
		/// возвращает ID скина указанного игрока
		/// </summary>
		/// <param name="player">игрок</param>
		int GetPlayerSkinId(IPlayerApi player);

		/// <summary>
		/// при смене ID скина
		/// id скина, playerActorNr, сервис
		/// </summary>
		ApiEvent<int, int, IPlayersSkinService> OnPlayerSkin { get; }
	}
}