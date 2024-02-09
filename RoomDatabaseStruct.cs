/// <summary>
/// Основная структура опции для наследования
/// </summary>
private struct MainOption<T>
{
    public string Name { get; set; }
    public T DefaultValue { get; set; }
}

/// <summary>
/// Приватная структура параметра Client
/// <para>Обозначает базу данных для игрока</para>
/// </summary>
private struct ClientOption : MainOption
    { }

/// <summary>
/// Структура базы данных режима
/// </summary>
public struct RoomDatabaseStruct
{
    ClientOption[] Client { get; set; }
    MainOption[] Room { get; set; }
}
