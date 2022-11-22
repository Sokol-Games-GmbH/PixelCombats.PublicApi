using System.Collections.Generic;

namespace PixelCombats.Api.RoomServer.Services.Areas
{
	/// <summary>
	/// набор тэгов
	/// </summary>
	public interface ITagsSet : IEnumerable<string>
	{
		/// <summary>
		/// общее количество тэгов
		/// </summary>
		int Count { get; }
		/// <summary>
		/// добавляет тэг
		/// </summary>
		/// <param name="tag">тэг</param>
		bool Add(string tag);
		/// <summary>
		/// удаляет тэг
		/// </summary>
		/// <param name="tag">тэг</param>
		bool Remove(string tag);
		/// <summary>
		/// проверяет наличие указанного тэга
		/// </summary>
		/// <param name="tag">тэг</param>
		bool Contains(string tag);
		/// <summary>
		/// удаляет все тэги
		/// </summary>
		void Clear();
	}
}