using Godot;
using System;

public partial class Enemy : Node
{
	double health;
	int dotCounter;
	int dotDamage;
	int buffCounter;

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
		dotCounter = turn;
		dotDamage = damage;
	}

	
}
