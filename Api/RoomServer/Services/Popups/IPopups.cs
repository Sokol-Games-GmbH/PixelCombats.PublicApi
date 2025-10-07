namespace PixelCombats.Api.RoomServer.Services.Popups
{
	/// <summary>
	/// в сущность можно отправлять всплывающие окна
	/// <para>Важно: для работы всплывающих окон в режиме должен быть включён флаг
	/// <c>PopupsEnabled</c> в корне файла <c>gamemode.json</c> (по умолчанию выключено).</para>
	/// </summary>
	public interface IPopups
	{
		/// <summary>
		/// показывает окно с текстом, которое не исчезает, пока игрок его не закроет
		/// </summary>
		/// <param name="text">текст в окне</param>
		/// <para>может быть ключем локализации</para>
		public void PopUp(string text);
	}
}