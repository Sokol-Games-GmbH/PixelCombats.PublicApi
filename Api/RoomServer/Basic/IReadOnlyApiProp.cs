using System;

namespace PixelCombats.Api.RoomServer.Basic
{
	/// <summary>
	/// значение в апи, доступное только для чтения
	/// </summary>
	/// <typeparam name="TValue">тип значения</typeparam>
	/// <typeparam name="TContext">тип контекста значения</typeparam>
	public interface IReadOnlyApiProp<TValue, TContext>
	{
		/// <summary>
		/// значение свойства
		/// </summary>
		TValue Value { get; }
		/// <summary>
		/// при смене значения или если значение меняет свойство <see cref="IApiProp.IsChanged"/>
		/// </summary>
		event Action<TValue, TContext> OnValue;
	}
}