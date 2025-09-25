using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

public partial class Player : CharacterBody2D
{
	//make a model for battling and a model for the exploration.
	public Stat attack = new Stat();
	public Stat hp = new Stat();
	public Stat stamina = new Stat();
	public Stat defense = new Stat();
	public List<StatusEffect> buffs = new List<StatusEffect>();
	public List<StatusEffect> debuffs = new List<StatusEffect>();
	public List<Stacks> stacks = new List<Stacks>();
	public List<Skill> skills = new List<Skill>();
	public Combo combo;
	public Constants.State state;


	public TextBox textBox;
	public string lastAction; //need someway to record last action.


	public Player()
	{
		attack.setValueAtStart(10);
		hp.setValueAtStart(150);
		stamina.setValueAtStart(10);
		defense.setValueAtStart(10);

		Skill attackSkill = new Skill(
				(player, enemy) => { },
				//effect | no return
				(player) => player.attack.currentValue //damage calculation
			);
		Skill dotSkill = new Skill(
			(player, enemy) =>
			{
				bool exists = false;
				foreach (Stacks stack in enemy.stacks)
				{
					if (stack.name.Trim() == "Poison")
					{
						exists = true;
					}
				}
				if (!exists)
				{
					enemy.stacks.Add(
						new Stacks(Constants.Type.ATTACK, 4,
							(number) => { return 10; },
						"Poison"));
				}
				else
				{
					GD.Print("Already Poisoned Numbnuts");
				}

			},
			(player) => (int)Math.Floor((double)player.attack.currentValue - (player.attack.currentValue * .025f))
		);

		skills.Add(attackSkill);
		skills.Add(dotSkill);
		GD.Print(skills[0]);
	}

	public void subtractStack()
	{
		foreach (Stacks stack in stacks)
		{
			stack.subtractCount();
			GD.Print(stack.name + " | Stacks Left: " + stack.stackCount);
			if (stack.stackCount <= 0)
			{

				stack.effect = null;
			}
		}
	}



	public override void _Ready()
	{
		state = Constants.State.NEUTRAL;
		// textBox = GetChild(0).GetChild(0).GetChild(0).GetChild<TextBox>(0);
		// textBox.displayText("This is some test text lmao", 10f);
		// GD.Print(attack.currentValue);
	}

	public override void _Process(double delta)
	{


		if (Input.IsActionJustPressed(Constants.CONTROLS_LEFT))
		{
			GD.Print("Left Pressed, allowed to move left");
			// animatedSprite2D.Scale = new Vector2(-1, 1);
			Position = new Vector2(Position.X - 8, Position.Y);


		}
		if (Input.IsActionJustPressed(Constants.CONTROLS_RIGHT))
		{
			GD.Print("Right Pressed, allowed to move right");
			// animatedSprite2D.Scale = new Vector2(1, 1);
			Position = new Vector2(Position.X + 8, Position.Y);
		}
		if (Input.IsActionJustPressed(Constants.CONTROLS_UP))
		{
			GD.Print("Left Pressed, allowed to move left");
			// animatedSprite2D.Scale = new Vector2(-1, 1);
			Position = new Vector2(Position.X, Position.Y - 8);


		}
		if (Input.IsActionJustPressed(Constants.CONTROLS_DOWN))
		{
			GD.Print("Right Pressed, allowed to move right");
			// animatedSprite2D.Scale = new Vector2(1, 1);
			Position = new Vector2(Position.X, Position.Y + 8);
		}

	}
}
