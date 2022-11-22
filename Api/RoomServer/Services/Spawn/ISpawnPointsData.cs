using System.Collections.Generic;

namespace PixelCombats.Api.RoomServer.Services.Spawn
{
	/// <summary>
	/// база данных групп спавнпоинтов
	/// <para>одна такая база есть в комнате, для того, чтобы к определенной группе спавнпоинтов можно было привязать определенные контексты</para>
	/// </summary>
	public interface ISpawnPointsData : IEnumerable<ISpawnPointsGroup>
	{
		/// <summary>
		/// все группы спавнпоинтов комнаты, в которых есть хоть один спавнпоинт
		/// </summary>
		IEnumerator<ISpawnPointsGroup> GetAllSpawnPointsGroups();
		/// <summary>
		/// возвращает группу спавнпоинтов, или если такой нет то создает ее
		/// </summary>
		/// <param name="id">id группы</param>
		ISpawnPointsGroup GetGroup(uint id);
	}
}