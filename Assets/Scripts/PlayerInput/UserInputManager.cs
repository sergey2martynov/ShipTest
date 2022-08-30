using System;
using UnityEngine;

namespace PlayerInput
{
    public class UserInputManager : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        
        public event Action ButtonMousePressed;
        public event Action ButtonMouseHold;
        public event Action ButtonMouseReleased;

        public Camera Camera => _camera;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ButtonMousePressed?.Invoke();
            }

            if (Input.GetMouseButton(0))
            {
                ButtonMouseHold?.Invoke();
            }

            if (Input.GetMouseButtonUp(0))
            {
                ButtonMouseReleased?.Invoke();
            }
        }
    }
}
