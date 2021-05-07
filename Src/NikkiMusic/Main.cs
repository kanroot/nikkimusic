using System;
using System.Collections.Generic;
using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using GDMechanic.Extensions;
using Godot;
using NikkiMusic.Actions;
using NikkiMusic.Systems;
using NikkiMusic.UI;

namespace NikkiMusic
{
	public class Main : Node
	{
		[Child()] private Menu menu;
		
		private List<object> Canciones = new List<object>(){new object(), new object(), new object()};
		public override void _Ready()
		{
			this.Wire();
			menu.Init(Canciones); 
		}

		
	}
}