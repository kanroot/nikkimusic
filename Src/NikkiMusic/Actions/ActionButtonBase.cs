using Godot;

namespace NikkiMusic.Actions
{
	public abstract class ActionButtonBase: Node2D
	{
		[Export] protected float timeBetweenStates = 0.7f;
		[Export] protected int scoreHorrible = 100;
		[Export] protected int scoreBad = 200;
		[Export] protected int scoreGood = 800;
		[Export] protected int scorePerfect = 1000;
		[Export] protected int scoreSlow = 500;
		[Export] protected int scoreMiss = -100;

		public int Score { get; protected set; }
		protected int bps;

		[Signal]
		public delegate int Destroyed();
		
		public override void _ExitTree()
		{
			EmitSignal(nameof(Destroyed), Score);
		}

		public virtual void Init(Vector2 position, int bps)
		{
			Position = position;
			this.bps = bps;
		}

		protected abstract void OnPressed();
		protected abstract void OnRelease();

	}
}