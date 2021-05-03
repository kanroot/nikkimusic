using System;
using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using Godot;

namespace NikkiMusic.Systems
{
	public class Conductor : Node
	{
		[Export] private bool debug;
		[Export] private int bpm = 150;
		[Export] private int bars = 4;

		[Child] private Label beatBPM;
		[Child] private AudioStreamPlayer audioStreamPlayer;
		private int prevFractionBeat;
		private int prevBeat;
		
		private const int COMPENSATE_FRAMES = 2;
		private const double COMPENSATE_HZ = 60.0;

		[Signal]
		public delegate int PulsedWholeBeat();

		[Signal]
		public delegate int PulsedFractionedBeat();
		
		public int CurrentBeat { get; private set; }
		public int CurrentBeatFraction { get; private set; }
		public double SongCurrentTime { get; private set; }

		private void PlaySong()
		{
			if (!audioStreamPlayer.Autoplay && !audioStreamPlayer.Playing)
			{
				audioStreamPlayer.Play();
			}
		}
		
		public override void _Process(float delta)
		{
			SongCurrentTime = audioStreamPlayer.GetPlaybackPosition() + AudioServer.GetTimeSinceLastMix()
				- AudioServer.GetOutputLatency() + (1 / COMPENSATE_HZ) * COMPENSATE_FRAMES;
			
			CurrentBeatFraction = (int) (SongCurrentTime * bpm / 3.75);
			CurrentBeat = CurrentBeatFraction / 16;

			var seconds = (int) SongCurrentTime;
			var secondsTotal = (int) audioStreamPlayer.Stream.GetLength();
			
			beatBPM.Visible = debug;
			const string debugText = "CURRENT: {0} BEAT: {1}/{2} TIME: {3}:{4}/{5}:{6}\n16avo: {7}";
			beatBPM.Text = string.Format(
				debugText,
				CurrentBeat,
				CurrentBeat % bars + 1,
				bars,
				seconds/60,
				seconds%60,
				secondsTotal/60,
				secondsTotal%60,
				CurrentBeatFraction);

			if (CurrentBeatFraction != prevFractionBeat)
			{
				EmitSignal(nameof(PulsedFractionedBeat), CurrentBeatFraction);
			}
			
			if (CurrentBeat != prevBeat)
			{
				EmitSignal(nameof(PulsedWholeBeat), CurrentBeat);
			}

			prevFractionBeat = CurrentBeatFraction;
			prevBeat = CurrentBeat;
		}

		public override void _Ready()
		{
			this.Wire();
			PlaySong();
		}
	}
}