// константы
var MaxScores = 6;
var WaitingModeSeconts = 10;
var BuildModeSeconds = 30;
var GameModeSeconds = 120;
var EndGameSeconds = 5;
var EndOfMatchTime = 10;

// константы имен
var WaitingStateValue = "Waiting";
var BuildModeStateValue = "BuildMode";
var GameStateValue = "Game";
var EndOfGameStateValue = "EndOfGame";
var EndOfMatchStateValue = "EndOfMatch";
var scoresProp = "Scores";

// постоянные переменные
var mainTimer = Timers.GetContext().Get("Main");
var stateProp = Properties.GetContext().Get("State");
var winTeamIdProp = Properties.GetContext().Get("WinTeam");

// применяем параметры создания комнаты
Damage.GetContext().FriendlyFire.Value = GameMode.Parameters.GetBool("FriendlyFire");
Map.Rotation = GameMode.Parameters.GetBool("MapRotation");
BreackGraph.OnlyPlayerBlocksDmg = GameMode.Parameters.GetBool("PartialDesruction");
BreackGraph.WeakBlocks = GameMode.Parameters.GetBool("LoosenBlocks");

// блок игрока всегда усилен
BreackGraph.PlayerBlockBoost = true;

// выключаем урон гранаты при касании
Damage.GetContext().GranadeTouchExplosion.Value = false;

// параметры игры
Properties.GetContext().GameModeName.Value = "GameModes/Team Dead Match";
TeamsBalancer.IsAutoBalance = true; // вкл автобаланс до начала катки
Ui.GetContext().MainTimerId.Value = mainTimer.Id;
// создаем команды
Teams.Add("Blue", "Teams/Blue", { b: 1 });
Teams.Add("Red", "Teams/Red", { r: 1 });
Teams.Get("Blue").Spawns.SpawnPointsGroups.Add(1);
Teams.Get("Red").Spawns.SpawnPointsGroups.Add(2);
Teams.Get("Red").Build.BlocksSet.Value = BuildBlocksSet.Red;
Teams.Get("Blue").Build.BlocksSet.Value = BuildBlocksSet.Blue;

// задаем что выводить в лидербордах
LeaderBoard.PlayerLeaderBoardValues = [
	{
		Value: "Kills",
		DisplayName: "Statistics/Kills",
		ShortDisplayName: "Statistics/KillsShort"
	},
	{
		Value: "Deaths",
		DisplayName: "Statistics/Deaths",
		ShortDisplayName: "Statistics/\DeathsShort"
	},
	{
		Value: "Scores",
		DisplayName: "Statistics/Scores",
		ShortDisplayName: "Statistics/ScoresShort"
	}
];
LeaderBoard.TeamLeaderBoardValue = {
	Value: scoresProp,
	DisplayName: "Statistics\Scores",
	ShortDisplayName: "Statistics\ScoresShort"
};
// вес команды в лидерборде
LeaderBoard.TeamWeightGetter.Set(function(team) {
	var prop = team.Properties.Get(scoresProp);
	if (prop.Value == null) return 0;
	return prop.Value;
});
// вес игрока в лидерборде
LeaderBoard.PlayersWeightGetter.Set(function(player) {
	var prop = player.Properties.Get("Scores");
	if (prop.Value == null) return 0;
	return prop.Value;
});

// задаем что выводить вверху
Ui.GetContext().TeamProp1.Value = { Team: "Blue", Prop: scoresProp };
Ui.GetContext().TeamProp2.Value = { Team: "Red", Prop: scoresProp };

// выводим 0 вверху
for (e = Teams.GetEnumerator(); e.MoveNext();) {
	e.Current.Properties.Get(scoresProp).Value= 0;
}

// разрешаем вход в команды по запросу
Teams.OnRequestJoinTeam.Add(function(player,team){team.Add(player);});
// спавн по входу в команду
Teams.OnPlayerChangeTeam.Add(function(player) {
	//if (stateProp.value === GameStateValue) 
	//	return;
	player.Spawns.Spawn();
});

// счетчик смертей
Damage.OnDeath.Add(function(player) {
	++player.Properties.Deaths.Value;
});
// счетчик убийств
Damage.OnKill.Add(function(player, killed) {
	if (killed.Team != null && killed.Team != player.Team) {
		++player.Properties.Kills.Value;
		player.Properties.Scores.Value += 100;
	}
});

// проверяем выигрыш команды
function GetWinTeam(){
	winTeam = null;
	wins = 0;
	noAlife = true;
	for (e = Teams.GetEnumerator(); e.MoveNext();) {
		if (e.Current.GetAlivePlayersCount() > 0) {
			++wins;
			winTeam = e.Current;
		}
	}
	if (wins === 1) return winTeam;
	else return null;
}
function TrySwitchGameState() // попытка переключения из геймстейта
{
	if (stateProp.value !== GameStateValue) 
		return;

	// анализ команд
	winTeam = null;
	wins = 0;
	alifeCount = 0;
	hasEmptyTeam = false;
	for (e = Teams.GetEnumerator(); e.MoveNext();) {
		var alife = e.Current.GetAlivePlayersCount();
		alifeCount += alife;
		if (alife > 0) {
			++wins;
			winTeam = e.Current;
		}
		if (e.Current.Count == 0) hasEmptyTeam = true;
	}

	// есть победившая команда
	if (!hasEmptyTeam && alifeCount > 0 && wins === 1) {
		log.debug("hasEmptyTeam=" + hasEmptyTeam);
		log.debug("alifeCount=" + alifeCount);
		log.debug("wins=" + wins);
		winTeamIdProp.Value = winTeam.Id;
		StartEndOfGame(winTeam);
		return;
	}

	// победивших нет и живых не осталось - ничья
	if (alifeCount == 0) {
		log.debug("победивших нет и живых не осталось - ничья");
		winTeamIdProp.Value = null;
		StartEndOfGame(null);
	}

	// победивших нет и основной таймер закончен - ничья
	if (!mainTimer.IsStarted) {
		log.debug("победивших нет и таймер не активен - ничья");
		winTeamIdProp.Value = null;
		StartEndOfGame(null);
	}
}
function OnGameStateTimer() // проверка выигрыша гейма
{
	TrySwitchGameState();
}
Damage.OnDeath.Add(TrySwitchGameState);
Players.OnPlayerDisconnected.Add(TrySwitchGameState);

// настройка переключения режимов
mainTimer.OnTimer.Add(function() {
	switch (stateProp.value) {
	case WaitingStateValue:
		SetBuildMode();
		break;
	case BuildModeStateValue:
		SetGameMode();
		break;
	case GameStateValue:
		OnGameStateTimer();
		break;
	case EndOfGameStateValue:
		EndEndOfGame();
		break;
	case EndOfMatchStateValue:
		RestartGame();
		break;
	}
});

// задаем первое игровое состояние
SetWaitingMode();

// состояния игры
function SetWaitingMode() { // состояние ожидания других игроков
	stateProp.value = WaitingStateValue;
	Ui.GetContext().Hint.Value = "Hint/WaitingPlayers";
	Spawns.GetContext().enable = false;
	TeamsBalancer.IsAutoBalance = true;
	mainTimer.Restart(WaitingModeSeconts);
}

function SetBuildMode() 
{
	stateProp.value = BuildModeStateValue;
	Ui.GetContext().Hint.Value = "Hint/BuildBase";

	var inventory = Inventory.GetContext();
	inventory.Main.Value = false;
	inventory.Secondary.Value = false;
	inventory.Melee.Value = true;
	inventory.Explosive.Value = false;
	inventory.Build.Value = true;

	mainTimer.Restart(BuildModeSeconds);
	Spawns.GetContext().enable = true;
	TeamsBalancer.IsAutoBalance = true; // вкл автобаланс до начала катки
	SpawnTeams();
}
function SetGameMode() 
{
	stateProp.value = GameStateValue;
	Ui.GetContext().Hint.Value = "Hint/AttackEnemies";
	winTeamIdProp.Value = null; // никто не выиграл

	var inventory = Inventory.GetContext();
	if (GameMode.Parameters.GetBool("OnlyKnives")) {
		inventory.Main.Value = false;
		inventory.Secondary.Value = false;
		inventory.Melee.Value = true;
		inventory.Explosive.Value = false;
		inventory.Build.Value = true;
	} else {
		inventory.Main.Value = true;
		inventory.Secondary.Value = true;
		inventory.Melee.Value = true;
		inventory.Explosive.Value = true;
		inventory.Build.Value = true;
	}

	mainTimer.Restart(GameModeSeconds);
	Spawns.GetContext().Despawn();
	Spawns.GetContext().RespawnEnable = false;
	TeamsBalancer.IsAutoBalance = false;
	TeamsBalancer.BalanceTeams();
	SpawnTeams();
}

function StartEndOfGame(team) { // team=null то ничья
	log.debug("win team="+team);
	stateProp.value = EndOfGameStateValue;
	if (team !== null) {
		log.debug(1);
		Ui.GetContext().Hint.Value = team + " wins!";
		 var prop = team.Properties.Get(scoresProp);
		 if (prop.Value == null) prop.Value = 1;
		 else prop.Value = prop.Value + 1;
	}
	else Ui.GetContext().Hint.Value = "Hint/Draw";

	mainTimer.Restart(EndGameSeconds);
}
function EndEndOfGame(){// конец конца матча
	if (winTeamIdProp.Value !== null) {
		var team = Teams.Get(winTeamIdProp.Value);
		var prop = team.Properties.Get(scoresProp);
		if (prop.Value >= MaxScores) SetEndOfMatchMode();
		else SetGameMode();
	}
	else SetGameMode();
}

function SetEndOfMatchMode() {
	stateProp.value = EndOfMatchStateValue;
	Ui.GetContext().Hint.Value = "Hint/EndOfMatch";

	var context = Spawns.GetContext();
	context.enable = false;
	context.Despawn();
	Game.GameOver(LeaderBoard.GetTeams());
	mainTimer.Restart(EndOfMatchTime);
}
function RestartGame() {
	Game.RestartGame();
}

function SpawnTeams() {
	var e = Teams.GetEnumerator();
	while (e.moveNext()) {
		Spawns.GetContext(e.Current).Spawn();
	}
}
