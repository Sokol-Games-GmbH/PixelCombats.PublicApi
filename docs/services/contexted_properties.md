## contextedProperties — контекстные свойства по умолчанию

Стандартные контекстные свойства для комнаты/команды/игрока.

Основное:
- `contextedProperties.GetContext().SkinType`
- `InventoryType`, `MaxHp`, `BuildSpeed`, `StartBlocksCount`

Пример:
```javascript
contextedProperties.GetContext().MaxHp.Value = 150;
Teams.Get("Blue").ContextedProperties.BuildSpeed.Value = 2; // X2
```

