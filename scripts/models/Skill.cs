using System;

public class Skill
{
    //edit the toString for this 
    String skillName;
    String skillDescription;
    public Func<Player, int, Enemy, int> skill { get; }

    public Skill(Action<Player, Enemy> effect, Func<Player, int> damageCalc)
    {
        skill = CreateSkill(effect, damageCalc);
    }
    private static Func<Player, int, Enemy, int> CreateSkill(Action<Player, Enemy> effect, Func<Player, int> damageCalc)
    {
        return (player, staminaCost, enemy) =>
        {
            int damage = damageCalc(player);
            effect(player, enemy);
            // player.staminaPoints -= staminaCost;

            return damage;
        };
    }


}