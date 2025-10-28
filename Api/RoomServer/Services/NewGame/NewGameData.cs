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
		/// <summary>
		/// id списка карт или 0, если список оставить тотже
		/// </summary>
		[SerializeMember(2)]
		public long MapListId;
	}
}