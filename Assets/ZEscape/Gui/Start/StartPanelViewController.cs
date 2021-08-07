using UnityEngine;

namespace Game.Gui.Start
{
    [RequireComponent(typeof(StartPanelView))]
    public class StartPanelViewController :  MonoBehaviour
    {
        private StartPanelView View => GetComponent<StartPanelView>();
      
    }
}