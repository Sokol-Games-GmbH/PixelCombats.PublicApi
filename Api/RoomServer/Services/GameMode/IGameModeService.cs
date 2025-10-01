using JavaScriptEngine.DataAnnotations;
using PixelCombats.DTO.Room.GameMode;

namespace PixelCombats.Api.RoomServer.Services.GameMode
{
	/// <summary>
	/// хранит значения параметров игрового режима
	/// </summary>
	[ScriptObject("GameMode", ScriptModuleNames.ROOM_API)]
	public interface IGameModeService
	{
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