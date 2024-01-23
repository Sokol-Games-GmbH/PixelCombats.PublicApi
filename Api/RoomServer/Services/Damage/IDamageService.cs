using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Interfaces;
using PixelCombats.Api.RoomServer.Services.Players;

namespace PixelCombats.Api.RoomServer.Services.Damage
{
	/// <summary>
	/// контекст урона
	/// </summary>
	public interface IDamageContext
	{
		/// <summary>
		/// включает или выключает входной урон в указанном контексте (возможность воспринять урон)
		/// <para>восприятие урона</para>
		/// <para>по уполчанию true</para>
		/// </summary>
		IApiProp<bool, IDamageContext> DamageIn { get; }
		/// <summary>
		/// включает или выключает выходной урон в указанном контексте (возможность нанести урон)
		/// <para>возможность наносить урон другим</para>
		/// <para>по умолчанию true</para>
		/// </summary>
		IApiProp<bool, IDamageContext> DamageOut { get; }
		/// <summary>
		/// разрешен ли урон по своим
		/// <para>по умолчанию false</para>
		/// </summary>
		IApiProp<bool, IDamageContext> FriendlyFire { get; }
		/// <summary>
		/// если истина, то граната взрывается от прикосновения к игроку
		/// <para>по умолчанию true</para>
		/// </summary>
		IApiProp<bool, IDamageContext> GranadeTouchExplosion { get; }
	}

	/// <summary>
	/// контекст урона в комнате
	/// </summary>
	public interface IRoomDamageContext : IDamageContext { }

	/// <summary>
	/// контекст урона команды
	/// </summary>
	public interface ITeamDamageContext : IDamageContext, ITeamContext { }

	/// <summary>
	/// контекст урона игрока
	/// </summary>
	public interface IPlayerDamageContext : IDamageContext, IPlayerContext { }

	/// <summary>
	/// сервис урона игрокам
	/// </summary>
	[ScriptObject("Damage", ScriptModuleNames.ROOM_API)]
	public interface IDamageService :
		IContextedService<IRoomDamageContext, ITeamDamageContext, IPlayerDamageContext>
	{
		/// <summary>
		/// первый игрок нанес второму урон
		/// <para>также отработает урон сам себе</para>
		/// </summary>
		ApiEvent<IPlayerApi, IPlayerApi, float> OnDamage { get; }
		/// <summary>
		/// один игрок убил другого или сам себя
		/// </summary>
		ApiEvent<IPlayerApi, IPlayerApi> OnKill { get; }
		/// <summary>
		/// игрок умер по какой-либо причине
		/// </summary>
		ApiEvent<IPlayerApi> OnDeath { get; }
	}
}