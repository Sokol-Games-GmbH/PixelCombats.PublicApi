using PixelCombats.DTO.Room.GameMode;
using PixelCombats.DTO.Room.Map;
using System.Threading.Tasks;

namespace PixelCombats.Api.Client.MainMenu.Services.RoomList
{
	/// <summary>
	/// результат входа в комнату
	/// </summary>
	public struct RoomJoinResult
	{
		/// <summary>
		/// если истина, то в комнату удалось войти
		/// </summary>
		public bool IsJoined;
		/// <summary>
		/// если не null то содержит информацию об ошибке входа
		/// </summary>
		public string Error;
	}
	/// <summary>
	/// дескриптор одной комнаты в списке комнат
	/// </summary>
	public interface IRoomHandler
	{
		/// <summary>
		/// имя комнаты
		/// </summary>
		string Name { get; }
		/// <summary>
		/// максимум игроков в комнате
		/// </summary>
		int PlayersMax { get; }
		/// <summary>
		/// текущее количество игроков в комнате
		/// </summary>
		int PlayersCount { get; }
		/// <summary>
		/// если истина, то комната имеет пароль
		/// </summary>
		bool HasPassword { get; }
		/// <summary>
		/// если истина, то это экспериментальная комната, созданная разработчиком
		/// </summary>
		bool IsExperimental { get; }
		/// <summary>
		/// если ложно то в комнату никак зайти нельзя
		/// </summary>
		bool IsOpen { get; }
		/// <summary>
		/// минимальный лвл в комнате или 0
		/// </summary>
		int MinLvl { get; }
		/// <summary>
		/// игровой режим
		/// </summary>
		GameModeMeta GameMode { get; }
		/// <summary>
		/// значения параметров игрового режима
		/// </summary>
		GameModeParametersValues GameModeParameters { get; }
		/// <summary>
		/// карта
		/// </summary>
		MapMeta Map { get; }
		/// <summary>
		/// если истина, то комната полная
		/// </summary>
		bool IsFull { get; }
		/// <summary>
		/// если истина, то версия игрового режима подходит для текущего клиента
		/// </summary>
		bool IsClientVersionCorrectForGameMode { get; }
		/// <summary>
		/// версия сетевого протокола
		/// </summary>
		public string NetworkVersion { get; }

		/// <summary>
		/// попытка войти в комнату
		/// </summary>
		/// <param name="password">пароль комнаты</param>
		Task<RoomJoinResult> Join(string password);
		/// <summary>
		/// попытка войти в комнату
		/// </summary>
		Task<RoomJoinResult> Join();
	}
}