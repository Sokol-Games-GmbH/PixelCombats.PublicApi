using PixelCombats.Api.Basic;
using PixelCombats.Api.RoomServer.Basic;

namespace PixelCombats.Api.Client.MainMenu.Services.RoomConstructor
{
	/// <summary>
	/// конструктор комнат
	/// </summary>
	[ScriptingRoot("RoomConstructor")]
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