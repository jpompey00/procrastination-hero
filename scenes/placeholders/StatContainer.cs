using Godot;
using System;

public partial class StatContainer : HBoxContainer
{

    public RichTextLabel statusName { get; set; }
    public RichTextLabel number { get; set; }

    public override void _Ready()
    {
        statusName = GetChild<RichTextLabel>(0);
        number = GetChild<RichTextLabel>(1);
    }

}
