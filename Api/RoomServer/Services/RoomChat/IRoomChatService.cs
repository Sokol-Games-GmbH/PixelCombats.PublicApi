using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Basic;

namespace PixelCombats.Api.RoomServer.Services.RoomChat
{
	/// <summary>
	/// внутрикомнатный чат
	/// </summary>
	[ScriptObject("Chat", ScriptModuleNames.ROOM_API)]
	public interface IRoomChatService
	{
		/// <summary>
		/// отправляет сообщение в чат комнаты
		/// </summary>
		void SendMessage(string text);
		/// <summary>
		/// возвращает все сообщения в чате
		/// </summary>
		RoomMessageData[] GetAllMessages();

		/// <summary>
		/// если в чате возникает сообщение
		/// </summary>
		ApiEvent<RoomMessageData, IRoomChatService> OnMessage { get; }
	}
}