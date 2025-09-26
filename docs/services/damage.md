## Damage — урон и события боя

Управление параметрами урона и обработка событий убийств/смертей.

Полезные свойства:
- `Damage.FriendlyFire` или `Damage.GetContext().FriendlyFire.Value` — урон по своим
- `BreackGraph.OnlyPlayerBlocksDmg` — ломаются только пользовательские блоки
- `BreackGraph.WeakBlocks` — ослабленные блоки

События:
- `Damage.OnDeath.Add(function(player) { ... })`
- `Damage.OnKill.Add(function(killer, killed) { ... })`

Примеры:
```javascript
// запрет урона в редакторе
Damage.GetContext().DamageOut.Value = false;

// подсчёт статистики
Damage.OnDeath.Add(function(player) { ++player.Properties.Deaths.Value; });
Damage.OnKill.Add(function(player, killed) {
  if (killed.Team && killed.Team !== player.Team) {
    ++player.Properties.Kills.Value;
    player.Properties.Scores.Value += 100;
  }
});
```

