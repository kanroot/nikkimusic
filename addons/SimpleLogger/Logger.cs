using System;
using System.Text;
using Godot;
using Newtonsoft.Json;
using NikkiMusic.Utils;

namespace SimpleLogger
{
	/// <summary>
	/// Ultra básica implementación de un logger estático.
	/// </summary>
	public class Logger
	{
		private const string USER_PREF_FILE = "user://loglevel.cfg"; 
		private const string DELIMITER = " [{0}]";
		private static Logger instance;
		private LogLevel logLevel;
		private File fileHandler;

		public LogLevel CurrentLogLevel
		{
			get => logLevel;
			set => SetLogLevel(value);
		}

		public static Logger Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Logger();
				}

				return instance;
			}
		}

		private Logger()
		{
			ReadLogLevelPrefs();
		}

		private void ReadLogLevelPrefs()
		{
			fileHandler = new File();
			if (!fileHandler.TryOpenFile(out _, USER_PREF_FILE, File.ModeFlags.Read))
			{
				CurrentLogLevel = LogLevel.Debug;
				fileHandler.Close();
				WriteLogLevelPref();
				return;
			}

			var content = fileHandler.GetAsText();
			fileHandler.Close();
			CurrentLogLevel = (LogLevel)int.Parse(content);
		}

		private void SetLogLevel(LogLevel level)
		{
			logLevel = level;
			WriteLogLevelPref();
		}

		private void WriteLogLevelPref()
		{ 
			if (fileHandler.TryOpenFile(out var _, USER_PREF_FILE, File.ModeFlags.Write))
			{
				var serialized = JsonConvert.SerializeObject(CurrentLogLevel);
				GD.Print(serialized);
				fileHandler.StoreString(serialized);
			}

			fileHandler.Close();
		}
		
		private static string BuildString(LogLevel level, object message, object context = null)
		{
			var sb = new StringBuilder();
			sb.Append(DateTime.Now.ToString("h:mm:ss tt"));
			sb.Append(string.Format(DELIMITER, level.ToString().ToUpper()));
			if (context != null)
			{
				sb.Append(string.Format(DELIMITER, context.GetContextName()));
			}

			sb.Append($" {message.ToString()}");
			return sb.ToString();
		}

		private static void Log(LogLevel level, object message, object context = null)
		{
			if (Instance.logLevel > level)
			{
				return;
			}
			
			if (level == LogLevel.Error)
			{
				GD.PrintErr(BuildString(level, message, context));
				return;
			}
			
			GD.Print(BuildString(level, message, context));
		}

		public static void LogDebug(object message, object context = null)
		{
			Log(LogLevel.Debug, message, context);
		}

		public static void LogInfo(object message, object context = null)
		{
			Log(LogLevel.Info, message, context);
		}

		public static void LogWarning(object message, object context = null)
		{
			Log(LogLevel.Warning, message, context);
		}

		public static void LogError(object message, object context = null)
		{
			Log(LogLevel.Error, message, context);
		}
	}
}
