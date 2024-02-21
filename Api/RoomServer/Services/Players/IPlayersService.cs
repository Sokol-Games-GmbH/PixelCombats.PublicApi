using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Basic;
using System.Collections.Generic;

namespace PixelCombats.Api.RoomServer.Services.Players
{
	/// <summary>
	/// сервис для работы с игроками
	/// </summary>
	[ScriptObject("Players", ScriptModuleNames.ROOM_API)]
	public interface IPlayersService : IEnumerable<IPlayerApi>
	{
		/// <summary>
		/// количество игроков в комнате
		/// </summary>
		int Count { get; }
		/// <summary>
		/// возвращает всех игроков в комнате
		/// <para>Не рекомендуется использовать каждый раз в цикле. Выностие за цикл</para>
		/// </summary>
		IPlayerApi[] All { get; }
		/// <summary>
		/// максимум игроков в комнате
		/// </summary>
		int MaxCount { get; }

		/// <summary>
		/// возвращает объект, для работы с игроком или null
		/// </summary>
		/// <param name="playerId">ID игрока</param>
		IPlayerApi Get(string playerId);
		/// <summary>
		/// позволяет получить игрока по его внутрикомнатному ID
		/// <para>работает быстрее чем получение по обычному ID игрока, однако внутрикомнатный ID всегда разный</para>
		/// </summary>
		/// <param name="roomId">внутрикомнатный ID</param>
		IPlayerApi GetByRoomId(int roomId);

		/// <summary>
		/// если подключился игрок
		/// </summary>
		ApiEvent<IPlayerApi, IPlayersService> OnPlayerConnected { get; }
		/// <summary>
		/// если игрок отключился
		/// </summary>
		ApiEvent<IPlayerApi, IPlayersService> OnPlayerDisconnected { get; }
	}
}