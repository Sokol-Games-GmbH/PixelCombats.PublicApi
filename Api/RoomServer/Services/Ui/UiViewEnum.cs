using System;

namespace PixelCombats.Api.RoomServer.Services.Ui
{
    /// <summary>
    /// Список UI элементов игрока
    /// </summary>
    public enum UiViews
    {
        /// <summary>
        /// Джойстик
        /// </summary>
        Joystick = 1,
        /// <summary>
        /// Стрелки полета
        /// </summary>
        Fly = 2,
        /// <summary>
        /// Инвентарь
        /// </summary>
        Inventory = 3,
        /// <summary>
        /// Кнопки выбора над инвентарем
        /// </summary>
        InventoryButtons = 4,
        /// <summary>
        /// Прочие кнопки действий
        /// </summary>
        OtherButtons = 5,
        /// <summary>
        /// Пропы и кнопка для выхода в команды вверху
        /// </summary>
        PropsBuild = 6
    }
}