using System;

namespace PixelCombats.Api.RoomServer.Basic
{
	public sealed class ApiEvent
	{
		public event Action Event;

		public void Add(Action action)
		{
			Event += action;
		}
		public void Remove(Action action)
		{
			Event -= action;
		}
		public void Invoke()
		{
			Event?.Invoke();
		}
	}
	public sealed class ApiEvent<T>
	{
		public event Action<T> Event;
		event Action<object> EventObj;

		public void Add(Action<object> action)
		{
			EventObj += action;
		}
		public void Remove(Action<object> action)
		{
			EventObj -= action;
		}
		public void Invoke(T param)
		{
			Event?.Invoke(param);
			EventObj?.Invoke(param);
		}
	}
	public sealed class ApiEvent<T1, T2>
	{
		public event Action<T1, T2> Event;
		event Action<object, object> EventObj;

		public void Add(Action<object, object> action)
		{
			EventObj += action;
		}
		public void Remove(Action<object, object> action)
		{
			EventObj -= action;
		}
		public void Invoke(T1 param1, T2 param2)
		{
			Event?.Invoke(param1, param2);
			EventObj?.Invoke(param1, param2);
		}
	}
	public sealed class ApiEvent<T1, T2, T3>
	{
		public event Action<T1, T2, T3> Event;
		event Action<object, object, object> EventObj;

		public void Add(Action<object, object, object> action)
		{
			EventObj +=  action;
		}
		public void Remove(Action<object, object, object> action)
		{
			EventObj -= action;
		}
		public void Invoke(T1 param1, T2 param2, T3 param3)
		{
			Event?.Invoke(param1, param2, param3);
			EventObj?.Invoke(param1, param2, param3);
		}
	}
}