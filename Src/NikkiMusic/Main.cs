using System;
using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using Godot;

namespace NikkiMusic
{
	public class Main : Node2D
	{
		[Child] private Label scoreLabel;
		[Child] private Conductor conductor;
		[Child] private WallpaperGradient wallpaperGradient;
		[Export] private PackedScene buttonTouch;
		private Random random = new Random();

		private int scoreTotal = 0;

		//esta propiedad es de solo lectura
		public int Score => scoreTotal;


		//se ejecuta cuando el nodo el ready entra en arbol de la escena.
		public override void _Ready()
		{
			this.Wire();
			conductor.pulse += OnPulse;
		}

		//corre por cada frame de simulacion
		public override void _Process(float delta)
		{
			scoreLabel.Text = Score.ToString();
		}

		private Vector2 XyZ()
		{
			var positionX = random.Next(100, (int) GetViewport().GetVisibleRect().Size.x - 100);
			var positionY = random.Next(100, (int) GetViewport().GetVisibleRect().Size.y - 100);

			return new Vector2(positionX, positionY);
		}

		private void OnPulse(int pulse)
		{
			var j = buttonTouch.Instance() as ButtonTouch;
			AddChild(j);
			j?.Init(XyZ());
			if (j != null) j.OnDestroyed += OnDestroyed;
		}

		private void ChangeBackGround()
		{
			var color =  new Color[] {Colors.Aqua,Colors.Beige};
			wallpaperGradient.SetGradient(color);
		}
		private void OnDestroyed(int Score)
		{
			scoreTotal += Score;
			ChangeBackGround();
		}
		//desarollar label, hud puntaje total, crear nodes del hud y crear una escena aparte o viceversa.
		//lograr sincronizar bpm con la reproducción real de godot.
	}
}