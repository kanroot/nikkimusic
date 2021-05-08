using System;
using Godot;

namespace SimpleLogger
{
	public class UnhandledExceptionHandler: Node
	{
		public override void _Ready()
		{
			AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
		}

		private void OnUnhandledException(object sender, UnhandledExceptionEventArgs args)
		{
			Logger.LogError($"Got unhandled exception: {args.ExceptionObject} from: {sender}");
			Logger.LogError("Se va todo a la mierda!");
		}
	}
}