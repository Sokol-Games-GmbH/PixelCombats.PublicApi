using System.Collections.Generic;
using PixelCombats.Api.RoomServer.Basic;

namespace PixelCombats.Api.RoomServer.Services.Spawn
{
	/// <summary>
	/// набор индексов групп спавнпоинтов
	/// <para>используется для привязки определенных групп спавнпоинтов</para>
	/// </summary>
	public interface ISpawnPointsGroupIndexSet : IEnumerable<uint>
	{
		/// <summary>
		/// количество групп спавнпоинтов
		/// </summary>
		int Count { get; }
		/// <summary>
		/// добавляет элемент в группу
		/// </summary>
		/// <param name="index">добавляемый элемент</param>
		void Add(uint index);
		/// <summary>
		/// удаляет элемент из группы
		/// </summary>
		/// <param name="index">значение</param>
		void Remove(uint index);
		/// <summary>
		/// производит очистку всего набора
		/// </summary>
		void Clear();
		/// <summary>
		/// проверяет наличие индекса в наборе
		/// </summary>
		/// <param name="index"></param>
		bool Contains(uint index);
		/// <summary>
		/// возвращает случайный индекс из набора
		/// <para>если набор индексов пуст, то возвращает 0</para>
		/// </summary>
		uint Random();

		/// <summary>
		/// если добавлился индекс группы спавнпоинтов
		/// </summary>
		ApiEvent<uint> OnAdd { get; }
		/// <summary>
		/// если удалился индекс группы спавнпоинтов
		/// </summary>
		ApiEvent<uint> OnRemove { get; }
	}
}