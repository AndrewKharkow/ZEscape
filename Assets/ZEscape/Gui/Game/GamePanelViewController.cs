using System;
using UnityEngine;

namespace Game.Gui.Game
{
    [RequireComponent(typeof(GamePanelView))]
    public class GamePanelViewController : MonoBehaviour
    {
        private GamePanelView View => GetComponent<GamePanelView>();
        public float _aimPosX;
        public float _aimPosY;

        private float MaxWith;
        private float MaxHeight;

        private Vector2 _aimClampedPosition;

        public event Action<Vector2> FingerTap;

        private void Start()
        {
            MaxWith = Screen.width;
            MaxHeight = Screen.height;

            _aimPosX = View.Aim.rectTransform.position.x;
            _aimPosY = View.Aim.rectTransform.position.y;
        }


        private void Update()
        {
            if(Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                ReplaceAim(touch.deltaPosition.x, touch.deltaPosition.y);
            }
        }

        public void ReplaceAim(float xSpeed, float ySpeed)
        {
            _aimPosX += (xSpeed * 50) * Time.deltaTime;
            _aimPosY += (ySpeed * 50) * Time.deltaTime;

            _aimPosX = Mathf.Clamp(_aimPosX, 0, MaxWith);
            _aimPosY = Mathf.Clamp(_aimPosY, 0, MaxHeight);

            _aimClampedPosition = new Vector2(_aimPosX, _aimPosY);

            View.Aim.rectTransform.position = _aimClampedPosition;

            FingerTap?.Invoke(View.Aim.rectTransform.position);
        }
    }
}