using System;
using Godot;
using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using GDMechanic.Extensions;

namespace NikkiMusic.UI
{
    public class Menu : Control
    {
        [Child] private TextureRect background;
        [Child] private Control controls;
        [Node("Interface/PlayButton")] private TextureButton playButton;
        [Node("Interface/GradeTexture")] private TextureRect gradeTexture;
        [Node("Interface/TimeTexture")] private TextureRect timeTexture;
        [Node("Interface/ScoreTexture")] private TextureRect scoreTexture;
        [Node("Interface/GradeLabel")] private Label gradeLabel;
        [Node("Interface/ScoreLabel")] private Label scoreLabel;
        [Node("Interface/TimeLabel")] private Label timeLabel;

        //solo de get
        public TextureButton PlayButton => playButton;

        
        public override void _Ready()
        {
        
        }
        
        public void SetTime(string time)
        {
            timeLabel.Text = time;
        }

        public void SetGrade(string grade)
        {
            gradeLabel.Text = grade;
        }

        public void SetScore(string score)
        {
            scoreLabel.Text = score;
        }
    }
}
