using System;
using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using Godot;

namespace NikkiMusic
{
	public class Conductor : Node
	{
		[Child()] private AudioStreamPlayer audioStreamPlayer;
		[Child()] private Label beatBPM;
		[Export] private int bmp = 100;
		[Export] private int bars = 4;
		private int beatPrevius;
		private bool playing = false;
		private const int COMPENSATE_FRAMES = 2;
		private const double COMPENSATE_HZ = 60.0;
		public event Action<int> pulse;
		
		public void PlaySong()
		{
			if (!audioStreamPlayer.Autoplay && !audioStreamPlayer.Playing)
			{
				audioStreamPlayer.Play();
			}
		}
		public override void _Process(float delta)
		{
			var time = 0.0;
			time = audioStreamPlayer.GetPlaybackPosition() + AudioServer.GetTimeSinceLastMix()
				- AudioServer.GetOutputLatency() + (1 / COMPENSATE_HZ) * COMPENSATE_FRAMES;
			var beat = (int) (time * bmp / 60.0);

			var seconds = (int) time;
			var secondsTotal = (int) audioStreamPlayer.Stream.GetLength();
			beatBPM.Text =
				$"BEAT: {beat % bars + 1} / {bars} TIME: {seconds / 60} : {seconds % 60} / {secondsTotal / 60} : {secondsTotal % 60} / BEAT: {beat}";
			if (beat != beatPrevius)
			{
				pulse?.Invoke(beat);
			}
			beatPrevius = beat;
		}

		public override void _Ready()
		{
			this.Wire();
			PlaySong();
		}
	}
}