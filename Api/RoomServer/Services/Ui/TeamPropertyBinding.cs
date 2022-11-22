using PixelCombats.Annotation;
using System;

namespace PixelCombats.Api.RoomServer.Services.Ui
{
	/// <summary>
	/// описывает свойство команды
	/// </summary>
	[Serializable]
	public class TeamPropertyBinding
	{
		/// <summary>
		/// ID команды
		/// </summary>
		[SerializeMember(1)]
		public string Team;
		/// <summary>
		/// имя свойства
		/// </summary>
		[SerializeMember(2)]
		public string Prop;
	}
}