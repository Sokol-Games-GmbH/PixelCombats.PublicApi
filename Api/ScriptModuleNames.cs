namespace PixelCombats.Api
{
	/// <summary>
	/// имена модулей апи
	/// </summary>
	public static class ScriptModuleNames
	{
		/// <summary>
		/// модуль базового функционала, доступен из любого контекста
		/// </summary>
		public const string BASIC = "pixel_combats/basic";
		/// <summary>
		/// модуль комнатного апи
		/// </summary>
		public const string ROOM_API = "pixel_combats/room";
		/// <summary>
		/// апи главного меню
		/// </summary>
		public const string MAIN_MENU = "pixel_combats/mainmenu";
		/// <summary>
		/// дебаг
		/// </summary>
		public const string DEBUG = "pixel_combats/debug";

		/// <summary>
		/// библиотека типов данных для голосования о новых играх
		/// </summary>
		public const string NEW_GAME_VOTE_TYPES = "pixel_combats/types/new_game_vote";
	}
}