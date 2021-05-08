#if TOOLS
using System;
using Godot;

namespace SimpleLogger
{
	[Tool]
	public class Plugin : EditorPlugin
	{
		private Control panel;
		private OptionButton dropdown;
		
		public override void _EnterTree()
		{
			var scene = GD.Load<PackedScene>("res://addons/SimpleLogger/LoggerDock.tscn");
			panel = scene.Instance<Control>();
			dropdown = (OptionButton) panel.FindNode("OptionButton");
			foreach (var level in Enum.GetValues(typeof(LogLevel)))
			{
				dropdown.AddItem(level.ToString());
			}

			dropdown.Connect("item_selected", this, nameof(OnDropdownChange));
			var initialLogLevel = Logger.Instance.CurrentLogLevel; 
			dropdown.Selected = (int) initialLogLevel;
			AddControlToBottomPanel(panel, "Log Level");
		}

		private void OnDropdownChange(int index)
		{
			Logger.Instance.CurrentLogLevel = (LogLevel) index;
		}

		public override void _ExitTree()
		{
			RemoveControlFromBottomPanel(panel);
			panel.Free();
		}
	}
}
#endif