using UnityEngine;

namespace Game.Gui.Game
{
    [RequireComponent(typeof(GamePanelView))]
    public class GamePanelViewController : MonoBehaviour
    {
        private GamePanelView View => GetComponent<GamePanelView>();
     
    }
}