using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZEscape.Gui
{
    public class Fade : MonoBehaviour
    {
        private Animator Animator => GetComponent<Animator>();

        private void OnEnable()
        {
            StartCoroutine(DisablePanel());
        }
        IEnumerator DisablePanel()
        {
            yield return new WaitForSeconds(0.4f);
            gameObject.SetActive(false);
        }
    }
}