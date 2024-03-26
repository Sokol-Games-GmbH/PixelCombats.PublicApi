using JavaScriptEngine.DataAnnotations;

namespace PixelCombats.Api.RoomServer.Services.NewGame
{
	/// <summary>
	/// сервис управления новой игрой
	/// </summary>
	[ScriptObject("NewGame", ScriptModuleNames.ROOM_API)]
	public interface INewGameService
	{
		/// <summary>
		/// стандартный перезапуск игры
		/// </summary>
		void RestartGame();
		/// <summary>
		/// перезапуск игры с указанными параметрами новой игры
		/// </summary>
		/// <param name="data">данные о запуске новой игры</param>
		void RestartGame(NewGameData data);
	}
}