// разрешения
Damage.FriendlyFire = false;
BreackGraph.OnlyPlayerBlocksDmg = false;
BreackGraph.WeakBlocks = true;
// делаем возможным ломать все блоки
BreackGraph.BreackAll = true;
// показываем количество квадов
Ui.GetContext().QuadsCount.Value = true;
// разрешаем все чистые блоки
Build.GetContext().BlocksSet.Value = BuildBlocksSet.AllClear;
// вкл строительные опции
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

// запрет нанесения урона
Damage.GetContext().DamageOut.Value = false;

// параметры игры
Properties.GetContext().GameModeName.Value = "GameModes/EDITOR";
// создаем команды
red = GameMode.Parameters.GetBool("RedTeam");
blue = GameMode.Parameters.GetBool("BlueTeam");
if (red || !red && !blue) {
	Teams.Add("Red", "Teams/Red", { r: 1 });
	Teams.Get("Red").Spawns.SpawnPointsGroups.Add(2);
}
if (blue || !red && !blue) {
	Teams.Add("Blue", "Teams/Blue", { b: 1 });
	Teams.Get("Blue").Spawns.SpawnPointsGroups.Add(1);
}

// разрешаем вход в команды по запросу
Teams.OnRequestJoinTeam.Add(function(player,team){team.Add(player);});
// спавн по входу в команду
Teams.OnPlayerChangeTeam.Add(function(player){ player.Spawns.Spawn()});

// задаем подсказку
Ui.getContext().Hint.Value = "Hint/BuildBase";

// конфигурация инвентаря
var roomInventory = Inventory.GetContext();
roomInventory.Main.Value = false;
roomInventory.Secondary.Value = false;
roomInventory.Melee.Value = true;
roomInventory.Explosive.Value = false;
roomInventory.Build.Value = true;
roomInventory.BuildInfinity.Value = true;

// моментальный спавн
Spawns.GetContext().RespawnTime.Value = 0;
