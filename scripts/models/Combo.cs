using System;

public class Combo
{
    Action<int, Enemy> comboAction;
    int turnsLeft;

    public Combo(Action<int, Enemy> _comboAction, int _turnsLeft)
    {
        this.comboAction = _comboAction;
        this.turnsLeft = _turnsLeft;
    }

    public void subtractOneTurn()
    {
        turnsLeft -= 1;
    }

}