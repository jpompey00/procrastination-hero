using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public int attack;
	public TextBox textBox;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		textBox = GetChild(0).GetChild(0).GetChild(0).GetChild<TextBox>(0);
		textBox.displayText("This is some test text lmao", 10f);
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
			Position = new Vector2(Position.X , Position.Y- 8);


		}
		if (Input.IsActionJustPressed(Constants.CONTROLS_DOWN))
		{
			GD.Print("Right Pressed, allowed to move right");
			// animatedSprite2D.Scale = new Vector2(1, 1);
			Position = new Vector2(Position.X , Position.Y+ 8);
		}
		
	}
}
