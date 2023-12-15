namespace PixelCombats.Api.RoomServer.Services.Popups
{
	/// <summary>
	/// в сущность можно отправлять всплывающие окна
	/// </summary>
	public interface IPopups
	{
		/// <summary>
		/// показывает окно с текстом, которое не исчезает, пока игрок его не закроет
		/// </summary>
		/// <param name="text">текст в окне</param>
		public void PopUp(string text);
	}
}