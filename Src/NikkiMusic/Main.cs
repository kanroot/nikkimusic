using System.Collections.Generic;
using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using Godot;

using NikkiMusic.UI;

namespace NikkiMusic
{
	public class Main : Node
	{
		[Child] private Menu menu;
		
		private readonly List<object> canciones = new List<object>{new object(), new object(), new object()};
		public override void _Ready()
		{
			this.Wire();
			menu.Init(canciones); 
		}

		
	}
}