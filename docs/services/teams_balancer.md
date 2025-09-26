## TeamsBalancer — авто-баланс команд

Управляет автоматическим балансом и перераспределением игроков между командами.

Частое:
- `TeamsBalancer.IsAutoBalance = true/false`
- `TeamsBalancer.BalanceTeams()` — принудительный баланс

Пример:
```javascript
TeamsBalancer.IsAutoBalance = true; // ожидание игроков
// ... перед стартом матча
TeamsBalancer.IsAutoBalance = false;
TeamsBalancer.BalanceTeams();
```

