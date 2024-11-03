using Godot;
using System;

public partial class GemPickup : Area2D
{
	public void _on_body_entered(Node2D body2D)
	{
		GD.Print("+1");
	}
}
