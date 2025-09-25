using Godot;
using System;

public partial class BattlePlaceholder : Node2D
{
    Player player;
    Enemy enemy;
    PlayerPlaceholder playerPlaceholder;
    Button attack;
    Button skill;
    Button defend;

    public override void _Ready()
    {
        player = new Player();
        playerPlaceholder = GetNode<PlayerPlaceholder>("Player_Placeholder");
        playerPlaceholder.setup(player);

        attack = GetNode("UI").GetChild(0).GetNode<Button>("Attack");
        skill = GetNode("UI").GetChild(0).GetNode<Button>("Skill");
        defend = GetNode("UI").GetChild(0).GetNode<Button>("Defend");

        attack.Pressed += () =>
        {
            
        };
    }


    public override void _Process(double delta)
    {
        
    }


}
