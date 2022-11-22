using System.Text;

namespace PixelCombats.Api.RoomServer.Services.Inventory
{
	/// <summary>
	/// определяет информацию о том, у кого какое оружие доступно при спавне и боезапас этого оружия
	/// </summary>
	public struct InventorySettings
	{
		/// <summary>
		/// разрешает или запрещает основное оружие
		/// </summary>
		public bool? Main;
		/// <summary>
		/// разрешает или запрещает вторичное оружие (пистолеты)
		/// </summary>
		public bool? Secondary;
		/// <summary>
		/// разрешает или запрещает оружие ближнего боя
		/// </summary>
		public bool? Melee;
		/// <summary>
		/// разрешает или запрещает взрывчатку
		/// </summary>
		public bool? Explosive;
		/// <summary>
		/// разрешает или запрещает строительный инструментарий
		/// </summary>
		public bool? Build;

		/// <summary>
		/// разрешает или отменяет бесконечный боезапас основного оружия
		/// </summary>
		public bool? MainInfinity;
		/// <summary>
		/// разрешает или отменяет бесконечный боезапас вторичного оружия (пистолета)
		/// </summary>
		public bool? SecondaryInfinity;
		/// <summary>
		/// разрешает или отменяет бесконечный боезапас взрывчатки
		/// </summary>
		public bool? ExplosiveInfinity;
		/// <summary>
		/// разрешает или отменяет бесконечный строительный инструментарий
		/// </summary>
		public bool? BuildInfinity;

		public override string ToString()
		{
			var sb = new StringBuilder(100);
			if (Main.HasValue && Main.Value) sb.Append("Main").Append('|');
			if (Secondary.HasValue && Secondary.Value) sb.Append("Secondary").Append('|');
			if (Melee.HasValue && Melee.Value) sb.Append("Melee").Append('|');
			if (Explosive.HasValue && Explosive.Value) sb.Append("Explosive").Append('|');
			if (Build.HasValue && Build.Value) sb.Append("Build").Append('|');

			if (MainInfinity.HasValue && MainInfinity.Value) sb.Append("MainInfinity").Append('|');
			if (SecondaryInfinity.HasValue && SecondaryInfinity.Value) sb.Append("SecondaryInfinity").Append('|');
			if (ExplosiveInfinity.HasValue && ExplosiveInfinity.Value) sb.Append("ExplosiveInfinity").Append('|');
			if (BuildInfinity.HasValue && BuildInfinity.Value) sb.Append("BuildInfinity").Append('|');
			return sb.ToString();
		}
	}
}