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
	}
}