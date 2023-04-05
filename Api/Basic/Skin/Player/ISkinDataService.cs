using PixelCombats.Api.RoomServer.Services.DefaultPropertiesContexted;

namespace PixelCombats.Api.Basic.Skin.Player
{
	/// <summary>
	/// данные по скинам
	/// </summary>
	/// todo это дело упразднить после того, как сделаем отработку цветов команды на скинах
	public interface ISkinDataService
	{
		/// <summary>
		/// возвращает технический скин для синих
		/// </summary>
		/// <param name="skinId">id скина</param>
		int GetTechnicalForBlue(int skinId);
		/// <summary>
		/// возвращает технический скин для красных
		/// </summary>
		/// <param name="skinId">id скина</param>
		int GetTechnicalForRed(int skinId);
		/// <summary>
		/// возвращает технический ID скина для указанного типа
		/// </summary>
		/// <param name="skinId">id скина</param>
		/// <param name="skinType">тип скина</param>
		/// <returns></returns>
		int GetTechnicalFor(int skinId, SkinTypes skinType);
	}
}