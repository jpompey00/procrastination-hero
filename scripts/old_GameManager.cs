// using Godot;
// using System;
// using System.Collections.Generic;

// public partial class GameManager : Node
// {
// 	Clark clark;
// 	int clarkCurrentHp;
// 	int clarkCurrentStamina;
// 	Enemy enemy1;
// 	int enemy1CurrentHp;
// 	Enemy enemy2;
// 	Enemy enemy3;
// 	Enemy enemy4;
// 	// Called when the node enters the scene tree for the first time.

// 	Timer turnTimer;
// 	Timer animationTimer;
// 	float waitTime; //set this to whatever animation

// 	List<int> turnOrder;

// 	Boolean isPlayerTurn; //use this to give and take player control away

// 	public override void _Ready()
// 	{
// 		clark = GetNode<Clark>("Clark");
// 		clark.setStats(40, 10, 10, 10, 10, 10, 10);
// 		GD.Print(clark.healthPoints);
// 		clarkCurrentHp = clark.healthPoints;
// 		isPlayerTurn = true;


// 		enemy1 = GetNode("EnemyList").GetChild<Enemy>(0);
// 		enemy1CurrentHp = enemy1.health;


// 		turnTimer = new Timer();
// 		turnTimer.Timeout += () => { isPlayerTurn = true; GD.Print("Player Turn"); };
// 		AddChild(turnTimer);

// 		animationTimer = new Timer();
// 		AddChild(animationTimer);
// 	}

// 	// Called every frame. 'delta' is the elapsed time since the previous frame.
// 	public override void _Process(double delta)
// 	{
// 		enemy1.setCurrentHealthOnProgressBar(enemy1CurrentHp);
// 		clark.setCurrentHealthOnProgressBar(clarkCurrentHp);
// 	}


// 	public void enemyTurn(Enemy enemy)
// 	{
// 		// GD.Print(clarkCurrentHp);
// 		clarkCurrentHp -= enemy.artificialIntelligence(clark)(enemy, clark);
// 		GD.Print("Clark HP: " + clarkCurrentHp + "/" + clark.healthPoints);
// 		waitTime = 2f;
// 		turnTimer.Start(waitTime);
// 	}

// 	public void endPlayerTurn()
// 	{
// 		// isPlayerTurn = false;
// 		enemyTurn(enemy1);
// 	}

// 	public override void _Input(InputEvent @event)
// 	{
// 		// base._Input(@event);
// 		if (@event is InputEventKey keyEvent && keyEvent.Pressed)
// 		{
// 			if (keyEvent.Keycode == Key.W)
// 			{
// 				if (isPlayerTurn)
// 				{
// 					isPlayerTurn = false;
// 					GD.Print("W pressed");
// 					double  animWaitTime = clark.playAnimation("Attack");

// 					animationTimer.Timeout += () =>
// 					{
// 						GD.Print("timer loop");
// 						enemy1CurrentHp -= clark.skillDict["Crippling Blow"](clark, 2, enemy1);
// 						GD.Print("EnemyHp: " + enemy1CurrentHp);
// 						endPlayerTurn();
// 						animationTimer.Stop();
// 					};
// 					animationTimer.Start(animWaitTime);
// 					// endPlayerTurn();
// 					// isPlayerTurn = false;
// 				}
// 				else
// 				{
// 					GD.Print("Not player turn");
// 				}
// 			}
// 		}
// 	}

// }
