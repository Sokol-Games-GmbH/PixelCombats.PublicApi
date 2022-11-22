using System.Collections.Generic;
using PixelCombats.Api.Basic;
using PixelCombats.Api.RoomServer.Basic;

namespace PixelCombats.Api.RoomServer.Services.Players
{
	/// <summary>
	/// сервис для работы с игроками
	/// </summary>
	[ScriptingRoot("Players")]
	public interface IPlayersService : IEnumerable<IPlayerApi>
	{
		/// <summary>
		/// количество игроков в комнате
		/// </summary>
		int Count { get; }
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