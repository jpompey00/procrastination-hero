using Godot;
using System;

public partial class TextBox : Control
{
	RichTextLabel label;
	TextureRect player;
	Timer displayTimer;
	// Called when the node enters the scene tree for the first time.

	public override void _Ready()
	{
		this.Visible = false;
		label = GetChild<RichTextLabel>(2);
		player = GetChild<TextureRect>(1);
		displayTimer = GetChild<Timer>(3);

		displayTimer.Timeout += () =>
		{
			//make this a smooth opacity change w/ LERP
			this.Visible = false;
		};
	}


	public void displayText(String textToDisplay, float time)
	{
		this.Visible = true;
		label.Text = textToDisplay;
		displayTimer.Start(time);
	}
	
}
