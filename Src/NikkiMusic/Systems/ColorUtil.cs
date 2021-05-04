using System;
using System.Collections.Generic;
using Godot;

namespace NikkiMusic.Systems
{
	public static class ColorUtil
	{
		// public static Color ChangeRgb(Color initColor, Color finalColor)
		// {
		// 	var r = (byte) ChangeRgbR8(initColor, finalColor);
		// 	var g = (byte) ChangeRgbG8(initColor, finalColor);
		// 	var b = (byte) ChangeRgbB8(initColor, finalColor);
		// 	return Color.Color8(r, g, b);
		// }

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
				if (a[i] == b[i])
				{
					a[i] = a[i];
				}
				else
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
			}

			return Color.Color8((byte) a[0], (byte) a[1], (byte) a[2]);
		}


		// private static int ChangeRgbR8(Color initColor, Color finalColor)
		// {
		// 	if (initColor.r8 == finalColor.r8)
		// 	{
		// 		return initColor.r8;
		// 	}
		// 	else
		// 	{
		// 		if (initColor.r8 < finalColor.r8)
		// 		{
		// 			return initColor.r8 + 1;
		// 		}
		// 		else
		// 		{
		// 			if (initColor.r8 > finalColor.r8)
		// 			{
		// 				return initColor.r8 - 1;
		// 			}
		// 		}
		// 	}
		//
		// 	return initColor.r8;
		// }
		//
		// private static int ChangeRgbG8(Color initColor, Color finalColor)
		// {
		// 	if (initColor.g8 == finalColor.g8)
		// 	{
		// 		return initColor.g8;
		// 	}
		// 	else
		// 	{
		// 		if (initColor.g8 < finalColor.g8)
		// 		{
		// 			return initColor.g8 + 1;
		// 		}
		// 		else
		// 		{
		// 			if (initColor.g8 > finalColor.g8)
		// 			{
		// 				return initColor.g8 - 1;
		// 			}
		// 		}
		// 	}
		//
		// 	return initColor.g8;
		// }
		//
		// private static int ChangeRgbB8(Color initColor, Color finalColor)
		// {
		// 	if (initColor.b8 == finalColor.b8)
		// 	{
		// 		return initColor.b8;
		// 	}
		// 	else
		// 	{
		// 		if (initColor.b8 < finalColor.b8)
		// 		{
		// 			return initColor.b8 + 1;
		// 		}
		// 		else
		// 		{
		// 			if (initColor.b8 > finalColor.b8)
		// 			{
		// 				return initColor.b8 - 1;
		// 			}
		// 		}
		// 	}
		//
		// 	return initColor.g8;
		// }
	}
}