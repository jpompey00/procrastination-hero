using Godot;
using System;

public partial class BattleParticipant : Node
{
    Sprite2D sprite;
    ProgressBar hpBar;
    ProgressBar staminaBar;
    StatContainer attackContainer;
    StatContainer defenseContainer;
    Player player;



    public override void _Ready()
    {
        // sprite = GetNode<Sprite2D>("Sprite2D");
        // hpBar = GetChild(1).GetNode<ProgressBar>("Hp Bar");
        // staminaBar = GetChild(1).GetNode<ProgressBar>("Stamina Bar");
        // attackContainer = GetChild(1).GetChild(2).GetNode<StatContainer>("Attack Container");
        // defenseContainer = GetChild(1).GetChild(2).GetNode<StatContainer>("Defense Container");

    }
    public void setup(Player player)
    {
        // this.player = player;
        // setupHpBar(player.hp);
        // setupStaminaBar(player.stamina);
        // setupAttackContainer(player.attack);
        // setupDefenseContainer(player.defense);
    }

    public void setupHpBar(Stat hp)
    {
        hpBar.MaxValue = hp.value;
        hpBar.Value = hp.currentValue;
    }

    public void setupStaminaBar(Stat stamina)
    {
        staminaBar.MaxValue = stamina.value;
        staminaBar.Value = stamina.currentValue;
    }
    public void setupAttackContainer(Stat attack)
    {
        attackContainer.number.Text = attack.currentValue.ToString();
    }
    public void setupDefenseContainer(Stat defense)
    {
        defenseContainer.number.Text = defense.currentValue.ToString();
    }

    public override void _Process(double delta)
    {
        hpBar.Value = player.hp.currentValue;
    }



}
