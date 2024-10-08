using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Interfaces;
using System;

namespace PixelCombats.Api.RoomServer.Services.Properties
{
	/// <summary>
	/// синхронизируемое свойство, доступное только для чтения
	/// <para>такие свойства создаются и обслуживаются движком</para>
	/// </summary>
	public interface IReadOnlyProperty
	{
		/// <summary>
		/// имя свойства
		/// </summary>
		string Name { get; }
		/// <summary>
		/// контекст свойства (в чем лежит свойство)
		/// </summary>
		IPropertiesContext Context { get; }

		/// <summary>
		/// значение свойства
		/// </summary>
		object Value { get; }
		/// <summary>
		/// возвращает тип значения, которое может хранить или null, если может хранить любое значение
		/// </summary>
		Type ValueType { get; }

		/// <summary>
		/// значение изменилось
		/// </summary>
		ApiEvent<IReadOnlyProperty> OnValue { get; }
	}

	/// <summary>
	/// синхронизируемое свойство, доступное для чтения и записи
	/// </summary>
	public interface IProperty : IReadOnlyProperty
	{
		/// <summary>
		/// значение свойства
		/// </summary>
		new object Value { get; set; }

		/// <summary>
		/// значение изменилось
		/// </summary>
		new ApiEvent<IProperty> OnValue { get; }
	}

	/// <summary>
	/// типизированное, доступное только для чтения свойство
	/// </summary>
	/// <typeparam name="T">тип значения свойства</typeparam>
	public interface IReadOnlyProperty<T> : IReadOnlyProperty
	{
		/// <summary>
		/// значение свойства
		/// </summary>
		new T Value { get; }

		/// <summary>
		/// значение изменилось
		/// </summary>
		new ApiEvent<IReadOnlyProperty<T>> OnValue { get; }
	}
	/// <summary>
	/// типизированное, доступное для чтения и записи свойство
	/// </summary>
	/// <typeparam name="T">тип свойства</typeparam>
	public interface IProperty<T> : IProperty
	{
		/// <summary>
		/// значение свойства
		/// </summary>
		new T Value { get; set; }

		/// <summary>
		/// значение изменилось
		/// </summary>
		new ApiEvent<IProperty<T>> OnValue { get; }
	}

	/// <summary>
	/// контекст свойств (набор свойств)
	/// </summary>
	public interface IPropertiesContext
	{
		/// <summary>
		/// возвращает свойство из контекста по его имени
		/// <para>возвращает только те свойства, которые доступныдля записи (Кроме системных, доступных только для чтения). 
		/// Если свойства с таким именем нет то оно будет создано</para>
		/// <para>если с таким именем зарезервировано системное свойство то возарвщвет null</para>
		/// </summary>
		/// <param name="name">имя значения</param>
		IProperty Get(string name);
		/// <summary>
		/// возвращает свойство, с доступом только для чтения
		/// <para>это более безопасный метод тк если </para>
		/// <para>если свойства с заданным именем нет, то будет создано обычное свойство, с доступом для чтения и записи</para>
		/// </summary>
		/// <param name="name">имя свойства</param>
		IReadOnlyProperty GetReadOnly(string name);
		/// <summary>
		/// попытка получения свойства
		/// </summary>
		/// <param name="name">имя свойства</param>
		/// <param name="property">полученное свойство или null, если свойство отсуствует</param>
		/// <returns>истина, если свойство имеется</returns>
		bool TryGetProperty(string name, out IProperty property);

		/// <summary>
		/// возвращает массив всех свойств
		/// <para>результаты могут иметь интерфайсы: <see cref="IProperty"/>, <see cref="IProperty{T}"/>, <see cref="IReadOnlyProperty"/>, <see cref="IReadOnlyProperty{T}"/></para>
		/// </summary>
		IReadOnlyProperty[] GetAllProperties();
		/// <summary>
		/// возвращает массив всех свойств, доступных для чтения и записи
		/// <para>результаты могут иметь интерфайсы: <see cref="IProperty"/>, <see cref="IProperty{T}"/></para>
		/// </summary>
		IProperty[] GetProperties();
	}

	/// <summary>
	/// контекст свойств комнаты.
	/// </summary>
	public interface IRoomPropertiesContext : IPropertiesContext
	{
		/// <summary>
		/// имя игрового режима. 
		/// <para>видно в списке комнат</para>
		/// </summary>
		IProperty<string> GameModeName { get; }
		/// <summary>
		/// если истина, то комната открыта
		/// </summary>
		IProperty<bool> IsOpen { get; }

		/// <summary>
		/// при смене значения какого-либо свойства в контексте
		/// </summary>
		ApiEvent<IRoomPropertiesContext, IReadOnlyProperty> OnProperty { get; }
	}

	/// <summary>
	/// контекст свойств для команды
	/// </summary>
	public interface ITeamPropertiesContext : IPropertiesContext, ITeamContext
	{
		/// <summary>
		/// при смене значения какого-либо свойства в контексте
		/// </summary>
		ApiEvent<ITeamPropertiesContext, IReadOnlyProperty> OnProperty { get; }
	}

	/// <summary>
	/// контекст свойств для игрока
	/// </summary>
	public interface IPlayerPropertiesContext : IPropertiesContext, IPlayerContext
	{
		/// <summary>
		/// ID игрока, только для чтения
		/// </summary>
		IReadOnlyProperty<string> Id { get; }
		/// <summary>
		/// лвл игрока, только для чтения
		/// </summary>
		IReadOnlyProperty<int> Lvl { get; }
		/// <summary>
		/// уровень тестировщика игры
		/// </summary>
		IReadOnlyProperty<int> TesterLvl { get; }
		/// <summary>
		/// если истина, то игрок неуязвим
		/// </summary>
		IProperty<bool> Immortality { get; }
		/// <summary>
		/// всего убийств (предопределенное значение.>)
		/// </summary>
		IProperty<int> Kills { get; }
		/// <summary>
		/// всего спавнов (предопределенное значение)
		/// </summary>
		IProperty<int> Spawns { get; }
		/// <summary>
		/// всего смертей (предопределенное значение)
		/// </summary>
		IProperty<int> Deaths { get; }
		/// <summary>
		/// всего очков (предопределенное значение)
		/// </summary>
		IProperty<int> Scores { get; }

		/// <summary>
		/// при смене значения какого-либо свойства в контексте
		/// </summary>
		ApiEvent<IPlayerPropertiesContext, IReadOnlyProperty> OnProperty { get; }
	}

	/// <summary>
	/// сервис свойств в комнате
	/// </summary>
	[ScriptObject("Properties", ScriptModuleNames.ROOM_API)]
	public interface IPropertiesService :
		IContextedService<IRoomPropertiesContext, ITeamPropertiesContext, IPlayerPropertiesContext>
	{
		/// <summary>
		/// если какое-либо значение из контекста комнаты изменилось
		/// </summary>
		ApiEvent<IPropertiesContext, IReadOnlyProperty> OnRoomProperty { get; }
		/// <summary>
		/// если какое-либо значение из контекста команды изменилось
		/// </summary>
		ApiEvent<ITeamPropertiesContext, IReadOnlyProperty> OnTeamProperty { get; }
		/// <summary>
		/// если какое-либо значение из контекста игрока изменилось
		/// </summary>
		ApiEvent<IPlayerPropertiesContext, IReadOnlyProperty> OnPlayerProperty { get; }
	}
}