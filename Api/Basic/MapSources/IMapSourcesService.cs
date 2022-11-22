using System.Collections.Generic;
using PixelCombats.Domain.DTO.Room.Map;

namespace PixelCombats.Api.Basic.MapSources
{
	/// <summary>
	/// сервис источников карт
	/// </summary>
	public interface IMapSourcesService // todo переделать, разбив на 2 интерфейса локальные и удаленные и оба вложив в общий интерфейс сервиса источников карт
	{
		/// <summary>
		/// все возможные источники карт (дефолтные карты и заготовки для строительства вместе)
		/// </summary>
		List<MapMeta> AllMapSources { get; }
	}
}