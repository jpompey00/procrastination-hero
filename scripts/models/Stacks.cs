using System;
using System.Collections;

public class Stacks
{
    Constants.Type type;
    public int stackCount{ get; set; }

    public Func<int, int> effect{get; set; }
    public String name{ get; set; }


    public Stacks(Constants.Type _type, int _stackCount, Func<int, int> _effect, String _name)
    {
        type = _type;
        stackCount = _stackCount;
        effect = _effect;
        name = _name;
    }


    public void subtractCount()
    {
        stackCount -= 1;
    }
}