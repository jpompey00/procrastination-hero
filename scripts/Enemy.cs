using Godot;
using System;
using System.Collections.Generic;

public partial class Enemy : Node
{
	public Stat attack = new Stat();
	public Stat hp = new Stat();
	public Stat stamina = new Stat();
	public Stat defense = new Stat();
	public List<StatusEffect> buffs = new List<StatusEffect>();
	public List<StatusEffect> debuffs = new List<StatusEffect>();
	public List<Stacks> stacks = new List<Stacks>();
	public Combo combo;
	public Constants.State state;

	public Enemy()
	{
		attack.setValueAtStart(11);
		hp.setValueAtStart(100);
		stamina.setValueAtStart(11);
		defense.setValueAtStart(11);
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void setDamageOverTime(int turn, int damage)
	{

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


}
