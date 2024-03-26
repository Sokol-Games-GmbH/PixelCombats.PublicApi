using JavaScriptEngine.DataAnnotations;

namespace PixelCombats.Api.Basic
{
	/// <summary>
	///   <para>Выводит логи на консоль</para>
	///   <para>Восновном используется для дебага скриптов</para>
	/// </summary>
	[ScriptObject("log", ScriptModuleNames.DEBUG)]
	public interface ILogService
	{
		/// <summary>Выволит лог в консоль</summary>
		/// <param name="obj">что вывести</param>
		void Debug(object obj);
		/// <summary>Выводит лог с предупреждением на консоль</summary>
		/// <param name="obj">Что вывести </param>
		void Warn(object obj);
		/// <summary>Выводит лог с ошибкой на консоль</summary>
		/// <param name="obj">Что вывести</param>
		void Err(object obj);
	}
}