using PixelCombats.Annotation;
using System;
using JavaScriptEngine.DataAnnotations;

namespace PixelCombats.Api.RoomServer.Services.LeaderBoard
{
	/// <summary>
	/// описатель значения
	/// </summary>
	[Serializable]
	[ScriptAllowed]
	[ScriptType("DisplayValueHeader", ScriptModuleNames.BASIC)]
	public class DisplayValueHeader
	{
		/// <summary>
		/// имя значения
		/// </summary>
		[SerializeMember(1)]
		public string Value;
		/// <summary>
		/// выводимый заголовок (если <see cref="null"/> тогда <see cref="Value"/>)
		/// </summary>
		[SerializeMember(2)]
		public string DisplayName;
		/// <summary>
		/// сокращенное выводимое значение (если <see cref="null"/> тогда <see cref="DisplayName"/>)
		/// </summary>
		[SerializeMember(3)]
		public string ShortDisplayName;

		public DisplayValueHeader() { }
		public DisplayValueHeader(string value, string displayName, string shortDisplayName)
		{
			Value = value;
			DisplayName = displayName;
			ShortDisplayName = shortDisplayName;
		}
	}
}