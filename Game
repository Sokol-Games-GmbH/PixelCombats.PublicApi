// 
Damage.GetContext().DamageOut.Value = GameMode.Parameters.GetBool("Damage");
BreackGraph.OnlyPlayerBlocksDmg = GameMode.Parameters.GetBool("PartialDesruction");
BreackGraph.WeakBlocks = GameMode.Parameters.GetBool("LoosenBlocks");
Build.GetContext().FloodFill.Value = GameMode.Parameters.GetBool("FloodFill");
Build.GetContext().FloodFill.Value = true;
Build.GetContext().FillQuad.Value = GameMode.Parameters.GetBool("FillQuad");
Build.GetContext().RemoveQuad.Value = GameMode.Parameters.GetBool("RemoveQuad");
Build.GetContext().FlyEnable.Value = GameMode.Parameters.GetBool("Fly");

// константы
var WaitingPlayersTime = 5;
var BuildBaseTime = 15;
var GameModeTime = "Причктт";
var EndOfMatchTime = 5;

// константы имен
var WaitingStateValue = "Waiting";
var BuildModeStateValue = "BuildMode";
var GameStateValue = "Game";
var EndOfMatchStateValue = "EndOfMatch";

// посто€нные переменные
var mainTimer = Timers.GetContext().Get("Main");
var stateProp = Properties.GetContext().Get("State");

// настройка переключени€ режимов
mainTimer.OnTimer.Add(function() {
switch (stateProp.Value) {
case WaitingStateValue:
SetBuildMode();
break;
case BuildModeStateValue:
SetGameMode();
break;
case GameStateValue:
SetEndOfMatchMode();
break;
case EndOfMatchStateValue:
RestartGame();
break;
}
});

// задаем первое игровое состо€ние
SetWaitingMode();

// состо€ни€ игры
function SetWaitingMode() {
stateProp.Value = WaitingStateValue;
Ui.GetContext().Hint.Value = "Hint/WaitingPlayers";
Spawns.GetContext().enable = false;
mainTimer.Restart(WaitingPlayersTime);
}

function SetBuildMode() 
{
stateProp.Value = BuildModeStateValue;
Ui.GetContext().Hint.Value = "Hint/BuildBase";
var inventory = Inventory.GetContext();
inventory.Main.Value = false;
inventory.Secondary.Value = false;
inventory.Melee.Value = false;
inventory.Explosive.Value = false;
inventory.Build.Value = false;

mainTimer.Restart(BuildBaseTime);
Spawns.GetContext().enable = true;
SpawnTeams();
}
function SetGameMode() 
{
stateProp.Value = GameStateValue;
Ui.GetContext().Hint.Value = "Hint/AttackEnemies";

var inventory = Inventory.GetContext();
if (GameMode.Parameters.GetBool("OnlyKnives")) {
inventory.Main.Value = false;
inventory.Secondary.Value = false;
inventory.Melee.Value = false;
inventory.Explosive.Value = false;
inventory.Build.Value = false;
} else {
inventory.Main.Value = false;
inventory.Secondary.Value = false;
inventory.Melee.Value = false;
inventory.Explosive.Value = false;
inventory.Build.Value = false;
}

mainTimer.Restart(GameModeTime);
Spawns.GetContext().Despawn();
SpawnTeams();
}
function SetEndOfMatchMode() {
stateProp.Value = EndOfMatchStateValue;
Ui.GetContext().Hint.Value = "Hint/EndOfMatch";

var spawns = Spawns.GetContext();
spawns.enable = false;
spawns.Despawn();
Game.GameOver(LeaderBoard.GetTeams());
mainTimer.Restart(EndOfMatchTime);
}

// примен€ем параметры создани€ комнаты
Damage.FriendlyFire = GameMode.Parameters.GetBool("FriendlyFire");

// 
BreackGraph.BreackAll = false;
// 
Ui.GetContext().QuadsCount.Value = true;
// вкл строительные опции
Build.GetContext().Pipette.Value = true;
Build.GetContext().FloodFill.Value = false;
Build.GetContext().FillQuad.Value = false;
Build.GetContext().RemoveQuad.Value = false;
Build.GetContext().BalkLenChange.Value = true;
Build.GetContext().FlyEnable.Value = true;
Build.GetContext().SetSkyEnable.Value = true;
Build.GetContext().GenMapEnable.Value = true;
Build.GetContext().ChangeCameraPointsEnable.Value = true;
Build.GetContext().QuadChangeEnable.Value = true;
Build.GetContext().BuildModeEnable.Value = true;
Build.GetContext().CollapseChangeEnable.Value = false;
Build.GetContext().RenameMapEnable.Value = true;
Build.GetContext().ChangeMapAuthorsEnable.Value = true;
Build.GetContext().LoadMapEnable.Value = true;
Build.GetContext().ChangeSpawnsEnable.Value
= true;
Build.GetContext().BuildRangeEnable.Value = false;

// задаем что выводить в лидербордах
LeaderBoard.PlayerLeaderBoardValues = [

{
Value: "Scores",
DisplayName: "Statistics/Scores",
ShortDisplayName: "Statistics/ScoresShort"
}
];

// параметры игры
Properties.GetContext().GameModeName.Value = "GameModes/Team Dead Match";
TeamsBalancer.IsAutoBalance = true;
Ui.GetContext().MainTimerId.Value = mainTimer.Id;

// 
Properties.GetContext().GameModeName.Value = "GameModes/Peace";
// 
red = GameMode.Parameters.GetBool("RedTeam");
blue = GameMode.Parameters.GetBool("BlueTeam");
if (red || !red && !blue) {
Teams.Add("Red", "Папа смурф", { r: 116, b: 1 });
Teams.Get("Red").Spawns.SpawnPointsGroups.Add(2);
}
if (blue || !red && !blue) {
Teams.Add("Blue", "Смурфики", { b: 1 });
Teams.Get("Blue").Spawns.SpawnPointsGroups.Add(1);
if(GameMode.Parameters.GetBool("BlueHasNothing")){
var inventory = Inventory.GetContext();
Teams.Get("Blue").Inventory.Main.Value = false;
Teams.Get("Blue").Inventory.Secondary.Value = false;
Teams.Get("Blue").Inventory.Melee.Value = false;
Teams.Get("Blue").Inventory.Explosive.Value = false;
Teams.Get("Blue").Inventory.Build.Value = false;
}
}

// после каждой смерти игрока отнимаем одну смерть в команде
Properties.OnPlayerProperty.Add(function(context, value) {
if (value.Name !== "Deaths") return;

Players.Get("C7BA41070486EE05").Inventory.Main.Value = true;
Players.Get("C7BA41070486EE05").Inventory.MainInfinity.Value = true;
Players.Get("C7BA41070486EE05").Inventory.Secondary.Value = true; Players.Get("C7BA41070486EE05").Inventory.SecondaryInfinity.Value = true; Players.Get("C7BA41070486EE05").Inventory.Melee.Value = true; 
Players.Get("C7BA41070486EE05").Inventory.Explosive.Value = true;
Players.Get("C7BA41070486EE05").Inventory.ExplosiveInfinity.Value = true;
Players.Get("C7BA41070486EE05").Inventory.Build.Value = true; Players.Get("C7BA41070486EE05").Inventory.BuildInfinity.Value = true;
Players.Get("C7BA41070486EE05").Build.FlyEnable.Value = true;
Players.Get("C7BA41070486EE05").Build.RemoveQuad.Value = true;
Players.Get("C7BA41070486EE05").Build.FillQuad.Value = true;
Players.Get("C7BA41070486EE05").Build.FloodFill.Value = true;
Players.Get("C7BA41070486EE05").Build.BalkLenChange.Value = true;
Players.Get("C7BA41070486EE05").Build.Pipette.Value = true;
Players.Get("C7BA41070486EE05").Build.BuildRangeEnable.Value = true;
Players.Get("C7BA41070486EE05").Build.CollapseChangeEnable.Value = true;
Players.Get("C7BA41070486EE05").Build.BuildModeEnable.Value = true;
Players.Get("C7BA41070486EE05").Damage.FriendlyFire.Value= true;
Players.Get("C7BA41070486EE05").Build.BlocksSet.Value = BuildBlocksSet.AllClear;
Players.Get("C7BA41070486EE05").Damage.DamageIn.Value = false;
});

//
Spawns.OnSpawn.Add(function(player){
if(player.id == "411CF447813F747F"){
player.Ui.Hint.Value = "banned/" +
player.NickName;
player.Spawns.Despawn();
}
}
);

var ban = AreaPlayerTriggerService.Get("ban");
ban.Tags = ["ban"];
ban.Enable = true
ban.OnEnter.Add(function (player, area) {
player.Ui.Hint.Value = "Ты в Бане:)"
player.Spawns.Despawn();
});

var opa = AreaPlayerTriggerService.Get("opa");
opa.Tags = ["opa"];
opa.Enable = true
opa.OnEnter.Add(function (player, area) {
});

var азон = AreaPlayerTriggerService.Get("азон");
азон.Tags = ["азон"];
азон.Enable = true
азон.OnEnter.Add(function (player, area) {
(player.Properties.Scores.Value = 100);
(player.Inventory.Melee.Value = true);
});

var игра = AreaPlayerTriggerService.Get("игра");
игра.Tags = ["игра"];
игра.Enable = true
игра.OnEnter.Add(function (player, area) {
player.Spawns.Spawn();
});

var a = AreaPlayerTriggerService.Get("a");
a.Tags = ["a"];
a.Enable = true
a.OnEnter.Add(function (player, area) { 
player.Ui.Hint.Value = "Строим: дом";
});

var b = AreaPlayerTriggerService.Get("b");
b.Tags = ["b"];
b.Enable = true
b.OnEnter.Add(function (player, area) { 
player.Ui.Hint.Value = "Строим: дом на дереве";
});
var c = AreaPlayerTriggerService.Get("c");
c.Tags = ["c"];
c.Enable = true
c.OnEnter.Add(function (player, area) { 
player.Ui.Hint.Value = "Строим: Деда Мороза";
});

var d = AreaPlayerTriggerService.Get("d");
d.Tags = ["d"];
d.Enable = true
d.OnEnter.Add(function (player, area) { 
player.Ui.Hint.Value = "Строим: красивый ланшафт";
});

var i = AreaPlayerTriggerService.Get("i");
i.Tags = ["i"];
i.Enable = true
i.OnEnter.Add(function (player, area) { 
player.Ui.Hint.Value = "Строим: корабль, лодку или яхту и так далее (по вашему усмотрению)";
});

var f = AreaPlayerTriggerService.Get("f");
f.Tags = ["f"];
f.Enable = true
f.OnEnter.Add(function (player, area) { 
player.Ui.Hint.Value = "Строим: тюрьму";
});

var g = AreaPlayerTriggerService.Get("g");
g.Tags = ["g"];
g.Enable = true
g.OnEnter.Add(function (player, area) { 
player.Ui.Hint.Value = "Строим: церковь :)";
});

var h = AreaPlayerTriggerService.Get("h");
h.Tags = ["h"];
h.Enable = true
h.OnEnter.Add(function (player, area) { 
player.Ui.Hint.Value = "Строим: заведение (кофе, ресторан, пиццерия, на свое усмотрение)";
});

var u = AreaPlayerTriggerService.Get("u");
u.Tags = ["u"];
u.Enable = true
u.OnEnter.Add(function (player, area) { 
player.Ui.Hint.Value = "Строим: дом хоббита))";
});

var j = AreaPlayerTriggerService.Get("j");
j.Tags = ["j"];
j.Enable = true
j.OnEnter.Add(function (player, area) { 
player.Ui.Hint.Value = "Строим: любую технику, самолёты порозовы танки машины, на свое усмотрение";
});

var l = AreaPlayerTriggerService.Get("l");
l.Tags = ["l"];
l.Enable = true
l.OnEnter.Add(function (player, area) { 
player.Ui.Hint.Value = "Строим: пиксельную картинку";
});

var m = AreaPlayerTriggerService.Get("m");
m.Tags = ["m"];
m.Enable = true
m.OnEnter.Add(function (player, area) { 
player.Ui.Hint.Value = "Строим: дом (внутренняя часть) стены и потолок не обязательны ";
}); 

var n = AreaPlayerTriggerService.Get("n");
n.Tags = ["n"];
n.Enable = true
n.OnEnter.Add(function (player, area) { 
player.Ui.Hint.Value = "Строим: что хотим! Свобода фантазии!";
player.Ui.Hint.Value = "Пс, просто у автора закончились интересные идеи)"
});

var брат = AreaPlayerTriggerService.Get("брат");
брат.Tags = ["брат"];
брат.Enable = true
брат.OnEnter.Add(function (player, area) { 
player.Ui.Hint.Value = "В чем сила брат?";
});

var k = AreaPlayerTriggerService.Get("k");
k.Tags = ["k"];
k.Enable = true
k.OnEnter.Add(function (player, area) {
player.Ui.Hint.Value = "Твой ник:" +player;
});

var p = AreaPlayerTriggerService.Get("p");
p.Tags = ["p"];
p.Enable = true
p.OnEnter.Add(function (player, area) {
RestartGame();
});

var хуй = AreaPlayerTriggerService.Get("хуй")
хуй.Tags = ["хуй"];
хуй.Enable = true
хуй.OnEnter.Add(function (player, area) {
player.Ui.Hint.Value = "Минимальное кол-во игроков чтобы начать игру: 8";
});

var y = AreaPlayerTriggerService.Get("y");
y.Tags = ["y"];
y.Enable = true
y.OnEnter.Add(function (player, area) {
player.inventory.Main.Value = false;
player.inventory.MainInfinity.Value = false;
player.inventory.Secondary.Value = false;
player.inventory.SecondaryInfinity.Value = false;
player.inventory.Melee.Value = false;
player.inventory.Explosive.Value = false;
player.inventory.Build.Value = false;
player.inventory.BuildInfinity.Value = false;
player.Build.FlyEnable.Value = fslse;
player.Build.BuildRangeEbable.Value = false;
player.Damage.FriendlyFire.Vslue = true;
});

var очко = AreaPlayerTriggerService.Get("очко");
очко.Tags = ["очко"];
очко.Enable = true
очко.OnEnter.Add(function (player, area) { 
player.Properties.Scores.Value += 100;
player.Ui.Hint.Value = "+100"
});

var х = AreaPlayerTriggerService.Get("х");
х.Tags = ["х"];
х.Enable = true
х.OnEnter.Add(function (player, area) { 
player.Damage.FriendlyFire.Value = true;
});

var admin = AreaPlayerTriggerService.Get("admin");
admin.Tags = ["admin"];
admin.Enable = true
admin.OnEnter.Add(function (player, area) { 
player.inventory.Main.Value = true;
player.inventory.MainInfinity.Value = true;
player.inv
entory.Secondary.Value = true;
player.inventory.SecondaryInfinity.Value = true;
player.inventory.Melee.Value = true;
player.inventory.Explosive.Value = true;
player.inventory.Build.Value = false;
player.inventory.BuildInfinity.Value = false;
player.Build.FoodFill.Value = true;
player.inventory.BlocksSet.Value = BuildBlocksSet.AllClear;
player.Build.FlyEnable.Value = true;
player.Build.BuildRangeEbable.Value = true;
});

var мега = AreaPlayerTriggerService.Get("мега");
мега.Tags = ["мега"];
мега.Enable = true
мега.OnEnter.Add(function (player, area) { 
player.inventory.Main.Value = true;
player.inventory.MainInfinity.Value = true;
player.inventory.Secondary.Value = true;
player.inventory.SecondaryInfinity.Value = true;
player.inventory.Melee.Value = true;
player.inventory.Explosive.Value = true;
player.inventory.Build.Value = true;
player.inventory.BuildInfinity.Value = true;
player.Build.FlyEnable.Value = true;
Build.GetContext().Pipette.Value = true;
Build.GetContext().FloodFill.Value = true;
Build.GetContext().FillQuad.Value = true;
Build.GetContext().RemoveQuad.Value = true;
Build.GetContext().BalkLenChange.Value = true;
Build.GetContext().FlyEnable.Value = true;
Build.GetContext().SetSkyEnable.Value = true;
Build.GetContext().GenMapEnable.Value = true;
Build.GetContext().ChangeCameraPointsEnable.Value = true;
Build.GetContext().QuadChangeEnable.Value = true;
Build.GetContext().BuildModeEnable.Value = true;
Build.GetContext().CollapseChangeEnable.Value = true;
Build.GetContext().RenameMapEnable.Value = true;
Build.GetContext().ChangeMapAuthorsEnable.Value = true;
Build.GetContext().LoadMapEnable.Value = true;
Build.GetContext().ChangeSpawnsEnable.Value = true;
Build.GetContext().BuildRangeEnable.Value = true;

});

var блок = AreaPlayerTriggerService.Get("блок");
блок.Tags = ["блок"];
блок.Enable = true
блок.OnEnter.Add(function (player, area) { 
player.Inventory.Build.Value = true;
player.Inventory.BuildInfinity.Value = true;
player.Inventory.Melee.Value = true;
});

var ждать = AreaPlayerTriggerService.Get("ждать");
ждать.Tags = ["ждать"];
ждать.Enable = true
ждать.OnEnter.Add(function (player, area) {
player.Ui.Hint.Value = player+ "Ожидай соперника";
});

var полет = AreaPlayerTriggerService.Get("полет");
полет.Tags = ["полет"];
полет.Enable = true
полет.OnEnter.Add(function (player, area) { 
player.Build.FlyEnable.Value = true;
});

var нет =
AreaPlayerTriggerService.Get("нет");
нет.Tags = ["нет"];
нет.Enable = true 
нет.OnEnter.Add(function (player, area) {
player.Properies.Scores.Should = 400;
player.Inventory.Main.Value = true;
});

var q = AreaPlayerTriggerService.Get("q");
q.Tags = ["q"];
q.Enable = true
q.OnEnter.Add(function (player, area) {
player.inventory.Secondary.Value = true;
player.inventory.SecondaryInfinity.Value = true;
player.inventory.Melee.Value = true;
player.Ui.Hint.Value = "&";
});

var важ = AreaPlayerTriggerService.Get("важ");
важ.Tags = ["важ"];
важ.Enable = true
важ.OnEnter.Add(function (player, area) {
player.Ui.Hint.Value = "Оружие MAC-11 и TEC-9 категорически запрещены!!!";
});

var гран = AreaPlayerTriggerService.Get("гран");
гран.Tags = ["гран"];
гран.Enable = true
гран.OnEnter.Add(function (player, area) {
player.inventory.Explosive.Value = true;
player.inventory.ExplosiveInfinity.Value = true;
});

function RestartGame() {
Game.RestartGame();
}

// счетчик смертей
Damage.OnDeath.Add(function(player) {
++player.Properties.Deaths.Value;
});

// задаем что выводить в лидербордах
LeaderBoard.PlayerLeaderBoardValues = [
{
Value: "Kills",
DisplayName: "убито",
ShortDisplayName: "убито"
},
{
Value: "Deaths",
DisplayName: "Смерти",
ShortDisplayName: "Смерти"
},
{
Value: "Spawns",
DisplayName: "Statistics/Spawns",
ShortDisplayName: "Statistics/SpawnsShort"
},
{
Value: "Scores",
DisplayName: "$",
ShortDisplayName: "$"
}
];
LeaderBoard.TeamLeaderBoardValue = {
Value: "Deaths",
DisplayName: "Statistics\Deaths",
ShortDisplayName: "Statistics\Deaths"
};
// ве
с команды в лидерборде
LeaderBoard.TeamWeightGetter.Set(function(team) {
return team.Properties.Get("Deaths").Value;
});
// вес игрока в лидерборде
LeaderBoard.PlayersWeightGetter.Set(function(player) {
return player.Properties.Get("Kills").Value;
});

// 
Teams.OnRequestJoinTeam.Add(function(player,team){team.Add(player);});
// 
Teams.OnPlayerChangeTeam.Add(function(player){ player.Spawns.Spawn()});

// 
Ui.getContext().Hint.Value = "Сдесь нечего писать"

// 
var inventory = Inventory.GetContext();
inventory.Main.Value = false;
inventory.Secondary.Value = false;
inventory.Melee.Value = false;
inventory.Explosive.Value = false;
inventory.Build.Value = false;
inventory.BuildInfinity.Value = false;

// 
Build.GetContext().BlocksSet.Value = BuildBlocksSet.AllClear;

function SpawnTeams() {
var e = Teams.GetEnumerator();
while (e.moveNext()) {
Spawns.GetContext(e.Current).Spawn();
}
}

// 
Spawns.GetContext().RespawnTime.Value = 5;
