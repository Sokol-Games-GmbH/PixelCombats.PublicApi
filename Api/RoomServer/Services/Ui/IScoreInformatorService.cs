using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Services.Players;

namespace PixelCombats.Api.RoomServer.Services.Ui
{
	/// <summary>
	/// сервис информирования игрока об очках (мерит уведомления)
	/// </summary>
	[ScriptObject("ScoreInfo", ScriptModuleNames.ROOM_API)]
	public interface IScoreInformatorService
	{
		/// <summary>
		/// отображает уведомление с очками указанному игроку
		/// </summary>
		/// <param name="player">кому показать</param>
		/// <param name="message">что показать (параметры сообщения)</param>
		void Show(IPlayerApi player, ScoreInformMessage message);
	}
}


