using PixelCombats.Api.Basic;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.DTO.Room.Map;

namespace PixelCombats.Api.RoomServer.Services.Map
{
	/// <summary>
	/// сервис работы с картой
	/// </summary>
	[ScriptingRoot("Map")]
	public interface IMapService
	{
        /// <summary>
        /// возвращает метаданные текущей карты.
        /// при смене меты происходит перезагрузка комнаты
        /// </summary>
        MapMeta MapMeta { get; }
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