using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Interfaces;
using PixelCombats.Api.RoomServer.Services.Players;
using PixelCombats.Api.RoomServer.Services.Teams;

namespace PixelCombats.Api.RoomServer.Services.PropertiesContexted
{
	/// <summary>
	/// контекстное свойство
	/// </summary>
	public interface IContextedProperty
	{
		/// <summary>
		/// имя свойства
		/// </summary>
		string Name { get; }
		/// <summary>
		/// значение свойства
		/// </summary>
		object Value { get; set; }
		/// <summary>
		/// имеет ли данное свойство значение
		/// </summary>
		bool HasValue { get; }

		/// <summary>
		/// сбрасывает значение, если оно имеется
		/// </summary>
		void Reset();
		/// <summary>
		/// сбрасывает текущее значение и значение всех контекстов выше
		/// </summary>
		void ResetUp();

		/// <summary>
		/// при смене <see cref="Value"/> или при его сбросе, <see cref="HasValue"/>
		/// </summary>
		ApiEvent<IContextedProperty> OnValue { get; }
	}

	/// <summary>
	/// свойство в контексте команды
	/// </summary>
	public interface ITeamContextedProperty : IContextedProperty, ITeamContext { }

	/// <summary>
	/// свойство в контексте игрока
	/// </summary>
	public interface IPlayerContextedProperty : IContextedProperty, IPlayerContext { }

	/// <summary>
	/// сервис контекстных свойств
	/// </summary>
	public interface IPropertiesContextedService
	{
		/// <summary>
		/// возвращает свойство в контексте комнаты
		/// </summary>
		/// <param name="name">имя свойства</param>
		IContextedProperty GetProperty(string name);
		/// <summary>
		/// возвращает свойство в контексте команды
		/// </summary>
		/// <param name="name">имя свойства</param>
		/// <param name="team">команда, для которой нужно получить свойство</param>
		ITeamContextedProperty GetProperty(string name, ITeamApi team);
		/// <summary>
		/// возвращает свойство в контексте игрока
		/// </summary>
		/// <param name="name">имя свойства</param>
		/// <param name="player">игрок, для которого нужно получить свойство</param>
		IPlayerContextedProperty GetProperty(string name, IPlayerApi player);
	}
}