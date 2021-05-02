using System;
using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using Godot;

// ReSharper disable once CheckNamespace
namespace NikkiMusic
{
	public class ButtonTouch : Area2D
	{
		[Export] private ButtonState initialState;
		[Child] AnimatedSprite animatedSprite;

		private ButtonState currentState;

		//variables
		[Export] private int scoreHorrible = 100;
		[Export] private int scoreBad = 200;
		[Export] private int scoreGood = 800;
		[Export] private int scorePerfect = 1000;
		[Export] private int scoreSlow = 500;
		[Export] private int scoreMiss = 0;

		private float timeBetweenStates = 0.7f;
		public event Action<int> OnDestroyed;
		private int score;

		public ButtonTouch Init(Vector2 position, float timeBetweenStates = 0.7f,
			ButtonState buttonState = ButtonState.Horrible)
		{
			this.Position = position;
			this.timeBetweenStates = timeBetweenStates;
			this.initialState = buttonState;
			UpdateState();
			return this;
		}

		private void UpdateState()
		{
			if (currentState == ButtonState.Miss)
			{
				QueueFree();
				return;
			}

			var timer = new Timer();
			AddChild(timer);
			timer.OneShot = true;
			timer.WaitTime = timeBetweenStates;
			timer.Connect("timeout", this, nameof(UpdateState));
			timer.Start();
			CurrentState++;
		}

		public void _input_event(Viewport viewport, InputEvent @event, int shapeIdx)
		{
			if (!(@event is InputEventScreenTouch) && !(@event is InputEventMouseButton)) return;
			if (!@event.IsPressed()) return;
			QueueFree(); //para matar instancia.
		}

		public override void _ExitTree()
		{
			OnDestroyed?.Invoke(score);
		}

		private void SetScore()
		{
			switch (CurrentState)
			{
				case ButtonState.Horrible:
					score = scoreHorrible;
					break;
				case ButtonState.Bad:
					score = scoreBad;
					break;
				case ButtonState.Good:
					score = scoreGood;
					break;
				case ButtonState.Perfect:
					score = scorePerfect;
					break;
				case ButtonState.Slow:
					score = scoreSlow;
					break;
				case ButtonState.Miss:
					score = scoreMiss;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public ButtonState CurrentState
		{
			get { return currentState; }

			private set
			{
				currentState = value;

				animatedSprite.Frame = (int) currentState;
				SetScore();
			}
		}

		public override void _Ready()
		{
			this.Wire();
		}
	}
}