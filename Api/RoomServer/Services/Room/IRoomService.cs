using JavaScriptEngine.DataAnnotations;

namespace PixelCombats.Api.RoomServer.Services.Room
{
	/// <summary>
	/// сервис управления комнатой
	/// </summary>
	[ScriptObject("Room", ScriptModuleNames.ROOM_API)]
	public interface IRoomService
	{
		/// <summary>
		/// закрывает комнату
		/// <para>заставляет всех, кто есть в комнате выйти из нее</para>
		/// </summary>
		void Close();
	}
}