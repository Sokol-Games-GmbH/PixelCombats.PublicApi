using PixelCombats.Api.RoomServer.Services.Players;

namespace PixelCombats.Api.RoomServer.Services.RoomChat
{
	/// <summary>
	/// входящее сообщение внутри комнаты
	/// </summary>
	public struct RoomMessageReceivedData
	{
		/// <summary>
		/// текст сообщения
		/// </summary>
		public string Text;
		/// <summary>
		/// отправитель, может быть NULL (восновном, если отправитель сервер)
		/// </summary>
		public IPlayerApi Sender;
		/// <summary>
		/// если истина, то отправителем сообщения является сервер
		/// </summary>
		public bool IsServerMsg;
	}
}