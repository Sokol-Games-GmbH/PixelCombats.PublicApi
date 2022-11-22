namespace PixelCombats.Api.Client
{
	/// <summary>
	/// сервис игровых режимов
	/// </summary>
	public interface IGameModeSourcesService
	{
		/// <summary>
		/// источник стандартных игровых режимов
		/// </summary>
		IGameModesSource Standart { get; }
	}
}