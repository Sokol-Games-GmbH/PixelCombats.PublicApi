using PixelCombats.Api.Basic;
using PixelCombats.Api.RoomServer.Basic;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PixelCombats.Api.Client.MainMenu.Services.RoomList
{
	/// <summary>
	/// интерфейс фильтра комнат
	/// </summary>
	public interface IRoomsFilter
	{
		/// <summary>
		/// производит проверку комнаты и если комната годная то выдает истину
		/// </summary>
		/// <param name="room">проверяемая комната</param>
		/// <returns></returns>
		bool FilterRoom(IRoomHandler room);
	}

	/// <summary>
	/// ответ запроса получания списка комнат
	/// </summary>
	public struct GetRoomsResponce
	{
		/// <summary>
		/// если произошла ошибка
		/// </summary>
		public bool IsError;
		/// <summary>
		/// ошибка
		/// </summary>
		public string ErrorString;
		/// <summary>
		/// список комнат
		/// </summary>
		public IList<IRoomHandler> Rooms;
	}

	/// <summary>
	/// фильтр комнат по имени
	/// </summary>
	public sealed class RoomsNameFilter : IRoomsFilter
	{
		string m_RoomRoomName;

		public RoomsNameFilter(string roomName)
		{
			m_RoomRoomName = roomName;
		}

		public bool FilterRoom(IRoomHandler room)
		{
			return room.Name == m_RoomRoomName;
		}
	}

	/// <summary>
	/// порождает некоторые фильтры комнат
	/// </summary>
	public static class RoomFilters
	{
		/// <summary>
		/// создает фильтр комнат по имени
		/// </summary>
		/// <param name="roomName">имя комнаты</param>
		public static IRoomsFilter Name(string roomName)
		{
			return new RoomsNameFilter(roomName);
		}
	}

	/// <summary>
	/// сервис списка комнат
	/// </summary>
	[ScriptingRoot("Rooms")]
	public interface IRoomListService
	{
		/// <summary>
		/// отображает детали определенной комнаты
		/// </summary>
		/// <param name="room">комната, на которую нужно показать детали</param>
		void ShowDetails(IRoomHandler room);

		/// <summary>
		/// возвращает комнату по е имени, или null
		/// </summary>
		/// <param name="roomName">имя комнаты</param>
		Task<IRoomHandler> GetRoomByNameAsync(string roomName);

		/// <summary>
		/// начинает поиск комнат в соответствии с фильтром
		/// </summary>
		/// <param name="filter">фильтр комнат. Если null то выводит все комнаты</param>
		/// <param name="includeFullRooms">включать ли полные комнаты</param>
		/// <param name="onlyCompatibleVersions">если истина, то возвращает только совместимые с текущей версией версии комнат</param>
		Task<GetRoomsResponce> MakeRequestAsync(IRoomsFilter filter = null, bool onlyCompatibleVersions = true, bool includeFullRooms = false);

		/// <summary>
		/// начинает поиск комнат в соответствии с фильтром
		/// </summary>
		/// <param name="filter">фильтр комнат. Если null то выводит все комнаты</param>
		/// <param name="onlyCompatibleVersions">если истина, то возвращает только совместимые с текущей версией версии комнат</param>
		/// <param name="includeFullRooms">включать ли полные комнаты</param>
		/// <param name="cancellationToken">токен отмены</param>
		Task<GetRoomsResponce> MakeRequestAsync(IRoomsFilter filter, bool onlyCompatibleVersions, bool includeFullRooms, CancellationToken cancellationToken);

		/// <summary>
		/// если нужно вывести детали определенной комнаты
		/// </summary>
		ApiEvent<IRoomHandler, IRoomListService> OnRoomDetailsRequest { get; }
	}
}