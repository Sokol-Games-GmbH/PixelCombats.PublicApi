using JavaScriptEngine.DataAnnotations;

namespace PixelCombats.Api.RoomServer.Services.Analytics
{
	[ScriptAllowed]
	[ScriptType("AnalyticsParameter", ScriptModuleNames.BASIC)]
	public class AnalyticsParameter
	{
		public enum Types
		{
			STRING = 1,
			LONG,
			DOUBLE
		}

		public readonly string Name;
		public Types Type;
		public object Value;

		public AnalyticsParameter(string name, string value)
		{
			this.Name = name;
			this.Value = value;
			this.Type = Types.STRING;
		}
		public AnalyticsParameter(string name, long value)
		{
			this.Name = name;
			this.Value = value;
			this.Type = Types.LONG;
		}
		public AnalyticsParameter(string name, double value)
		{
			this.Name = name;
			this.Value = value;
			this.Type = Types.DOUBLE;
		}
	}
}