using System.Threading;
using System.Threading.Tasks;

namespace PixelCombats.Api.Client.Room
{
	/// <summary>
	/// интерфейс сервиса сохранения исходника карты на сервере
	/// </summary>
	public interface ISaveMapOnServerService
	{
		/// <summary>
		/// сохраняет исходник карты на сервере
		/// </summary>
		Task<uint> SaveMapSourceOnServer(CancellationToken ct);
		/// <summary>
		/// запрос на загрузку карты по ее id. работает только если один в комнате
		/// </summary>
		/// <param name="mapId">id карты</param>
		void RequestLoadMap(uint mapId);
	}
}