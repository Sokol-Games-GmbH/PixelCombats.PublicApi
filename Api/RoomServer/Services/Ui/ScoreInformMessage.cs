using JavaScriptEngine.DataAnnotations;
using PixelCombats.Annotation;
using System;

namespace PixelCombats.Api.RoomServer.Services.Ui
{
	/// <summary>
	/// тип уведомления об очках
	/// </summary>
	public enum ScoreInformType
	{
		/// <summary>ассист</summary>
		Assist = 1,
		/// <summary>килл</summary>
		Kill = 2,
		/// <summary>постройка карты</summary>
		Build = 3,
		/// <summary>поломка нейтрального блока</summary>
		NeutralBlockDestroy = 4,
		/// <summary>поломка вражеского блока</summary>
		EnemyBlockDestroy = 5
	}

	/// <summary>
	/// структура параметров уведомления об очках
	/// </summary>
	[Serializable]
	[ScriptAllowed]
	[ScriptType("ScoreInformMessage", ScriptModuleNames.BASIC)]
	public class ScoreInformMessage
	{
		/// <summary>
		/// тип сообщения
		/// </summary>
		[SerializeMember(1)]
		public ScoreInformType Type;
		/// <summary>
		/// ID оружия, из которого было убийство или ассист (если применимо)
		/// </summary>
		[SerializeMember(2)]
		public int WeaponId;
		/// <summary>
		/// сколько очков выдано
		/// </summary>
		[SerializeMember(3)]
		public int Scores;
		/// <summary>
		/// признак хедшота (для корректного текста и оформления уведомления при килле)
		/// </summary>
		[SerializeMember(4)]
		public bool IsHeadshot;
	}
}


