using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZEscape.Gui
{
    [RequireComponent(typeof(LosePanelView))]

    public class LosePanelViewController : MonoBehaviour
    {
        private LosePanelView View => GetComponent<LosePanelView>();

        private void OnRestartGameButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}