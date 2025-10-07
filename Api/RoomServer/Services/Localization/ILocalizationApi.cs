using JavaScriptEngine.DataAnnotations;

namespace PixelCombats.Api.RoomServer.Services.Localization
{
	/// <summary>
	/// локализация для скриптов режима (ROOM_API)
	/// </summary>
	[ScriptObject("Localization", ScriptModuleNames.ROOM_API)]
	public interface ILocalizationApi
	{
		/// <summary>
		/// перевод термина на текущий язык
		/// </summary>
		/// <param name="term">ключ</param>
		string T(string term);

		/// <summary>
		/// текущий язык
		/// </summary>
		string CurrentLanguage { get; }
	}
}
