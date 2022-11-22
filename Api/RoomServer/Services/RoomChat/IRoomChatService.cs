using PixelCombats.Api.RoomServer.Basic;

namespace PixelCombats.Api.RoomServer.Services.RoomChat
{
	/// <summary>
	/// внутрикомнатный чат
	/// </summary>
	public interface IRoomChatService
	{
		/// <summary>
		/// отправляет сообщение в чат комнаты
		/// </summary>
		void SendMessage(string text);

		/// <summary>
		/// если в чате возникает сообщение
		/// </summary>
		ApiEvent<RoomMessageReceivedData, IRoomChatService> OnMessage { get; }
	}
}