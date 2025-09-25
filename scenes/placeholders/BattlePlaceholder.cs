using Godot;
using System;

public partial class BattlePlaceholder : Node2D
{
    //basically the game manager lmao
    Player player;
    Enemy enemy;
    PlayerPlaceholder playerPlaceholder;
    EnemyPlaceholder enemyPlaceholder;
    Button attack;
    Button skill;
    Button defend;

    public override void _Ready()
    {
        player = new Player();
        enemy = new Enemy();


        playerPlaceholder = GetNode<PlayerPlaceholder>("Player_Placeholder");
        enemyPlaceholder = GetNode<EnemyPlaceholder>("Enemy_Placeholder");
        playerPlaceholder.setup(player);
        enemyPlaceholder.setup(enemy);
        

        attack = GetNode("UI").GetChild(0).GetNode<Button>("Attack");
        skill = GetNode("UI").GetChild(0).GetNode<Button>("Skill");
        defend = GetNode("UI").GetChild(0).GetNode<Button>("Defend");

        attack.Pressed += () =>
        {
            //maybe use a map for readability.
            GD.Print(enemy.hp.currentValue + "/" + enemy.hp.value);
            int damage = player.skills[0].skill(player, 2, enemy);
            GD.Print(damage + " damage done");

            enemy.hp.currentValue -= damage;
        };
    }





    //should likely just use this for updating visuals, not for any actual game thing.
    public override void _Process(double delta)
    {

    }


}
