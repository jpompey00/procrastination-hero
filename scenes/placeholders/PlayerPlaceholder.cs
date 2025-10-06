using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerPlaceholder : Node2D
{
    Sprite2D sprite;
    ProgressBar hpBar;
    ProgressBar staminaBar;
    StatContainer attackContainer;
    StatContainer defenseContainer;
    Player player;
    VBoxContainer buffAndDebuffContainer;
    public TextureRect defenseIcon { get; set; }


    public override void _Ready()
    {
        //creating scene from the file path i guess
        PackedScene defenseScene = GD.Load<PackedScene>("res://scenes/buff and debuff icons/defense_icon.tscn");
        defenseIcon = defenseScene.Instantiate<TextureRect>();


        sprite = GetNode<Sprite2D>("Sprite2D");
        hpBar = GetChild(1).GetNode<ProgressBar>("Hp Bar");
        staminaBar = GetChild(1).GetNode<ProgressBar>("Stamina Bar");
        attackContainer = GetChild(1).GetChild(2).GetNode<StatContainer>("Attack Container");
        defenseContainer = GetChild(1).GetChild(2).GetNode<StatContainer>("Defense Container");
        buffAndDebuffContainer = GetNode<VBoxContainer>("UI Elements Placeholder/Buff Debuff Container");
    }
    public void setup(Player player)
    {
        this.player = player;
        setupHpBar(player.hp);
        setupStaminaBar(player.stamina);
        setupAttackContainer(player.attack);
        setupDefenseContainer(player.defense);
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

    public void addToBuffsAndDebuffs(TextureRect textureRect)
    {
        buffAndDebuffContainer.AddChild(textureRect);
    }

    public override void _Process(double delta)
    {
        hpBar.Value = player.hp.currentValue;
    }




}
