using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Basic;
using System.Threading;
using System.Threading.Tasks;

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
		/// <param name="ct">токен завершения</param>
		Task<bool> TryCreateRoom(RoomCreationParameters parameters, CancellationToken ct = new());

		/// <summary>
		/// 
		/// </summary>
		ApiEvent<RoomCreationParameters, IRoomConstructor> OnRoomCreated { get; }
	}
}