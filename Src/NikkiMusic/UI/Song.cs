using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using Godot;

namespace NikkiMusic.UI
{
    public class Song : TextureButton
    {   
        
        [Child] private Label songName;
        
        public override void _Ready()
        {
            this.Wire();
        }
        

        public Song Init(string name)
        {
            this.songName.Text = name;
            return this;
        }
        
    }
}
