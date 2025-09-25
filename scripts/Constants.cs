using System;
using Godot;


public static class Constants
{
    // public const float SPEED = 750f;
    public const String CONTROLS_LEFT = "Left";
    public const String CONTROLS_RIGHT = "Right";
    public const String CONTROLS_UP = "Up";
    public const String CONTROLS_DOWN = "Down";
    public const String CONTROLS_CONFIRM = "Confirm";
    public const String CONTROLS_DENY = "Deny";

    public enum State
    {
        COMBO,
        STUN,
        NEUTRAL
    }

    public enum Type
    {
        ATTACK,
        HEAL,
        BUFF,
        DEBUFF
    }

    public enum TurnPhase
    {
        START,
        TURN,
        BATTLE,
        RESOLVE,
        CLEANUP
    }
}

