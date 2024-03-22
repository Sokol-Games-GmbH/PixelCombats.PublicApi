using JavaScriptEngine.DataAnnotations;
using PixelCombats.Annotation;
using System;
using PixelCombats.Api.RoomServer.Basic;
using PixelCombats.Api.RoomServer.Services.NewGame;

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