using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Interfaces;
using PixelCombats.Api.RoomServer.Services.Players;
using System.Collections.Generic;

namespace PixelCombats.Api.RoomServer.Services.Damage
{
	/// отчёт о смерти жертвы с вкладом всех причастных
	public interface IKillReport
	{
		/// <summary>
		/// жертва
		/// </summary>
		IPlayerApi Victim { get; }
		/// <summary>
		/// кто убил
		/// </summary>
		/// <para>если суицид — Victim</para>
		IPlayerApi Killer { get; }
		/// <summary>
		/// убившее попадание
		/// </summary>
		IHitData KillHit { get; }
		/// <summary>
		/// вначале убийца, потом отсортировано по убыванию урона помошь в убийстве (ассист), если таковые имеются
		/// </summary>
		IList<IKillContributionItem> Items { get; }
	}

	/// элемент вклада конкретного атакующего
	public interface IKillContributionItem
	{
		/// <summary>
		/// кто нанес урон
		/// </summary>
		IPlayerApi Attacker { get; }
		/// <summary>
		/// нанесенный урон, который засчитан в поддержку
		/// </summary>
		float Damage { get; }
		/// <summary>
		/// количество засчитанных в поддержку попаданий
		/// </summary>
		int Hits { get; }
		/// <summary>
		/// это финальный убийца
		/// </summary>
		bool IsKiller { get; }
	}

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
		/// <para>устарело, используйте OnHit</para>
		/// </summary>
		ApiEvent<IPlayerApi, IPlayerApi, float> OnDamage { get; }
		/// <summary>
		/// отрабатывает любое попадание (урон)
		/// <para>также отработает урон сам себе</para>
		/// <para>первый аргумент кто нанес урон, кторой кому, третий - детали попадания</para>
		/// </summary>
		ApiEvent<IPlayerApi, IPlayerApi, IHitData> OnHit { get; }
		/// <summary>
		/// один игрок убил другого или сам себя
		/// </summary>
		ApiEvent<IPlayerApi, IPlayerApi> OnKill { get; }
		/// <summary>
		/// игрок умер по какой-либо причине
		/// </summary>
		ApiEvent<IPlayerApi> OnDeath { get; }
		/// <summary>
		/// детальный отчёт по убийству с вкладом всех, кто нанёс урон в окне времени
		/// </summary>
		ApiEvent<IPlayerApi, IPlayerApi, IKillReport> OnKillReport { get; }
	}
}