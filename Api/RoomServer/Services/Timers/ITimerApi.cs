using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Interfaces;

namespace PixelCombats.Api.RoomServer.Services.Timers
{
	/// <summary>
	/// API для работы с одним таймером
	/// </summary>
	public interface ITimerApi : ITimerEvents
	{
		/// <summary>
		/// id таймера
		/// </summary>
		string Id { get; }
		/// <summary>
		/// если истина, то таймер активен и обрабатывается
		/// </summary>
		bool IsStarted { get; }
		/// <summary>
		/// интервал срабатывания таймера
		/// </summary>
		float Interval { get; }
		/// <summary>
		/// если истина, то таймер по завершении перезапускается
		/// </summary>
		bool IsLoop { get; }
		/// <summary>
		/// сколько времени осталось до срабатывания
		/// </summary>
		float LapsedTime { get; }

		/// <summary>
		/// перезапуск таймера.
		/// <para>если таймер уже был активен то он начнет работу заного с новыми настройками</para>
		/// </summary>
		/// <param name="interval">интервал, через который сработает таймер</param>
		void Restart(float interval);
		/// <summary>
		/// перезапуск таймера, делает его циклически срабатываемым
		/// <para>если таймер уже был активен то он начнет работу заного с новыми настройками</para>
		/// </summary>
		/// <param name="interval">интервал срабатывания таймера</param>
		void RestartLoop(float interval);
		/// <summary>
		/// останавливает таймер, делает его неактивным в комнате (см. <see cref="ITimerApi.IsStarted"/>)
		/// </summary>
		void Stop();
	}

	/// <summary>
	/// интерфейс событий таймера
	/// </summary>
	/// <typeparam name="TimerType">тип таймера</typeparam>
	public interface ITimerEvents
	{
		/// <summary>
		/// если у таймера сменилось состояние <see cref="ITimerApi.IsStarted"/>
		/// </summary>
		ApiEvent<ITimerApi> OnIsStarted { get; }
		/// <summary>
		/// при срабатывании таймера
		/// <para>таймер уже не активен</para>
		/// </summary>
		ApiEvent<ITimerApi> OnTimer { get; }
		/// <summary>
		/// если какой-либо таймер начал свою работу
		/// </summary>
		ApiEvent<ITimerApi> OnRestart { get; }
	}

	/// <summary>
	/// интерфейс таймера в комнате
	/// </summary>
	public interface IRoomTimerApi : ITimerApi { }

	/// <summary>
	/// таймер в контексте игрока
	/// </summary>
	public interface IPlayerTimerApi : ITimerApi, IPlayerContext { }

	/// <summary>
	/// таймер в контексте команды
	/// </summary>
	public interface ITeamTimerApi : ITimerApi, ITeamContext { }
}