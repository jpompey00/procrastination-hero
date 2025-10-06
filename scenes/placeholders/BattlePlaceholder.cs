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
    Constants.TurnPhase turnPhase;

    public override void _Ready()
    {
        turnPhase = Constants.TurnPhase.START;
        player = new Player();
        enemy = new Enemy();

        playerPlaceholder = GetNode<PlayerPlaceholder>("Player_Placeholder");
        enemyPlaceholder = GetNode<EnemyPlaceholder>("Enemy_Placeholder");
        playerPlaceholder.setup(player);
        enemyPlaceholder.setup(enemy);


        turnPhase = Constants.TurnPhase.BATTLE;

        attack = GetNode("UI").GetChild(0).GetNode<Button>("Attack");
        skill = GetNode("UI").GetChild(0).GetNode<Button>("Skill");
        defend = GetNode("UI").GetChild(0).GetNode<Button>("Defend");

        attack.Pressed += () =>
        {
            if (turnPhase == Constants.TurnPhase.BATTLE)
            {
                //maybe use a map for readability.
                GD.Print(enemy.hp.currentValue + "/" + enemy.hp.value);
                int damage = player.skills[0].skill(player, 2, enemy);
                GD.Print(damage + " damage done");

                enemy.hp.currentValue -= damage;
                turnPhase = Constants.TurnPhase.RESOLVE;
            }


        };
        skill.Pressed += () =>
        {
            if (turnPhase == Constants.TurnPhase.BATTLE)
            {
                GD.Print(enemy.hp.currentValue + "/" + enemy.hp.value);
                int damage = player.skills[1].skill(player, 2, enemy);
                GD.Print(damage + " damage done");

                enemy.hp.currentValue -= damage;
                turnPhase = Constants.TurnPhase.RESOLVE;
            }
            //apply a dot

        };


        defend.Pressed += () =>
        {
            if (turnPhase == Constants.TurnPhase.BATTLE)
            {
                GD.Print("Defending");
                Stacks defense = new Stacks(Constants.Type.BUFF, 1,
                (number) =>
                {
                    return 10;
                }, "Defend");
                player.stacks.Add(defense);
                //create a stack of defense
                playerPlaceholder.addToBuffsAndDebuffs(playerPlaceholder.defenseIcon);
                //defense goes away after 1 hit
                turnPhase = Constants.TurnPhase.RESOLVE;
            }


        };
    }





    //should likely just use this for updating visuals, not for any actual game thing.
    public override void _Process(double delta)
    {
        //not scalable will need to be fixed :D
        if (turnPhase == Constants.TurnPhase.RESOLVE)
        {
            player.hp.currentValue -= enemy.attack.currentValue;
            GD.Print("Take damage chucklenuts");
            turnPhase = Constants.TurnPhase.CLEANUP;
        }
        if (turnPhase == Constants.TurnPhase.CLEANUP)
        {
            //subtract stacks from everyone
            enemy.subtractStack();
            player.subtractStack();
            turnPhase = Constants.TurnPhase.BATTLE;
        }
    }


}
