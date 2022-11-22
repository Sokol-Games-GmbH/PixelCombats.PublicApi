using System.IO;
using PixelCombats.Domain.DTO;

namespace PixelCombats.Api.Basic.Structures
{
	/// <summary>
	/// ставит фильтр в соответствие потоку с файлом карт
	/// </summary>
	public interface IMapFilterStreamAnalyzer
	{
		/// <summary>
		/// ставит фильтр в соответствие потоку с картой
		/// </summary>
		/// <param name="filter">изменяемый фильтр карты</param>
		/// <param name="stream">поток карты</param>
		void Apply(ref MapFilter filter, Stream stream);
	}
}