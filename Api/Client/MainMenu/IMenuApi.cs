using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.Client.MainMenu.Services.MenuItems;

namespace PixelCombats.Api.Client.MainMenu
{
	/// <summary> 
	/// API для работы с главным меню
	/// </summary>
	[ScriptObject("menu", ScriptModuleNames.MAIN_MENU)]
	public interface IMenuApi
	{
		/// <summary>
		/// Определяет какие элементы меню включены, какие выключены
		/// </summary>
		IMenuItemsService ItemsService { get; }
	}
}