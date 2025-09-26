using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Basic;

namespace PixelCombats.Api.RoomServer.Services.BreackGraph
{
	/// <summary>
	/// граф поломок вокселей
	/// <para>используется для определения модели повреждений блоков</para>
	/// </summary>
	[ScriptObject("BreackGraph", ScriptModuleNames.ROOM_API)]
	public interface IBreackGraphService
	{
		/// <summary>
		/// можно ли ломать блоки
		/// <para>по умолчанию<see cref="true"/></para>
		/// </summary>
		bool Damage { get; set; }
		/// <summary>
		/// можно ли ломать блоки игроков
		/// <para>по умолчанию<see cref="true"/></para>
		/// </summary>
		bool PlayerBlockDmg { get; set; }
		/// <summary>
		/// усиление блоков игроков
		/// </summary>
		bool PlayerBlockBoost { get; set; }
		/// <summary>
		/// ослабить блоки
		/// </summary>
		bool WeakBlocks { get; set; }
		/// <summary>
		/// если истина, то может быть сломан любой блок
		/// <para>делает возможным сломать такие блоки как металл, лава итд</para>
		/// </summary>
		bool BreackAll { get; set; }
		/// <summary>
		/// если истина, то ломаль можно только блоки игроков
		/// </summary>
		bool OnlyPlayerBlocksDmg { get; set; }
		/// <summary>
		/// возвращает изначальный (не сломанный) блок для указанного блока, который может быть поломанным
		/// <para>нужно чтобы понять из сломанного блока, какой исходный блок для данного в цепочке поломок блока.
		/// Например любой сломаннй блок красной команды даст просто блок красной команды</para>
		/// </summary>
		/// <param name="blockId">сломанный блок</param>
		/// <returns>исходный, не поломанный блок для текущего блока</returns>
		ushort BlockRoot(ushort blockId);

		/// <summary>
		/// если были изменены опции графа поломок
		/// </summary>
		ApiEvent<IBreackGraphService> OnOptions { get; }
	}
}