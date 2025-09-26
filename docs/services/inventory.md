## Inventory — инвентарь

Включение/отключение типов оружия и режимов бесконечности.

Где доступен:
- Комнатный контекст: `Inventory.GetContext()`
- Командный контекст: `team.Inventory`
- Игрок: `player.Inventory`

Частые поля:
- `Main`, `Secondary`, `Melee`, `Explosive`, `Build` — включение (Value=true/false)
- `MainInfinity`, `SecondaryInfinity`, ... — бесконечные патроны
- `BuildInfinity` — бесконечные блоки

Примеры:
```javascript
// режим строительства
var inv = Inventory.GetContext();
inv.Main.Value = false;
inv.Secondary.Value = false;
inv.Melee.Value = true;
inv.Explosive.Value = false;
inv.Build.Value = true;
inv.BuildInfinity.Value = true;

// только ножи в матче
if (GameMode.Parameters.GetBool("OnlyKnives")) {
  inv.Main.Value = false;
  inv.Secondary.Value = false;
  inv.Melee.Value = true;
  inv.Explosive.Value = false;
  inv.Build.Value = true;
}
```

