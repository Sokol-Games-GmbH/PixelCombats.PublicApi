using PixelCombats.Api.Basic;
using PixelCombats.DTO.Room.GameMode;

namespace PixelCombats.Api.RoomServer.Services.GameMode
{
	/// <summary>
	/// хранит значения параметров игрового режима
	/// </summary>
	[ScriptingRoot("GameMode")]
	public interface IGameModeService
	{
		/// <summary>
		/// скрипт игрового режима
		/// </summary>
		string Script { get; }
		/// <summary>
		/// текущий игровой режим
		/// </summary>
		GameModeMeta Value { get; }
		/// <summary>
		/// значения параметров
		/// </summary>
		GameModeParametersValues Parameters { get; }
	}
}