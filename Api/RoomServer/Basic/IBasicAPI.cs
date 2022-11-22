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
	[ScriptingRoot("basic")]
	public interface IBasicAPI
	{
		/// <summary>Выводит логи на консоль</summary>
		ILogService Log { get; }
		/// <summary>Выводит сообщения игроку </summary>
		IMessageService Msg { get; }
	}
}