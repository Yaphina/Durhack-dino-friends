using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		// if have multiple characters = may need to change name
		animatedSprite2D.Play();

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("moveLeft", "moveRight", "moveUp", "moveDown");
		if (direction != Vector2.Zero)
		{
			animatedSprite2D.Animation = "idle"; // Change this to walk afterwards
			velocity = direction * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		// Changing the player animation to idle when the player is not moving
		if (velocity == Vector2.Zero)
		{
			animatedSprite2D.Animation = "idle";
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
