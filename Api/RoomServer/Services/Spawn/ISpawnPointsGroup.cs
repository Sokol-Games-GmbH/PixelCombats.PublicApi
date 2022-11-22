using System.Collections.Generic;
using PixelCombats.Api.Basic.Structures.Math;
using PixelCombats.Api.RoomServer.Basic;

namespace PixelCombats.Api.RoomServer.Services.Spawn
{
	/// <summary>
	/// данные обо всех спавнпоинтах
	/// </summary>
	public interface ISpawnPointsGroup : IEnumerable<SpawnPoint>
	{
		/// <summary>
		/// ID группы спавнпоинтов
		/// </summary>
		uint Id { get; }
		/// <summary>
		/// количество спавнпоинтов в группе
		/// </summary>
		int Count { get; }

		/// <summary>
		/// возвращает случайный спавнпоинт из группы спавнпоинтов
		/// </summary>
		/// <returns></returns>
		SpawnPoint GetRandomSpawnpoint();
		/// <summary>
		/// добавляет спавнпоинт в группу
		/// <para>если спавнпоинт с такой позицией уже сужествует то спавнпоинт будет заменен</para>
		/// </summary>
		/// <param name="spawnPoint">спавнпоинт</param>
		void Add(SpawnPoint spawnPoint);
		/// <summary>
		/// добавляет спавнпоинт в группу
		/// <para>если спавнпоинт с такой позицией уже сужествует то спавнпоинт будет заменен</para>
		/// </summary>
		/// <param name="x">позиция x</param>
		/// <param name="y">позиция y</param>
		/// <param name="z">позиция z</param>
		/// <param name="angle">угол просмотра</param>
		void Add(int x, int y, int z, float angle);
		/// <summary>
		/// удаляет спавнпоинт по его позиции
		/// </summary>
		/// <param name="index">позиция удаляемого спавнпоинта</param>
		void Remove(Index position);
		/// <summary>
		/// удаляет спавнпоинт по его позиции
		/// </summary>
		/// <param name="x">позиция x</param>
		/// <param name="y">позиция y</param>
		/// <param name="z">позиция z</param>
		void Remove(int x, int y, int z);
		/// <summary>
		/// удаляет все спавнпоинты из группы
		/// </summary>
		void Clear();

		/// <summary>
		/// если добавился спавнпоинт
		/// </summary>
		ApiEvent<SpawnPoint> OnAdd { get; }
		/// <summary>
		/// если удалился спавнпоинт
		/// </summary>
		ApiEvent<SpawnPoint> OnRemove { get; }
	}
}