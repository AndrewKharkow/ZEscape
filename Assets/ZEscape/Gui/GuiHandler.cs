using UnityEngine;

namespace ZEscape.Gui
{
    public class GuiHandler : MonoBehaviour
    {
        public enum GuiState
        {
            Start,
            Game,
            Win,
            Lose
        }

        public StartPanelViewController Start;
        public GamePanelViewController Game;
        public WinPanelViewController Win;
        public LosePanelViewController Lose;
        public Fade Fade;

        private void OnEnable()
        {
            SetGuiState(GuiState.Start);
        }

        public void SetGuiState(GuiState state)
        {
            switch (state)
            {
                case GuiState.Start:
                    Start.gameObject.SetActive(true);
                    Game.gameObject.SetActive(false);
                    Win.gameObject.SetActive(false);
                    Lose.gameObject.SetActive(false);
                    break;
                case GuiState.Game:
                    Start.gameObject.SetActive(false);
                    Game.gameObject.SetActive(true);
                    Win.gameObject.SetActive(false);
                    Lose.gameObject.SetActive(false);
                    break;
                case GuiState.Win:
                    Start.gameObject.SetActive(false);
                    Game.gameObject.SetActive(false);
                    Win.gameObject.SetActive(true);
                    Lose.gameObject.SetActive(false);
                    break;
                case GuiState.Lose:
                    Start.gameObject.SetActive(false);
                    Game.gameObject.SetActive(false);
                    Win.gameObject.SetActive(false);
                    Lose.gameObject.SetActive(true);
                    break;
            }
        }
        public void FadeEffect()
        {
            Fade.gameObject.SetActive(true);
        }
    }
}