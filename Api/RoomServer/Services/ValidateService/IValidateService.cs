using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Basic;

namespace PixelCombats.Api.RoomServer.Services.ValidateService
{
	/// <summary>
	/// сервис валидности режима
	/// </summary>
	[ScriptObject("Validate", ScriptModuleNames.ROOM_API)]
	public interface IValidateService
	{
		/// <summary>
		/// если истина, то режим валидный
		/// </summary>
		bool? IsValid { get; }
		/// <summary>
		/// сообщение о невалидности
		/// </summary>
		string Message { get; }
		/// <summary>
		/// сообщает в систему о неполадке в режиме
		/// <para>после этого сообщения комната закрывается</para>
		/// </summary>
		/// <param name="message">сообщение игроку (пропускается через локализацию)</param>
		void ReportInvalid(string message);
		/// <summary>
		/// если это дело вызвать то все последующие вызовы репортов не учитываются
		/// </summary>
		void ReportValid();

		/// <summary>
		/// после репорта валидности
		/// </summary>
		ApiEvent<IValidateService> OnValid { get; }
	}
}