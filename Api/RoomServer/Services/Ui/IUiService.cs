using PixelCombats.Api.Basic;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Interfaces;

namespace PixelCombats.Api.RoomServer.Services.Ui
{
	/// <summary>
	/// контекст пользовательского интерфейса
	/// </summary>
	public interface IUIContext
	{
		/// <summary>
		/// ID основного таймера с контекста комнаты
		/// </summary>
		IApiProp<string, IUIContext> MainTimerId { get; }
		/// <summary>
		/// подсказка
		/// </summary>
		IApiProp<string, IUIContext> Hint { get; }
		/// <summary>
		/// нужно ли выводить количество квадов
		/// <para>по умолчанию false</para>
		/// </summary>
		IApiProp<bool, IUIContext> QuadsCount { get; }
		/// <summary>
		/// свойство левое вверху
		/// </summary>
		IApiProp<TeamPropertyBinding, IUIContext> TeamProp1 { get; }
		/// <summary>
		/// свойство правое вверху
		/// </summary>
		IApiProp<TeamPropertyBinding, IUIContext> TeamProp2 { get; }
		/// <summary>
		/// Отображение сообщений в углу экрана
		/// </summary>
		IApiProp<bool, IUiContext> EventsLineEnable { get; }
		/// <summary>
		/// Отвечает за отображение Ui интерфейса у игрока
		/// Нужно например для скриншота карты
		/// </summary>
		IApiProp<bool, IUiContext> ViewEnable { get; }
	}

	/// <summary>
	/// контекст интерфейса в комнате
	/// </summary>
	public interface IRoomUIContext : IUIContext { }

	/// <summary>
	/// контекст интерфейса на уровне команды
	/// </summary>
	public interface ITeamUIContext : IUIContext, ITeamContext { }

	/// <summary>
	/// контекст интерфейса на уровне игрока
	/// </summary>
	public interface IPlayerUIContext : IUIContext, IPlayerContext { }

	/// <summary>
	/// сервис пользовательского интерфейса
	/// </summary>
	[ScriptingRoot("Ui")]
	public interface IUiService :
		IContextedService<IRoomUIContext, ITeamUIContext, IPlayerUIContext>
	{ }
}
