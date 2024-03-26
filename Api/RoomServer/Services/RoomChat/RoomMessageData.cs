using JavaScriptEngine.DataAnnotations;

namespace PixelCombats.Api.RoomServer.Services.RoomChat
{
	/// <summary>
	/// входящее сообщение внутри комнаты
	/// </summary>
	[ScriptAllowed]
	public struct RoomMessageData
	{
		/// <summary>
		/// имя пользователя или null, если отправитель сервер
		/// </summary>
		public string NickName;
		/// <summary>
		/// текст сообщения
		/// </summary>
		public string Text;
		/// <summary>
		/// id отправителя в комнате, или 0, если отправитель сервер
		/// </summary>
		public int Sender;
		/// <summary>
		/// id команды отправителя в момент отправки сообщения или null
		/// </summary>
		public string TeamId;
	}
}