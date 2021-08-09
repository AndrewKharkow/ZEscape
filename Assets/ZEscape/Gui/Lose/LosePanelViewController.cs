using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZEscape.Gui
{
    [RequireComponent(typeof(LosePanelView))]

    public class LosePanelViewController : MonoBehaviour
    {
        private LosePanelView View => GetComponent<LosePanelView>();

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