using System.Collections.Generic;

namespace PixelCombats.Api.RoomServer.Services.Ui
{
	/// <summary>
	/// Расширения для работы с набором (кэшем) сообщений об очках.
	/// </summary>
    public static class ScoreInformMessageExtensions
	{
		/// <summary>
		/// Проверяет, можно ли объединить два сообщения: совпадает ключ без учёта очков,
		/// и при этом сообщения НЕ являются убийствами (Kill не мержится).
		/// </summary>
		/// <param name="left">Первое сообщение.</param>
		/// <param name="right">Второе сообщение.</param>
		/// <returns>True, если сообщения можно слить (merge), иначе false.</returns>
		public static bool CanMerge(this ScoreInformMessage left, ScoreInformMessage right)
		{
			// Сравниваем только существенные для объединения поля
			if (left == null || right == null) return false;
			// Убийства не мержатся
			if (left.Type == ScoreInformType.Kill || right.Type == ScoreInformType.Kill) return false;
			return left.Type == right.Type
				&& left.WeaponId == right.WeaponId
				&& left.IsHeadshot == right.IsHeadshot;
		}

		/// <summary>
		/// Возвращает элемент из набора, с которым можно выполнить merge,
		/// либо null, если подходящего не найдено. Для Kill всегда null.
		/// </summary>
		public static ScoreInformMessage FindMergeTarget(this IEnumerable<ScoreInformMessage> source, ScoreInformMessage candidate)
		{
			if (source == null || candidate == null) return null;
			if (candidate.Type == ScoreInformType.Kill) return null;
			foreach (var item in source) {
				if (item.CanMerge(candidate)) return item;
			}
			return null;
		}

		/// <summary>
		/// Добавляет сообщение в очередь-кэш. Если в кэше уже есть элемент
		/// с тем же ключом (совпадает всё, кроме очков), то к найденному элементу
		/// прибавляются очки добавляемого элемента, а новый элемент не добавляется.
		/// </summary>
        /// <param name="cache">Очередь-кэш сообщений.</param>
        /// <param name="candidate">Добавляемое сообщение.</param>
        public static void AddOrMerge(this IList<ScoreInformMessage> cache, ScoreInformMessage candidate)
		{
			// Защита от некорректных параметров
			if (cache == null || candidate == null) return;

			// Убийства не мержатся — кладём сразу
            if (candidate.Type == ScoreInformType.Kill) { cache.Add(candidate); return; }

			var target = cache.FindMergeTarget(candidate);
			if (target != null) { 
                target.Scores += candidate.Scores; 
                return; 
            }

			// Совпадений не было — обычная постановка в очередь
            cache.Add(candidate);
		}

        /// <summary>
        /// Перегрузка для очереди без приведения типов.
        /// </summary>
        public static void AddOrMerge(this Queue<ScoreInformMessage> cache, ScoreInformMessage candidate)
        {
            if (cache == null || candidate == null) return;
            if (candidate.Type == ScoreInformType.Kill) { cache.Enqueue(candidate); return; }
            var target = cache.FindMergeTarget(candidate);
            if (target != null) { 
                target.Scores += candidate.Scores; 
                return; 
            }
            cache.Enqueue(candidate);
        }
	}
}


