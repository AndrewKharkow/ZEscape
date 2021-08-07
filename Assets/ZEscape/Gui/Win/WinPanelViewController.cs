using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Gui.Win
{
    [RequireComponent(typeof(WinPanelView))]
    public class WinPanelViewController : MonoBehaviour
    {
        private WinPanelView View => GetComponent<WinPanelView>();

        private void OnNextLevelButton()
        {
            if(SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}