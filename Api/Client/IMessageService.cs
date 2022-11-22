using PixelCombats.Api.Basic;

namespace PixelCombats.Api.Client
{
	/// <summary>
	///  Выводит сообщения игроку
	///  <para>Используется, если нужно вывести сообщение игроку</para>
	/// </summary>
	[ScriptingRoot("msg")]
	public interface IMessageService
	{
		/// <summary>
		/// Выводит сообщение локальному игроку</summary>
		/// <param name="content">Что вывести</param>
		void Show(object content);
		/// <summary>
		/// Выводит сообщение локальному игроку</summary>
		/// <param name="content">Что вывести</param>
		/// <param name="caption">Заголовок</param>
		void Show(object content, object caption);
		/// <summary>
		/// выводит сообщение об ошибке
		/// </summary>
		/// <param name="content">что выводить</param>
		void ShowError(object content);
		/// <summary>
		/// выводит сообщение об ошибке
		/// </summary>
		/// <param name="content">что выводить</param>
		/// <param name="caption">заголовок</param>
		void ShowError(object content, object caption);
	}
}
