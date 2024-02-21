using System;
using JavaScriptEngine.DataAnnotations;

namespace PixelCombats.Api.RoomServer.Basic
{
	/// <summary>
	/// описывает функцию, которая возвращает значение в апи
	/// </summary>
	/// <typeparam name="T1">тип агрумента</typeparam>
	/// <typeparam name="TRes">тип результата</typeparam>
	[ScriptAllowed]
	public class ApiFunc<T1,TRes>
	{
		public event Func<T1, TRes> Func;
		event Func<object, object> FuncObj;

		public void Set(Func<object, object> action)
		{
			FuncObj = action;
		}
		public void Remove()
		{
			FuncObj = null;
		}
		/// <summary>
		/// выполняет функцию, которая задана в делегатах
		/// </summary>
		/// <param name="param1">аргумент функции</param>
		/// <returns>если есть подписка через <see cref="Set"/>, то вернет ее значение, если нет то <see cref="Func"/>, а если и ее нет то <see cref="default(TRes)"/></returns>
		public TRes Invoke(T1 param1)
		{
			if (FuncObj != null) {
				var obj = FuncObj.Invoke(param1);
				if (obj?.GetType() == typeof(double)) {
					var resDouble = (double) obj;
					var resType = typeof(TRes);
					if (resType == typeof(int)) return (TRes)(object)Convert.ToInt32(resDouble);
					if (resType == typeof(float)) return (TRes) (object) (float) resDouble;
					return (TRes) obj;
				}

				if (obj is TRes res) return res;
				return default;
			}
			if (Func != null) return Func.Invoke(param1);
			return default;
		}
	}
}