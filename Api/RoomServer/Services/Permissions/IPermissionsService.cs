using JavaScriptEngine.DataAnnotations;

namespace PixelCombats.Api.RoomServer.Services.Permissions
{
	/// <summary>
	/// структура разрешений в комнате
	/// </summary>
	public struct RoomPermissions
	{
		/// <summary>
		/// можно ли закрывать комнату
		/// </summary>
		public bool CloseRoom { get; set; }

		/// <summary>
		/// разрешения в комнате по умолчанию
		/// </summary>
		public static RoomPermissions Default => new() {
			CloseRoom = false
		};
	}
	/// <summary>
	/// 
	/// </summary>
	[ScriptObject("Permissions", ScriptModuleNames.ROOM_API)]
	public interface IPermissionsService
	{
		/// <summary>
		/// имя файла разрешений
		/// </summary>
		public const string GAME_MODE_ROOM_PERMISSIONS = "client/room/permissions.json";
		/// <summary>
		/// разрешения в комнате
		/// <para>чтобы разрешения в комнате были нестандартные <see cref="RoomPermissions.Default"/> нужно при создании режима создать файл <see cref="GAME_MODE_ROOM_PERMISSIONS"/></para>
		/// </summary>
		RoomPermissions Value { get; }
	}
}