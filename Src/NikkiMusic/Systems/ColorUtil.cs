using Godot;

namespace NikkiMusic.Systems
{
	public static class ColorUtil
	{
		public static Color ChangeRgb(Color initColor, Color finalColor)
		{
			var r = (byte) ChangeRgbR8(initColor, finalColor);
			var g = (byte) ChangeRgbG8(initColor, finalColor);
			var b = (byte) ChangeRgbB8(initColor, finalColor);
			return Color.Color8(r, g, b);
		}

		private static int ChangeRgbR8(Color initColor, Color finalColor)
		{
			if (initColor.r8 == finalColor.r8)
			{
				return initColor.r8;
			}
			else
			{
				if (initColor.r8 < finalColor.r8)
				{
					return initColor.r8 + 1;
				}
				else
				{
					if (initColor.r8 > finalColor.r8)
					{
						return initColor.r8 - 1;
					}
				}
			}

			return initColor.r8;
		}

		private static int ChangeRgbG8(Color initColor, Color finalColor)
		{
			if (initColor.g8 == finalColor.g8)
			{
				return initColor.g8;
			}
			else
			{
				if (initColor.g8 < finalColor.g8)
				{
					return initColor.g8 + 1;
				}
				else
				{
					if (initColor.g8 > finalColor.g8)
					{
						return initColor.g8 - 1;
					}
				}
			}

			return initColor.g8;
		}

		private static int ChangeRgbB8(Color initColor, Color finalColor)
		{
			if (initColor.b8 == finalColor.b8)
			{
				return initColor.b8;
			}
			else
			{
				if (initColor.b8 < finalColor.b8)
				{
					return initColor.b8 + 1;
				}
				else
				{
					if (initColor.b8 > finalColor.b8)
					{
						return initColor.b8 - 1;
					}
				}
			}

			return initColor.g8;
		}
	}
}