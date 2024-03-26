namespace PixelCombats.Api.RoomServer.Services.RoomChat
{
	public static class RoomChatMessageExtensions
	{
		/// <summary>
		/// истина, если отправитель - сервер
		/// <see cref="RoomMessageData.Sender"/>==0
		/// </summary>
		public static bool IsServerMsg(this RoomMessageData data)
		{
			return data.Sender == 0;
		}
	}
}