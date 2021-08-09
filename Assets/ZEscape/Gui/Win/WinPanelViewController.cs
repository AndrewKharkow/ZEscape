using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZEscape.Gui
{
    [RequireComponent(typeof(WinPanelView))]

    public class WinPanelViewController : MonoBehaviour
    {
        private WinPanelView View => GetComponent<WinPanelView>();

        private void OnEnable()
        {
            View.TryAgainButton.onClick.AddListener(OnTryAgainButton);
        }

        private void OnTryAgainButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnDisable()
        {
            View.TryAgainButton.onClick.RemoveListener(OnTryAgainButton);
        }
    }
}