using PixelCombats.Api.Basic;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Interfaces;

namespace PixelCombats.Api.RoomServer.Services.Inventory
{
	/// <summary>
	/// логика инвентаря
	/// </summary>
	public interface IInventoryContext
	{
		/// <summary>
		/// разрешает или запрещает основное оружие
		/// </summary>
		public IApiProp<bool, IInventoryContext> Main { get; }
		/// <summary>
		/// разрешает или отменяет бесконечный боезапас основного оружия
		/// </summary>
		public IApiProp<bool, IInventoryContext> MainInfinity { get; }
		/// <summary>
		/// разрешает или запрещает вторичное оружие (пистолеты)
		/// </summary>
		public IApiProp<bool, IInventoryContext> Secondary { get; }
		/// <summary>
		/// разрешает или отменяет бесконечный боезапас вторичного оружия (пистолета)
		/// </summary>
		public IApiProp<bool, IInventoryContext> SecondaryInfinity { get; }
		/// <summary>
		/// разрешает или запрещает оружие ближнего боя
		/// </summary>
		public IApiProp<bool, IInventoryContext> Melee { get; }
		/// <summary>
		/// разрешает или запрещает взрывчатку
		/// </summary>
		public IApiProp<bool, IInventoryContext> Explosive { get; }
		/// <summary>
		/// разрешает или отменяет бесконечный боезапас взрывчатки
		/// </summary>
		public IApiProp<bool, IInventoryContext> ExplosiveInfinity { get; }
		/// <summary>
		/// разрешает или запрещает строительный инструментарий
		/// </summary>
		public IApiProp<bool, IInventoryContext> Build { get; }
		/// <summary>
		/// разрешает или отменяет бесконечный строительный инструментарий
		/// </summary>
		public IApiProp<bool, IInventoryContext> BuildInfinity { get; }

		/// <summary>
		/// восстанавливает боекомплект имеющегося оружия
		/// </summary>
		public void Restore();
		/// <summary>
		/// восстанавливает боекомплект в указанных слотах
		/// </summary>
		/// <param name="slots">массив слотов или столы через запятую (слоты нумеруются с 1)</param>
		public void Restore(params byte[] slots);

		/// <summary>
		/// настройки инвентаря в данном контексте
		/// </summary>
		//IApiProp<InventorySettings, IInventoryContext> Settings { get; }
		/*/// <summary>
		/// настройки инвентаря в данном слое
		/// </summary>
		InventorySettings Settings { get; }
		/// <summary>
		/// результирующие настройки инвентаря (комбинируются для комнаты, команды и игрока)
		/// <para>комбинирование: настройки команды переопределяют настройки комнаты, настройки игрока переопределяют все остальные настройки</para>
		/// </summary>
		InventorySettings SettingsResult { get; }
		/// <summary>
		/// переопределяет настройки, задавая все как во входной структуре
		/// </summary>
		/// <param name="settings">входная структура настроек</param>
		void Override(InventorySettings settings);
		/// <summary>
		/// модифицирует настройки, задавая только заданные
		/// </summary>
		/// <param name="modification">модифицированные параметры</param>
		void Modify(InventorySettings modification);
		/// <summary>
		/// производит сброс настроек инвентаря
		/// </summary>
		void Clear();*/
	}

	/// <summary>
	/// контекст инвентаря в комнате
	/// </summary>
	public interface IRoomInventoryContext : IInventoryContext
	{
		/*/// <summary>
		/// вызывается, когда изменились настройки инвентаря в комнате
		/// </summary>
		ApiEvent<InventorySettings, IRoomInventoryContext> OnSettings { get; }
		/// <summary>
		/// если изменились результирующие настройки для комнаты
		/// </summary>
		ApiEvent<InventorySettings, IRoomInventoryContext> OnSettingsResult { get; }*/
	}

	/// <summary>
	/// API инвентаря команды
	/// </summary>
	public interface ITeamInventoryContext : IInventoryContext, ITeamContext
	{
		/*/// <summary>
		/// вызывается, когда изменились настройки инвентаря
		/// </summary>
		ApiEvent<InventorySettings, ITeamInventoryContext> OnSettings { get; }
		/// <summary>
		/// изменились результирующие настройки инвентаря в комнате (комбинируется с комнатой)
		/// </summary>
		ApiEvent<InventorySettings, ITeamInventoryContext> OnSettingsResult { get; }*/
	}

	/// <summary>
	/// API инвентаря игрока
	/// </summary>
	public interface IPlayerInventoryContext : IInventoryContext, IPlayerContext
	{
		/*/// <summary>
		/// вызывается, когда изменились настройки инвентаря
		/// </summary>
		ApiEvent<InventorySettings, IPlayerInventoryContext> OnSettings { get; }
		/// <summary>
		/// изменились результирующие настройки инвентаря игрока (комбинируется с комнатой и командой)
		/// </summary>
		ApiEvent<InventorySettings, IPlayerInventoryContext> OnSettingsResult { get; }*/
	}

	/// <summary>
	/// описывает инвентарь в комнате.
	/// </summary>
	/// все настройки переопределяются в следующем порядке комната->команда->игрок.
	/// тоесть если в комнате оружие не разрешено а в команде разрешено, то вче члены команды получают это оружие,
	/// при условии, что у конкретных игроков нет настройки, что оружие запрещено
	[ScriptingRoot("Inventory")]
	public interface IInventoryService :
		IContextedService<IRoomInventoryContext, ITeamInventoryContext, IPlayerInventoryContext>
	{
		/// <summary>
		/// очищает все настройки для комнаты, всех команд и игроков
		/// </summary>
		/*void ClearAll();
		/// <summary>
		/// очищает настройки всех команд
		/// </summary>
		void ClearTeams();
		/// <summary>
		/// очищает настройки всех игроков
		/// </summary>
		void ClearPlayers();*/
	}
}