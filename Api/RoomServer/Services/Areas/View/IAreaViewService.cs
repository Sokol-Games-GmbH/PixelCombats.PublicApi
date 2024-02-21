using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.Basic.Structures.Math;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Interfaces;
using System;
using System.Collections.Generic;

namespace PixelCombats.Api.RoomServer.Services.Areas.View
{
	/// <summary>
	/// фасад визуализатора зоны
	/// </summary>
	public interface IAreaView : IEquatable<IAreaView>
	{
		/// <summary>
		/// имя визуализатора
		/// </summary>
		string Name { get; }
		/// <summary>
		/// если истина, то данный визуализатор визуализируется
		/// </summary>
		bool Enable { get; set; }
		/// <summary>
		/// конкретная зона для визуализации
		/// </summary>
		IArea Area { get; set; }
		/// <summary>
		/// тэги зон для визуализации
		/// <para>если отлично от null то визуализируются зоны по указанным тэгам</para>
		/// </summary>
		string[] Tags { get; set; }
		/// <summary>
		/// цвет визуализации
		/// </summary>
		Color Color { get; set; }
		/// <summary>
		/// сбрасывает значение в текущем контексте, заставляя взять значение из контекста выше
		/// </summary>
		void Reset();

		/// <summary>
		/// возвращает массив всех зон, с которыми работает
		/// </summary>
		IArea[] GetAreas();

		/// <summary>
		/// если изменились какие-либо данные визуализатора
		/// <para>когда <see cref="Sync"/>==false событий нет!</para>
		/// </summary>
		ApiEvent<IAreaView> OnData { get; }
		/// <summary>
		/// если изменилась одна из зон
		/// </summary>
		ApiEvent<IArea, IAreaView> OnArea { get; }
	}

	/// <summary>
	/// контекст визуализации зон
	/// </summary>
	public interface IAreaViewContext : IEnumerable<IAreaView>
	{
		/// <summary>
		/// возвращает все фасады визуализаторов
		/// <para>Не рекомендуется использовать каждый раз в цикле. Выностие за цикл</para>
		/// </summary>
		IAreaView[] All { get; }
		/// <summary>
		/// возвращает фасад визуализатора по иго имени
		/// </summary>
		/// <param name="name">имя визуализатора</param>
		IAreaView Get(string name);

		/// <summary>
		/// если изменились какие-либо данные какого-либо визуализатора
		/// </summary>
		ApiEvent<IAreaView, IAreaViewContext> OnView { get; }
	}

	/// <summary>
	/// контекст визуализации зон для комнаты
	/// </summary>
	public interface IRoomAreaViewContext : IAreaViewContext { }
	/// <summary>
	/// контекст визуализации зон для команды
	/// </summary>
	public interface ITeamAreaViewContext : IAreaViewContext, ITeamContext { }
	/// <summary>
	/// контекст визуализации зон для игрока
	/// </summary>
	public interface IPlayerAreaViewContext : IAreaViewContext, IPlayerContext { }

	/// <summary>
	/// сервис визуализации зон
	/// </summary>
	[ScriptObject("AreaViewService", ScriptModuleNames.ROOM_API)]
	public interface IAreaViewService :
		IContextedService<IRoomAreaViewContext, ITeamAreaViewContext, IPlayerAreaViewContext>
	{ }
}