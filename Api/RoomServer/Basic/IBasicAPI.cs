using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.Basic;
using PixelCombats.Api.Client;

namespace PixelCombats.Api.RoomServer.Basic
{
	/// <summary>
	///   <para>
	/// API клиента</para>
	///   <para>Доступно всегда
	/// </para>
	/// </summary>
	[ScriptObject("basic", ScriptModuleNames.BASIC)]
	public interface IBasicAPI
	{
		/// <summary>Выводит логи на консоль</summary>
		ILogService Log { get; }
		/// <summary>Выводит сообщения игроку </summary>
		IMessageService Msg { get; }
	}
}