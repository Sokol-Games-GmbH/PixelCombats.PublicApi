using System.Threading;
using System.Threading.Tasks;
using PixelCombats.DTO.Room.Map;

namespace PixelCombats.Api.Client.Maps
{
	/// <summary>
	/// производит доступ к байтам данных карт с разных источников
	/// </summary>
	public interface IMapByMetaDownloader
	{
		/// <summary>
		/// производит загрузку карты с указанной метой и возвращает поток данных этой карты
		/// </summary>
		/// <param name="mapMeta">мета карты</param>
		/// <param name="ct">токен отмены</param>
		Task<byte[]> DownloadMapAsync(MapMeta mapMeta, CancellationToken ct);
	}
}