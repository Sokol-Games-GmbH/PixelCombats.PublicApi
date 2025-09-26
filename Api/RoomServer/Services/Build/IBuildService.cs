using JavaScriptEngine.DataAnnotations;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Interfaces;
using PixelCombats.Api.RoomServer.Services.Players;

namespace PixelCombats.Api.RoomServer.Services.Build
{
	/// <summary>
	/// контекст строительства
	/// </summary>
	/// <typeparam name="TContext">тип контекста</typeparam>
	public interface IBuildContext
	{
		/// <summary>
		/// набор блоков
		/// </summary>
		IApiProp<IBlocksSet, IBuildContext> BlocksSet { get; }
		/// <summary>
		/// разрешена ли пипетка
		/// <para>по умолчанию нет</para>
		/// </summary>
		IApiProp<bool, IBuildContext> Pipette { get; }
		/// <summary>
		/// разрешена ли заливка одного квада
		/// <para>по умолчанию нет</para>
		/// </summary>
		IApiProp<bool, IBuildContext> FloodFill { get; }
		/// <summary>
		/// разрешена ли заливка одного блока
		/// <para>по умолчанию нет</para>
		/// </summary>
		IApiProp<bool, IBuildContext> FillQuad { get; }
		/// <summary>
		/// можно ли удалять квады
		/// <para>по умолчанию нет</para>
		/// </summary>
		IApiProp<bool, IBuildContext> RemoveQuad { get; }
		/// <summary>
		/// можно ли менять длину балки игрокам
		/// <para>по умолчанию нет</para>
		/// </summary>
		IApiProp<bool, IBuildContext> BalkLenChange { get; }
		/// <summary>
		/// длина балки
		/// <para>по умолчанию 10</para>
		/// <para>todo не реализовано</para>
		/// </summary>
		IApiProp<int, IBuildContext> BalkLen { get; }
		/// <summary>
		/// разрешен ли режим полета
		/// <para>по умолчанию нет</para>
		/// </summary>
		IApiProp<bool, IBuildContext> FlyEnable { get; }
		/// <summary>
		/// можно ли менять скайбокс
		/// </summary>
		IApiProp<bool, IBuildContext> SetSkyEnable { get; }
		/// <summary>
		/// можно ли генерировать карту
		/// </summary>
		IApiProp<bool, IBuildContext> GenMapEnable { get; }
		/// <summary>
		/// можно ли менять точки просмотра камеры
		/// </summary>
		IApiProp<bool, IBuildContext> ChangeCameraPointsEnable { get; }
		/// <summary>
		/// можно ли рисовать квадами
		/// </summary>
		IApiProp<bool, IBuildContext> QuadChangeEnable { get; }
		/// <summary>
		/// разрешает или запрещает режим строительства
		/// </summary>
		IApiProp<bool, IBuildContext> BuildModeEnable { get; }
		/// <summary>
		/// можно ли менять количество блоков, которое может упасть
		/// </summary>
		IApiProp<bool, IBuildContext> CollapseChangeEnable { get; }
		/// <summary>
		/// можно ли переименовываеть карту
		/// </summary>
		IApiProp<bool, IBuildContext> RenameMapEnable { get; }
		/// <summary>
		/// можно ли менять список авторов карты
		/// </summary>
		IApiProp<bool, IBuildContext> ChangeMapAuthorsEnable { get; }
		/// <summary>
		/// можно ли загружать карту
		/// </summary>
		IApiProp<bool, IBuildContext> LoadMapEnable { get; }
		/// <summary>
		/// можно ли менять спавнпоинты
		/// </summary>
		IApiProp<bool, IBuildContext> ChangeSpawnsEnable { get; }
		/// <summary>
		/// можно ли строить областями. и можно ли редактировать зоны на карте
		/// <para>по умолчанию false</para>
		/// </summary>
		IApiProp<bool, IBuildContext> BuildRangeEnable { get; }
	}

	/// <summary>
	/// контекст строительства для комнаты
	/// </summary>
	public interface IRoomBuildContext : IBuildContext { }

	/// <summary>
	/// контекст строительства для команды
	/// </summary>
	public interface ITeamBuildContext : ITeamContext, IBuildContext { }

	/// <summary>
	/// контекст строительства для игрока
	/// </summary>
	public interface IPlayerBuildContext : IPlayerContext, IBuildContext
	{
		/// <summary>
		/// идентиффикатор блока в руках у игрока
		/// </summary>
		IApiProp<ushort, IPlayerBuildContext> BuildBlockId { get; }
	}

	/// <summary>
	/// сервис строительства
	/// <para>включает в себя функционал изменения геометрии карт</para>
	/// </summary>
	[ScriptObject("Build", ScriptModuleNames.ROOM_API)]
	public interface IBuildService : IContextedService<IRoomBuildContext, ITeamBuildContext, IPlayerBuildContext> { }
}