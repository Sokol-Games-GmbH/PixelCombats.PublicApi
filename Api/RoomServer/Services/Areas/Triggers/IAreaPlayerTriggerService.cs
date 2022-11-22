using PixelCombats.Api.Basic;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Services.Players;
using System.Collections.Generic;

namespace PixelCombats.Api.RoomServer.Services.Areas.Triggers
{
	/// <summary>
	/// триггер для зон
	/// </summary>
	public interface IAreaTrigger
	{
		/// <summary>
		/// имя триггера
		/// </summary>
		string Name { get; }
		/// <summary>
		/// зона, с которой работает
		/// </summary>
		IArea Area { get; set; }
		/// <summary>
		/// тэги зон, с которыми работает
		/// </summary>
		string[] Tags { get; set; }
		/// <summary>
		/// включен ли триггер
		/// <para>когда выключен - не работают события и не идет никакой учет (экономится производительность)</para>
		/// </summary>
		bool Enable { get; set; }

		/// <summary>
		/// возвращает массив всех зон, с которыми работает
		/// </summary>
		/// <returns></returns>
		IArea[] GetAreas();

		/// <summary>
		/// изменились настройки триггера
		/// </summary>
		ApiEvent<IAreaTrigger> OnData { get; }
		/// <summary>
		/// если изменилась одна из зон
		/// </summary>
		ApiEvent<IArea, IAreaTrigger> OnArea { get; }
	}

	/// <summary>
	/// триггер игроков для зон
	/// </summary>
	public interface IPlayerTrigger : IAreaTrigger
	{
		/// <summary>
		/// количество игроков в триггере
		/// </summary>
		int Count { get; }

		/// <summary>
		/// если истина, то игрок находится в триггере
		/// </summary>
		/// <param name="player">проверяемый игрок</param>
		bool Contains(IPlayerApi player);
		/// <summary>
		/// возвращает копию массива всех игроков внутри триггера
		/// </summary>
		/// <returns></returns>
		IPlayerApi[] GetPlayers();

		/// <summary>
		/// если игрок зашел в триггер
		/// </summary>
		ApiEvent<IPlayerApi, IArea, IPlayerTrigger> OnEnter { get; }
		/// <summary>
		/// игрок вышел из тригера
		/// </summary>
		ApiEvent<IPlayerApi, IArea, IPlayerTrigger> OnExit { get; }
	}

	/// <summary>
	/// сервис триггеров зон
	/// </summary>
	[ScriptingRoot("AreaPlayerTriggerService")]
	public interface IAreaPlayerTriggerService : IEnumerable<IPlayerTrigger>
	{
		/// <summary>
		/// возвращает триггер игроков по имени
		/// </summary>
		/// <param name="name">имя триггера игроков</param>
		IPlayerTrigger Get(string name);

		/// <summary>
		/// когда изменился какой-либо триггер
		/// </summary>
		ApiEvent<IPlayerTrigger, IAreaPlayerTriggerService> OnTrigger { get; }
	}
}