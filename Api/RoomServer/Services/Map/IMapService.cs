using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.DTO.Room.Map;

namespace PixelCombats.Api.RoomServer.Services.Map
{
	/// <summary>
	/// сервис работы с картой
	/// </summary>
	[ScriptObject("Map", ScriptModuleNames.ROOM_API)]
	public interface IMapService
	{
		/// <summary>
		/// возвращает метаданные текущей карты.
		/// при смене меты происходит перезагрузка комнаты
		/// </summary>
		MapMeta MapMeta { get; }
		/// <summary>
		/// ID текущей карты или 0, если ID карты не известен
		/// </summary>
		long MapId { get; }
		/// <summary>
		/// текущий список карт или 0, если список карт не задан
		/// </summary>
		long MapListId { get; }
		/// <summary>
		/// нужно ли менять карту, когда начинается новая игра
		/// <para>карта может быть изменена только на случайную, из списка стандартных карт</para>
		/// <para>по умолчанию <see cref="false"/></para>
		/// </summary>
		bool Rotation { get; set; }
		/// <summary>
		/// если это возможно, то включит случайную карту из текущего списка карт
		/// </summary>
		void LoadRandomMap();
		/// <summary>
		/// происходит, если загрузилась карта
		/// </summary>
		ApiEvent<IMapService> OnLoad { get; }
	}
}