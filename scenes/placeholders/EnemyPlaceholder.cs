using Godot;
using System;

public partial class EnemyPlaceholder : Node2D
{
    Sprite2D sprite;
    ProgressBar hpBar;
    ProgressBar staminaBar;
    StatContainer attackContainer;
    StatContainer defenseContainer;
    Enemy enemy;

    public override void _Ready()
    {
        sprite = GetNode<Sprite2D>("Sprite2D");
        hpBar = GetChild(1).GetNode<ProgressBar>("Hp Bar");
        staminaBar = GetChild(1).GetNode<ProgressBar>("Stamina Bar");
        attackContainer = GetChild(1).GetChild(2).GetNode<StatContainer>("Attack Container");
        defenseContainer = GetChild(1).GetChild(2).GetNode<StatContainer>("Defense Container");

    }
    public void setup(Enemy enemy)
    {
        this.enemy = enemy;
        setupHpBar(enemy.hp);
        setupStaminaBar(enemy.stamina);
        setupAttackContainer(enemy.attack);
        setupDefenseContainer(enemy.defense);
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
        hpBar.Value = enemy.hp.currentValue;
    }
}
