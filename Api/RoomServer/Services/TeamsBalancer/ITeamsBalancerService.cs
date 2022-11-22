using PixelCombats.Api.Basic;
using PixelCombats.Api.RoomServer.Basic;

namespace PixelCombats.Api.RoomServer.Services.TeamsBalancer
{
	/// <summary>
	/// Определяет баланс команд в игре
	/// </summary>
	[ScriptingRoot("TeamsBalancer")]
	public interface ITeamsBalancerService
	{
		/// <summary>
		/// если true то будет всегда балансировать автоматически
		/// </summary>
		bool IsAutoBalance { get; set; }
		/// <summary>
		/// максимальная разница игроков.
		/// <para>по умолчанию 1 и если 0 то не работает</para>
		/// </summary>
		uint MaxPlayerDifference { get; set; }
		/// <summary>
		/// производит баланс команд
		/// </summary>
		void BalanceTeams();

		/// <summary>
		/// сменился флаг автобаланса
		/// </summary>
		ApiEvent<ITeamsBalancerService> OnIsAutoBalance { get; }
		/// <summary>
		/// если изменилась максимальная разница в командах
		/// </summary>
		ApiEvent<ITeamsBalancerService> OnMaxPlayerDifference { get; }
		/// <summary>
		/// после балансировки команд
		/// </summary>
		ApiEvent<ITeamsBalancerService> OnBalanceTeams { get; }
	}
}