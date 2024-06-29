using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HiddenObjects
{
    public class SwipeDetection
    {
        public event Action<Vector2> OnMoveDeltaRecived;

        private TouchInputMap _input;

        public SwipeDetection(TouchInputMap input)
        {
            this._input = input;

            _input.Swipe.TouchDelta.performed += OnTouchDeltaPerformed;
        }

        //public void OnTouchStart(InputAction.CallbackContext context)
        //{
        //    _input.Swipe.TouchDelta.performed += OnTouchDeltaPerformed;
        //}
        //
        //private void OnTouchEnd(InputAction.CallbackContext context)
        //{
        //    _input.Swipe.TouchDelta.performed -= OnTouchDeltaPerformed;
        //}

        public void OnTouchDeltaPerformed(InputAction.CallbackContext context)
        {
            var delta = context.ReadValue<Vector2>();
            OnMoveDeltaRecived?.Invoke(delta);
        }

        
    }
}