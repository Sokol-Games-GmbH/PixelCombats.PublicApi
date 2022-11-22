using System.Collections.Generic;
using PixelCombats.Api.Basic;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Services.LeaderBoard;
using PixelCombats.Api.RoomServer.Services.Players;
using PixelCombats.Api.RoomServer.Services.Teams;

namespace PixelCombats.Api.RoomServer.Services.Game
{
	/// <summary>
	/// сервис конца матча
	/// </summary>
	[ScriptingRoot("Game")]
	public interface IGameService
	{
		/// <summary>
		/// если истина, то игра окончена
		/// </summary>
		bool IsGameOver { get; }

		/// <summary>
		/// перезапускает игру в комнате
		/// </summary>
		void RestartGame();
		/// <summary>
		/// завершает игру
		/// </summary>
		/// <param name="winner">команда - победитель</param>
		void GameOver(ITeamApi winner);
		/// <summary>
		/// завершает игру
		/// </summary>
		/// <param name="winner">игрок - победитель</param>
		void GameOver(IPlayerApi winner);
		/// <summary>
		/// завершает игру
		/// </summary>
		/// <param name="teamsLeaderBoard">лидерборд команд</param>
		void GameOver(IList<LeaderBoardTeamItem> teamsLeaderBoard);
		/// <summary>
		/// завершает игру
		/// </summary>
		/// <param name="playersLeaderBoard">лидерборд игроков</param>
		void GameOver(IList<LeaderBoardPlayerItem> playersLeaderBoard);

		/// <summary>
		/// игра окончена (происходит всегда перед событием победы игроков или команд)
		/// </summary>
		ApiEvent<IGameService> OnGameOver { get; }
		/// <summary>
		/// игра окончена и выиграла команда или ничья, если в списке больше одного элемента, победу разделили все кто в списке
		/// </summary>
		ApiEvent<IList<ITeamApi>, IGameService> OnTeamsWin { get; }
		/// <summary>
		/// игра окончена и выиграл игрок или ничья, если в списке больше одного элемента, победу разделили все кто в списке
		/// </summary>
		ApiEvent<IList<IPlayerApi>, IGameService> OnPlayersWin { get; }
	}
}