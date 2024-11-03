using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private AnimatedSprite2D animatedSprite2D;
	private Vector2 velocity;
	public const float Speed = 300.0f;
	
	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	public void GetInput()
	{
		Vector2 direction = Input.GetVector("moveLeft", "moveRight", "moveUp", "moveDown");
		velocity = direction * Speed;
	}
	
	public void updateAnimation()
	{
		if (velocity.X < 0) {
			animatedSprite2D.Play("running_left");
		} else if (velocity.X > 0) {
			animatedSprite2D.Play("running_right");
		} else if (velocity.Y < 0) {
			animatedSprite2D.Play("running_away");
		} else if (velocity.Y > 0) {
			animatedSprite2D.Play("running_towards");
		}
		
		if (velocity == Vector2.Zero) {
			animatedSprite2D.Play("idle");
		}
	}
	
	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		Velocity = velocity;
		MoveAndSlide();
		updateAnimation();
	}
}
