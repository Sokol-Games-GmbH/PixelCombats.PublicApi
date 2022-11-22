using System.Collections.Generic;
using PixelCombats.Api.Basic;
using PixelCombats.Api.Basic.Structures.Math;
using PixelCombats.Api.RoomServer.Basic;

namespace PixelCombats.Api.RoomServer.Services.Areas
{
	/// <summary>
	/// описывает область карты
	/// <para>является фасадом зоны, который можно получить даже, если такой области нет в комнате</para>
	/// </summary>
	public interface IArea
	{
		/// <summary>
		/// уникальное имя зоны
		/// </summary>
		string Name { get; }
		/// <summary>
		/// набор тэгов
		/// </summary>
		ITagsSet Tags { get; }
		/// <summary>
		/// все диапазоны индексов, которые входят в состав зоны
		/// </summary>
		IRangesSet Ranges { get; }
		/// <summary>
		/// если истина, то текущая зона пустая, значит ничего не содержит и она не синхронизирована в комнате
		/// <para>изменяется на false если в зоне имеется хоть что-то</para>
		/// </summary>
		bool IsEmpty { get; }
		/// <summary>
		/// входит ли указанный индекс пространства в зону
		/// </summary>
		/// <param name="index">индекс пространства</param>
		bool Contains(Index index);

		/// <summary>
		/// сменилось свойство <see cref="IsEmpty"/>
		/// </summary>
		ApiEvent<IArea> OnEmpty { get; }
		/// <summary>
		/// если что-либо изменилось в области
		/// </summary>
		ApiEvent<IArea> OnData { get; }
	}

	/// <summary>
	/// сервис зон на карте
	/// <para>если работать как с перечислителем то выдаст все дескрипторы всех зон, и пустых и нет</para>
	/// </summary>
	[ScriptingRoot("AreaService")]
	public interface IAreaService: IEnumerable<IArea>
	{
		/// <summary>
		/// возвращает зону по ее уникальному имени
		/// <para>если такой зоны нет, то будет создан пустой объект зоны</para>
		/// </summary>
		/// <param name="name">имя зоны</param>
		IArea Get(string name);
		/// <summary>
		/// возвращает массив всех зон с указанным тэгом
		/// <para>
		/// этот масив формируется при каждом запросе новый,
		/// изменение массива не даст эффекта
		/// </para>
		/// </summary>
		/// <param name="tag">тэг, для которого получить зоны</param>
		IArea[] GetByTag(string tag);

		/// <summary>
		/// добавилась или обновилась какая-либо зона
		/// </summary>
		ApiEvent<IArea, IAreaService> OnArea { get; }
	}
}