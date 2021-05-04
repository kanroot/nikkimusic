using System;
using System.Collections.Generic;
using Godot;

namespace NikkiMusic.Systems
{
	public static class ColorUtil
	{
		public static Color ChangeRgb(Color initColor, Color finalColor)
		{
			var a = new List<int>();
			a.Add(initColor.r8);
			a.Add(initColor.g8);
			a.Add(initColor.b8);
			var b = new List<int>();
			b.Add(finalColor.g8);
			b.Add(finalColor.b8);
			b.Add(finalColor.r8);

			for (var i = 0; i < a.Count; i++)
			{
				if (a[i] < b[i])
				{
					a[i] += 1;
				}
				else
				{
					if (a[i] > b[i])
					{
						a[i] -= 1;
					}
				}
			}

			return Color.Color8((byte) a[0], (byte) a[1], (byte) a[2]);
		}
	}
}