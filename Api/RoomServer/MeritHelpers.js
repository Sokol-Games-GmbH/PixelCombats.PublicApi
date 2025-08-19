/* MeritHelpers.js v1.0
 * Общая библиотека расчетов системы заслуг (Merit System v5)
 * Источник чисел: согласно предоставленным формулам и таблицам
 */

var MeritHelpers = {
	// weaponId → category (минимальный набор; будет расширяться)
	WEAPON_CATEGORIES: {
		1: "pistol",  // Beretta
		2: "rifle",   // AK-47
		3: "pistol",  // Desert Eagle
		4: "lmg",     // M249SAW
		6: "melee",   // Military Shovel
		7: "shotgun", // Shotgun
		9: "smg",     // MP5
		10: "grenade",// Grenade
		11: "melee",  // M9 Bayonet
		12: "melee",  // Knife
		13: "sniper", // M24
		14: "rifle",  // M4A1
		18: "sniper", // AWP
		20: "sniper"  // AWP (дубликат)
	},

	// очки по категориям
	CATEGORY_SCORES: {
		"sniper":   { head: 240, body: 144, assist: 60 },
		"rifle":    { head: 150, body: 96,  assist: 60 },
		"pistol":   { head: 168, body: 108, assist: 60 },
		"shotgun":  { head: 162, body: 114, assist: 60 },
		"lmg":      { head: 138, body: 90,  assist: 60 },
		"smg":      { head: 156, body: 102, assist: 60 },
		"melee":    { head: 180, body: 120, assist: 60 },
		"grenade":  { head: 144, body: 144, assist: 60 }
	},

	// модификаторы карт
	MAP_MODIFIERS: {
		"Length_S": 0.8,
		"Length_M": 1.0,
		"Length_L": 1.2,
		"Length_XL": 1.4
	},

	calculateKillScore: function(weaponId, isHeadshot, mapSize) {
		const category = this.WEAPON_CATEGORIES[weaponId] || "rifle";
		const scores = this.CATEGORY_SCORES[category] || this.CATEGORY_SCORES["rifle"];
		const base = isHeadshot ? scores.head : scores.body;
		const modifier = this.MAP_MODIFIERS[mapSize] || 1.0;
		return Math.round(base * modifier);
	},

	calculateAssistScore: function(mapSize) {
		const modifier = this.MAP_MODIFIERS[mapSize] || 1.0;
		return Math.round(60 * modifier);
	},

	calculateTimeScore: function(mapSize, timeInterval) {
		const modifier = this.MAP_MODIFIERS[mapSize] || 1.0;
		return Math.round(10 * modifier);
	},

	createAssistTracker: function(timeWindowMs = 10000, minDamage = 20) {
		const tracker = new Map(); // victimId -> [ {id, player, damage, time} ]
		return {
			recordDamage: function(attacker, victim, damage, weaponId) {
				if (!attacker || !victim) return;
				const now = Date.now();
				const victimId = victim.Id;
				if (!tracker.has(victimId)) tracker.set(victimId, []);
				const arr = tracker.get(victimId);
				for (let i = arr.length - 1; i >= 0; i--) {
					if (now - arr[i].time > timeWindowMs) arr.splice(i, 1);
				}
				let rec = arr.find(a => a.id === attacker.Id);
				if (rec) { rec.damage += damage; rec.time = now; rec.weaponId = weaponId; }
				else if (arr.length < 5) arr.push({ id: attacker.Id, player: attacker, damage: damage, time: now, weaponId: weaponId });
			},
			getAssisters: function(victim, killer) {
				const arr = tracker.get(victim.Id) || [];
				return arr.filter(a => a.id !== killer.Id && a.damage >= minDamage);
			},
			clearVictim: function(victim) { tracker.delete(victim.Id); }
		};
	},

	getCurrentWeaponId: function(player) {
		// 1) предпочтительно: читать из свойств игрока (устанавливается мостиком при попадании)
		try {
			const prop = player?.Properties?.Get?.("LastWeaponId");
			if (prop && typeof prop.Value === 'number') return prop.Value;
		} catch(e) {}
		// 2) запасной вариант: из инвентаря
		try { return player?.Inventory?.CurrentWeapon?.Id ?? 0; } catch (e) { return 0; }
	},
	getLastHitWasHeadshot: function(victim) {
		// 1) предпочтительно: читать флаг из свойств жертвы, установленный мостиком
		try {
			const prop = victim?.Properties?.Get?.("LastHitWasHeadshot");
			if (prop && typeof prop.Value === 'boolean') return prop.Value === true;
		} catch(e) {}
		return false;
	}
};

export { MeritHelpers };
