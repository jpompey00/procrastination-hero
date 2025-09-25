using Godot;
using System;
using System.Collections.Generic;

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
		hp.setValueAtStart(10);
		stamina.setValueAtStart(10);
		defense.setValueAtStart(10);

		Skill attackSkill = new Skill(
				(player, enemy) => { },
				//effect | no return
				(player) => player.attack.currentValue //damage calculation
			);
		skills.Add(attackSkill);
		GD.Print(skills[0]);
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
