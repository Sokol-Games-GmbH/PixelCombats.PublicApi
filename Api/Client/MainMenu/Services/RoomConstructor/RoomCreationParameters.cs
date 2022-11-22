using PixelCombats.Domain.DTO.Room.GameMode;
using PixelCombats.Domain.DTO.Room.Map;
using PixelCombats.Domain.DTO.Room.MapLists;

namespace PixelCombats.Api.Client.MainMenu.Services.RoomConstructor
{
	/// <summary>
	/// параметры создания комнаты
	/// </summary>
	public sealed class RoomCreationParameters
	{
		/// <summary>
		/// имя комнаты
		/// </summary>
		public string RoomName;
		/// <summary>
		/// пароль в комнате
		/// </summary>
		public string Password;
		/// <summary>
		/// макс игроков
		/// </summary>
		public byte MaxPlayers;
		/// <summary>
		/// источник игровго режима
		/// </summary>
		public GameModeMeta GameMode;
		/// <summary>
		/// источник карты
		/// <para>карта, для воспроизведения в комнате в момент ее создания</para>
		/// </summary>
		public MapMeta Map;
		/// <summary>
		/// ID списка карт
		/// </summary>
		public long? MapListId;
		/// <summary>
		/// тип источника списков карт
		/// </summary>
		public MapListSourceTypes MapListSourceType;

		/// <summary>
		/// параметры, для передачи в игровой режим
		/// </summary>
		public GameModeParametersValues Addition;

		/// <summary>
		/// если истина, то карта кастомная
		/// </summary>
		public bool IsCustomMap =>
			Map is { SourceType: MapSourceTypes.LocalFile or MapSourceTypes.RoomData };
	}
}