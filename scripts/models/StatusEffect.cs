using System;

public class StatusEffect
{
    public Action<Stat> effect { get; }
    public int turnsLeft { get; set; }

    StatusEffect(Action<Stat> _effect, int _turnsLeft)
    {
        effect = _effect;
        turnsLeft = _turnsLeft;
    }

    public void subtractOneTurn()
    {
        turnsLeft -= 1;
    }
}