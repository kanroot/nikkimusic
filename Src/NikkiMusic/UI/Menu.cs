using System.Collections.Generic;
using Godot;
using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;

namespace NikkiMusic.UI
{
    public class Menu : Control
    {
        
        [Child] private TextureRect background;
        [Child] private Control controls;
        [Node("Controls/PlayButton")] private TextureButton playButton;
        [Node("Controls/GradeTexture")] private TextureRect gradeTexture;
        [Node("Controls/DifficultTexture")] private TextureRect difficultTexture;
        [Node("Controls/ScoreTexture")] private TextureRect scoreTexture;
        [Node("Controls/GradeLabel")] private Label gradeLabel;
        [Node("Controls/ScoreLabel")] private Label scoreLabel;
        [Node("Controls/DifficultyLabel")] private Label difficultyLabel;
        [Node("SongList/VBoxContainer")] private VBoxContainer songsContainer;
        [Export] private Texture texture;
        [Export] private PackedScene songScene;
        private object selectedSong;
        private List<object> songs;
        
        public TextureButton PlayButton => playButton;

        public override void _Ready()
        {
            this.Wire();
        }
        public void SetDifficulty(string difficulty)
        {
            difficultyLabel.Text = difficulty;
        }

        public Menu Init( List<object> songs)
        {
            this.songs = songs;
            AddSongs();
            ChangeCurrentSong(new object());
            return this;
        }
        
        private void AddSongs()
        {
            foreach (var s in songs)
            {
                var songEntry = songScene.Instance<Song>();
                songsContainer.AddChild(songEntry);
                songEntry.Init("FORCES");
            }
        }

        public void ChangeCurrentSong(object song)
        {
            SetGrade("A");
            SetDifficulty("EASY");
            SetScore("000000");
            SetBackground(texture);
        }
        private void SetGrade(string grade)
        {
            gradeLabel.Text = grade;
        }

        private void SetScore(string score)
        {
            scoreLabel.Text = score;
        }

        public void SetBackground(Texture texture)
        {
            background.Texture = texture;
        }
    }
}
