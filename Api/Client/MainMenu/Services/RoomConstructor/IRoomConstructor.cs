using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Basic;

namespace PixelCombats.Api.Client.MainMenu.Services.RoomConstructor
{
	/// <summary>
	/// конструктор комнат
	/// </summary>
	[ScriptObject("RoomConstructor", ScriptModuleNames.MAIN_MENU)]
	public interface IRoomConstructor
	{
		/// <summary>
		/// попытка создать комнату
		/// </summary>
		/// <param name="parameters">параметры моздания комнаты</param>
		void TryCreateRoom(RoomCreationParameters parameters);

		/// <summary>
		/// 
		/// </summary>
		ApiEvent<RoomCreationParameters, IRoomConstructor> OnRoomCreated { get; }
	}
}