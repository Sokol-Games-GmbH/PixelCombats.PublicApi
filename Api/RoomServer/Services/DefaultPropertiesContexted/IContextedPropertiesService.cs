using PixelCombats.Api.Basic;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Interfaces;

namespace PixelCombats.Api.RoomServer.Services.DefaultPropertiesContexted
{
	/// <summary>
	/// типы скинов
	/// </summary>
	public enum SkinTypes : int
	{
		/// <summary>
		/// стандартный скин
		/// </summary>
		Default = 0,
		/// <summary>
		/// зомби
		/// </summary>
		Zombie = 1,
		/// <summary>
		/// заключенный
		/// </summary>
		Prizoner = 2
	}

	/// <summary>
	/// типы инвентарей
	/// </summary>
	public enum InventoryTypes
	{
		/// <summary>
		/// стандартный инвентарь
		/// </summary>
		Default = 0,
		/// <summary>
		/// зомби
		/// </summary>
		Zombie = 1
	}

	/// <summary>
	/// контекст стандартных контекстных свойств
	/// </summary>
	public interface IContextedPropertiesContext
	{
		/// <summary>
		/// тип скина
		/// </summary>
		IApiProp<SkinTypes, IContextedPropertiesContext> SkinType { get; }
		/// <summary>
		/// тип инвентаря
		/// </summary>
		IApiProp<InventoryTypes, IContextedPropertiesContext> InventoryType { get; }
	}

	/// <summary>
	/// контекст стандартных контекстных свойств в комнате
	/// </summary>
	public interface IRoomContextedPropertiesContext : IContextedPropertiesContext { }
	/// <summary>
	/// контекст стандартных контекстных свойств в команде
	/// </summary>
	public interface ITeamContextedPropertiesContext : IContextedPropertiesContext, ITeamContext { }
	/// <summary>
	/// контекст стандартных контекстных свойств игрока
	/// </summary>
	public interface IPlayerContextedPropertiesContext : IContextedPropertiesContext, IPlayerContext { }

	[ScriptingRoot("contextedProperties")]
	public interface IContextedPropertiesService :
		IContextedService<IRoomContextedPropertiesContext, ITeamContextedPropertiesContext, IPlayerContextedPropertiesContext>
	{ }
}