using Godot;
using System;
using System.Runtime.Serialization;

public static class PlayerSkills
{
	// Called when the node enters the scene tree for the first time.
	/*
	setup for player skills
	skillName(Clark clark, int staminaCost, int healthCost, Enemy target = null){
	//effect code
	return damage / effect
	}
	*/

	//Factory Function
	//player, int staminaCost, enemy
	private static Func<Player, int, Enemy, int> CreateSkill(Action<Player, Enemy> effect, Func<Player, int> damageCalc)
	{
		return (player, staminaCost, enemy) =>
		{
			int damage = damageCalc(player);
			effect(player, enemy);
			// player.staminaPoints -= staminaCost;

			return damage;
		};
	}

	public static Func<Player, int, Enemy, int> attack = CreateSkill(
		(player, enemy) => { }, //effect | no return
		(player) => player.attack * 1 //damage calculation
	);

	public static Func<Player, int, Enemy, int> baconSkill = CreateSkill( //dot
		(player, enemy) => { enemy.setDamageOverTime(3, player.attack); },
		(player) => player.attack
	);

	public static Func<Player, int, Enemy, int> sandwichSkill = CreateSkill( //combo
		(player, enemy) => { },
		(player) => player.attack
	);

	public static Func<Player, int, Enemy, int> steakSkill = CreateSkill( //atk buff
		(player, enemy) => { },
		(player) => player.attack
	);
	
	//how to modify the skills :)

}


	/*
	sandwich - combo attack
	bacon - dot
	steak - atk buff

	opera - informs moves
	anime - buffs next attack
	news - debuff bosses stats (depression)

	lofi - lifesteal
	video essay - consecutive attacks do less
	stream - flat def increase
	*/