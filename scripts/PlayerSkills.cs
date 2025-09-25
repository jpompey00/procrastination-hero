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
	//each skill will need a type associated with it.
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
		(player) => player.attack.currentValue //damage calculation
	);

	public static Func<Player, int, Enemy, int> baconSkill = CreateSkill( //dot
		(player, enemy) => { enemy.setDamageOverTime(3, player.attack.currentValue); },
		(player) => player.attack.currentValue
	);

	public static Func<Player, int, Enemy, int> sandwichSkill = CreateSkill( //combo
		(player, enemy) =>
		{
			player.state = Constants.State.COMBO;
			player.combo = new Combo(
				(player, enemy) => { }, // combo effect
				3 //combo turns
			);
		},
		(player) => { return 0; }

	);

	public static Func<Player, int, Enemy, int> steakSkill = CreateSkill( //atk buff
		(player, enemy) => { },
		(player) => player.attack.currentValue
	);



	/*
	May use a factory function with a state keeping parameter like "state"?
	plan it out for each skill mayhaps. 
	*/
	private static Func<Player, int, Enemy, int> CreateSkill(Action<Player, Enemy> effect, Func<Player, int> damageCalc, int state)
	{
		if (state == 1)
		{
			return (player, staminaCost, enemy) =>
			{
				int damage = damageCalc(player);
				effect(player, enemy);
				// player.staminaPoints -= staminaCost;

				return damage;
			};


		}
		else if (state == 2)
		{
			return null;
		}
		return null;

	}
	
	public static Func<Player, int, Enemy, int> testState = CreateSkill(
		(player, enemy) => { },
		(player) => player.attack.currentValue,
		1
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