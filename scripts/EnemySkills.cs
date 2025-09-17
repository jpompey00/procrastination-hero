// using Godot;
// using System;

// public partial class EnemySkills
// {
// 	//setup for skills
// 	/*
// 	skill()
// 	*/


// 	// Called when the node enters the scene tree for the first time.
// 	private static Func<Enemy, Clark, int> CreateSkill(Action<Enemy, Clark> effect, Func<Enemy, int> damageCalc)
// 	{
// 		return (enemy, clark) =>
// 		{
// 			int damage = damageCalc(enemy);
// 			effect(enemy, clark);
// 			// clark.staminaPoints -= staminaCost;
// 			return damage;
// 		};
// 	}

// 	public static Func<Enemy, Clark, int> attack = CreateSkill(
// 		(enemy, clark) => { }, //effect | no return
// 		(enemy) => enemy.attack * 1 + 2 //damage calculation
// 	);





// }
