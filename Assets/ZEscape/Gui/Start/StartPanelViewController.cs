using System;
using UnityEngine;

namespace ZEscape.Gui
{
    [RequireComponent(typeof(StartPanelView))]

    public class StartPanelViewController : MonoBehaviour
    {
        private StartPanelView View => GetComponent<StartPanelView>();
        public event Action StartGame;

        private void OnEnable()
        {
            View.StartGame.onClick.AddListener(OnStartGameClick);
        }

        private void OnStartGameClick()
        {
            StartGame?.Invoke();
        }

        private void OnDisable()
        {
            View.StartGame.onClick.RemoveListener(OnStartGameClick);
        }
    }
}