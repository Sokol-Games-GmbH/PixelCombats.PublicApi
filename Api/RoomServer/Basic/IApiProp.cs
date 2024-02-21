using System;

namespace PixelCombats.Api.RoomServer.Basic
{
	/// <summary>
	/// свойство в API
	/// </summary>
	public interface IApiProp
	{
		/// <summary>
		/// если истина, то значение задано
		/// </summary>
		bool IsChanged { get; }

		/// <summary>
		/// сброс значения до значения по умолчанию, также значение <see cref="IsChanged"/> станет <see cref="false"/>
		/// </summary>
		void Reset();

		/// <summary>
		/// тип значения
		/// </summary>
		Type ValueType { get; }

		void SetValueInternal(object obj); // todo вырезать

		/// <summary>
		/// добавляет слушателя изменения события
		/// </summary>
		/// <param name="action">делегат - слушатель</param>
		void AddListener(Action<object, object> action);
		/// <summary>
		/// удаляет слушателя
		/// </summary>
		/// <param name="action">делегат - слушатель</param>
		void RemoveListener(Action<object, object> action);
	}

	/// <summary>
	/// синхронизированное свойство
	/// </summary>
	/// <typeparam name="TValue">тип значения</typeparam>
	/// <typeparam name="TContext">тип контекста значения</typeparam>
	public interface IApiProp<TValue, TContext>: IApiProp, IReadOnlyApiProp<TValue, TContext>
	{
		/// <summary>
		/// задает значение свойства
		/// </summary>
		TValue Value { get; set; }
	}
}