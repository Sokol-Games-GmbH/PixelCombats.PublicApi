using System;
using JavaScriptEngine.DataAnnotations;
using PixelCombats.Annotation;

namespace PixelCombats.Api.RoomServer.Services.NewGame
{
	/// <summary>
	/// вариант новой игры
	/// <para>может применяться, для запуска новой игры</para>
	/// </summary>
	[ScriptType("NewGameData", ScriptModuleNames.ROOM_API)]
	[ScriptAllowed]
	[Serializable]
	public class NewGameData
	{
		/// <summary>
		/// id карты или 0, если карту оставить туже
		/// </summary>
		[SerializeMember(1)]
		public long MapId;

		public NewGameData(long MapId)
		{
	            if (MapId >= 0)
                        this.MapId = MapId;
		}
	}
}
