using System.Threading.Tasks;
using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using Godot;
using NikkiMusic.Utils;

namespace NikkiMusic.Actions
{
    public class ButtonTouch : ActionButtonBase
    {
        [Export] private Texture textureHorrible;
        [Export] private Texture textureBad;
        [Export] private Texture textureGood;
        [Export] private Texture texturePerfect;
        [Export] private Texture textureSlow;
        
        [Child] private TouchScreenButton actionButton;
        
        private ButtonState currentState;
        
        public override void Init(Vector2 position, int bps)
        {
            base.Init(position, bps);
            UpdateState(ButtonState.Horrible);
            _ = LifeCycle();
        }
        
        private void UpdateState(ButtonState state)
        {
            currentState = state;
            actionButton.Normal = GetCurrentTexture();
            Score = GetCurrentScore();
        }

        private async Task LifeCycle()
        {
            while (currentState != ButtonState.Miss)
            {
                await ToSignal(GetTree().CreateTimer(timeBetweenStates), "timeout");
                UpdateState(currentState.Next());
            }
            
            QueueFree();
        }

        private int GetCurrentScore()
        {
            switch (currentState)
            {
                case ButtonState.Horrible:
                    return scoreHorrible;
                case ButtonState.Bad:
                    return scoreBad;
                case ButtonState.Good:
                    return scoreGood;
                case ButtonState.Perfect:
                    return scorePerfect;
                case ButtonState.Slow:
                    return scoreSlow;
                case ButtonState.Miss:
                    return scoreMiss;
                default:
                    GD.PrintErr($"Botón alcanzó estado no soportado para reportar puntaje: {currentState}");
                    return scoreHorrible;
            }
        }
        
        private Texture GetCurrentTexture()
        {
            switch (currentState)
            {
                case ButtonState.Horrible:
                    return textureHorrible;
                case ButtonState.Bad:
                    return textureBad;
                case ButtonState.Good:
                    return textureGood;
                case ButtonState.Perfect:
                    return texturePerfect;
                case ButtonState.Slow:
                    return textureSlow;
                case ButtonState.Miss:
                    return new ImageTexture();
                default:
                    GD.PrintErr($"Botón alcanzó estado no soportado para cambio de textura: {currentState}");
                    return new ImageTexture();
            }
        }
        
        protected override void OnPressed()
        {
            QueueFree();
        }

        protected override void OnRelease()
        {
            //No se usa para este tipo de botones
        }

        
        public override void _Ready()
        {
            this.Wire();
            actionButton.Connect("pressed",this,nameof(OnPressed));
        }
    }
}

