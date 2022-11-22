using PixelCombats.Api.RoomServer.Basic;
using System.Collections.Generic;
using PixelCombats.Domain.DTO.Room.GameMode;

namespace PixelCombats.Api.Client
{
	/// <summary>
	/// сервис источников игровых режимов
	/// </summary>
	public interface IGameModesSource : IEnumerable<GameModeMeta>
	{
		/// <summary>
		/// количество игровых режимов
		/// </summary>
		int Count { get; }

		/// <summary>
		/// возвращает игровой режим по его имени
		/// </summary>
		/// <param name="name">имя игрового режима</param>
		GameModeMeta Get(string name);

		/// <summary>
		/// обновился источник игровых режимов
		/// </summary>
		ApiEvent<IGameModesSource> OnUpdate { get; }
	}
}