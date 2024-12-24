using JavaScriptEngine.DataAnnotations;

namespace PixelCombats.Api.RoomServer.Services.Analytics
{
	/// <summary>
	/// аналитика игрового режима
	/// </summary>
	[ScriptObject("Analytics", ScriptModuleNames.ROOM_API)]
	public interface IAnalyticsService
	{
		/// <summary>
		/// отправляет аналитический эвент
		/// </summary>
		/// <param name="eventName">имя эвента</param>
		/// <param name="parameters">параметры</param>
		void LogEvent(string eventName, params AnalyticsParameter[] parameters);
	}
}