using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using Godot;

namespace NikkiMusic
{
	public class WallpaperGradient : Control
	{
		[Child] private TextureRect textureRect;

		private Gradient Gradient
		{
			get
			{
				 return (Gradient) textureRect.Texture.Get("gradient");
				
			}
		}
		public override void _Ready()
		{
			this.Wire();
			
		}

		public void SetGradient(Color[] color)
		{
			Gradient.Colors = color;
		}
		

	}
}