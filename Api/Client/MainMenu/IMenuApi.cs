using PixelCombats.Api.Basic;
using PixelCombats.Api.Client.MainMenu.Services.MenuItems;

namespace PixelCombats.Api.Client.MainMenu
{
	/// <summary> 
	/// API для работы с главным меню
	/// </summary>
	[ScriptingRoot("menu")]
	public interface IMenuApi
	{
		/// <summary>
		/// Определяет какие элементы меню включены, какие выключены
		/// </summary>
		IMenuItemsService ItemsService { get; }
	}
}