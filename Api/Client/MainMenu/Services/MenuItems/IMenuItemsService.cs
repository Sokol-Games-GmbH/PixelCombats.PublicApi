using System;
using PixelCombats.Api.Basic.Structures.Math;

namespace PixelCombats.Api.Client.MainMenu.Services.MenuItems
{
	/// <summary>  Определяет, какие элементы в меню включить а какие выключить</summary>
	public interface IMenuItemsService
	{
		/// <summary>
		/// феерверки на заднем плане
		/// </summary>
		bool Fireworks { get; set; }
		/// <summary>
		/// Новогодняя елка
		/// </summary>
		bool CristmasTree { get; set; }
		/// <summary>
		/// делает небо определенного цвета
		/// </summary>
		Color SkyColor { get; set; }

		event Action<IMenuItemsService> OnFireworks;
		event Action<IMenuItemsService> OnCristmassTree;
		event Action<IMenuItemsService> OnSkyColor;
	}
}
