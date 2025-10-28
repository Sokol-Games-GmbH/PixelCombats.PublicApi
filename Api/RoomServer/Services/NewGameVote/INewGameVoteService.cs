using JavaScriptEngine.DataAnnotations;
using PixelCombats.Annotation;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Services.NewGame;
using System;

namespace PixelCombats.Api.RoomServer.Services.NewGameVote
{
	/// <summary>
	/// параметры создания нового голосования
	/// </summary>
	[ScriptType("NewGameVoteStartParameters", ScriptModuleNames.ROOM_API)]
	[ScriptAllowed]
	public struct NewGameVoteStartParameters
	{
		/// <summary>
		/// варианты
		/// </summary>
		public NewGameData[] Variants;
		/// <summary>
		/// максимальное время голосования в секундах
		/// </summary>
		public double Timer;
	}

	/// <summary>
	/// данные имеющегося голосования
	/// </summary>
	[Serializable]
	[ScriptAllowed]
	public class NewGameVoteDTO
	{
		/// <summary>
		/// варианты новой игры
		/// </summary>
		[SerializeMember(1)]
		public NewGameData[] Variants;
		/// <summary>
		/// время конца голосования
		/// </summary>
		[SerializeMember(2)]
		public double EndTime;
	}

	#region система запросов вариантов игр
	/// <summary>
	/// запрос на получение вариантов новой игры
	/// </summary>
	public interface INewGameVariantsRequest { }

	/// <summary>
	/// описывает конкретный вариант
	/// </summary>
	[ScriptType("Variant", ScriptModuleNames.NEW_GAME_VOTE_TYPES)]
	[ScriptAllowed]
	public class Variant : INewGameVariantsRequest
	{
		/// <summary>
		/// ID карты или 0, если таже самая карта
		/// </summary>
		public long MapId { get; set; }
		/// <summary>
		/// ID списка карт или 0, если тотже самый список карт
		/// </summary>
		public long MapListId { get; set; }

		public Variant() { }
		public Variant(long mapId, long mapListId)
		{
			this.MapId = mapId;
			this.MapListId = mapListId;
		}
	}

	/// <summary>
	/// тотже самый вариант, который сейчас играется
	/// </summary>
	[ScriptType("SameVariant", ScriptModuleNames.NEW_GAME_VOTE_TYPES)]
	[ScriptAllowed]
	public sealed class SameVariant : Variant
	{
		public SameVariant() : base(0, 0) { }
	}

	/// <summary>
	/// если задано в наборе запросов вариантов, то результат отбросит все не уникальное
	/// <para>в наборе может быть только один запрос уникальности</para>
	/// </summary>
	[ScriptType("OnlyUniqueVariants", ScriptModuleNames.NEW_GAME_VOTE_TYPES)]
	[ScriptAllowed]
	public sealed class OnlyUniqueVariants : INewGameVariantsRequest
	{
		/// <summary>
		/// если истина, то карты уникальные
		/// </summary>
		public bool MapUnique { get; set; }
		/// <summary>
		/// если истина, то списки карт уникальные
		/// </summary>
		public bool MapListUnique { get; set; }

		public OnlyUniqueVariants(bool mapUnique = true, bool mapListUnique = true)
		{
			this.MapUnique = mapUnique;
			this.MapListUnique = mapListUnique;
		}
	}

	/// <summary>
	/// возвращает варианты для голосования из текущего списка карт
	/// </summary>
	[ScriptType("FromSameMapList", ScriptModuleNames.NEW_GAME_VOTE_TYPES)]
	[ScriptAllowed]
	public sealed class FromSameMapList : INewGameVariantsRequest
	{
		/// <summary>
		/// сколько вариантов запрашивается
		/// <para>если вариантов указано большее или равное чем есть в текущем списке, то вернет все что есть в списке, так как повторы исключаются</para>
		/// </summary>
		public int Count { get; set; }

		public FromSameMapList() { }
		public FromSameMapList(int count)
		{
			Count = count;
		}
	}

	/// <summary>
	/// возвращает варианты для голосования из всех официальных списков карт
	/// </summary>
	[ScriptType("FromOfficialMapLists", ScriptModuleNames.NEW_GAME_VOTE_TYPES)]
	[ScriptAllowed]
	public sealed class FromOfficialMapLists : INewGameVariantsRequest
	{
		/// <summary>
		/// сколько вариантов запрашивается
		/// <para>если вариантов указано больше или равное количеству во всех списках, то вернет все что есть во всех списках, так как повторы исключаются</para>
		/// </summary>
		public int Count { get; set; }
		/// <summary>
		/// если истина, то текущий список карт не учитывается
		/// </summary>
		public bool ExcludeSameMapList { get; set; }

		public FromOfficialMapLists() { }
		public FromOfficialMapLists(int count, bool excludeSameMapList = false)
		{
			Count = count;
			ExcludeSameMapList = excludeSameMapList;
		}
	}
	#endregion

	/// <summary>
	/// сервис инициализации голосования за новую игру
	/// </summary>
	[ScriptObject("NewGameVote", ScriptModuleNames.ROOM_API)]
	public interface INewGameVoteService
	{
		/// <summary>
		/// текущие варианты
		/// <para>если задано то голосование идет</para>
		/// <para>возвращает кэшированое значение - только для чтения</para>
		/// </summary>
		NewGameVoteDTO Data { get; }
		/// <summary>
		/// результаты голосования за варианты
		/// <para>вариант с индексом за последним - это пропуск голосования</para>
		/// <para>может быть пустым массивом</para>
		/// <para>количества голосов за варианты, соответствующих индексов</para>
		/// <para>возвращает кэшированое значение - только для чтения</para>
		/// </summary>
		int[] Votes { get; }
		/// <summary>
		/// результат голосования или null
		/// </summary>
		NewGameData Result { get; }
		/// <summary>
		/// если истина, то в данный момент идет голосование
		/// </summary>
		bool IsActive { get; }
		/// <summary>
		/// сколько времени осталось на голосование или 0, если нет голосования
		/// </summary>
		double LapsedTime { get; }

		/// <summary>
		/// запускает голосование за новую игру
		/// <para>если голосование уже идет то ничего не происходит</para>
		/// </summary>
		/// <param name="arg">параметры нового голосования</param>
		void Start(NewGameVoteStartParameters arg);
		/// <summary>
		/// запускает голосование за новую игру с дополнительными вариантами из текущего списка карт
		/// <param name="arg">изначальные опции голосования</param>
		/// <param name="extraVariantsCount">количество вариантов для голосования, помимо текущего варианта (не более 10)</param>
		/// </summary>
		void Start(NewGameVoteStartParameters arg, int extraVariantsCount);
		/// <summary>
		/// запускает голосование за новую игру
		/// <para>если голосование уже идет то ничего не происходит</para>
		/// </summary>
		/// <param name="variants">варианты голосования</param>
		/// <param name="timer">время, отведенное на голосование</param>
		void Start(INewGameVariantsRequest[] variants, double timer);

		/// <summary>
		/// изменилось <see cref="Data"/>
		/// </summary>
		ApiEvent<INewGameVoteService> OnData { get; }
		/// <summary>
		/// изменилось <see cref="Votes"/>
		/// </summary>
		ApiEvent<INewGameVoteService> OnVote { get; }
		/// <summary>
		/// изменился <see cref="Result"/>
		/// </summary>
		ApiEvent<INewGameVoteService> OnResult { get; }
	}
}