using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HiddenObjects
{
    public class SwipeDetection
    {
        public event Action<Vector2> OnMoveDeltaRecived;

        private TouchInputMap _input;
        private RectTransform _inputMoveZone;

        public SwipeDetection(TouchInputMap input, RectTransform inputMoveZone)
        {
            this._input = input;

            _inputMoveZone = inputMoveZone;
            _input.Swipe.TouchPress.started += OnTouchStart;
            _input.Swipe.TouchPress.canceled += OnTouchEnd;
        }

        public void OnTouchStart(InputAction.CallbackContext context)
        {
            var touchPosition = _input.Swipe.TouchPosition.ReadValue<Vector2>();

            var isTouchInInputMoveZone = 
                RectTransformUtility.RectangleContainsScreenPoint(_inputMoveZone, touchPosition);

            if (isTouchInInputMoveZone)
            {
                _input.Swipe.TouchDelta.performed += OnTouchDeltaPerformed;
            }
        }

        private void OnTouchEnd(InputAction.CallbackContext context)
        {
            _input.Swipe.TouchDelta.performed -= OnTouchDeltaPerformed;
        } 

        public void OnTouchDeltaPerformed(InputAction.CallbackContext context)
        {
            var delta = context.ReadValue<Vector2>();
            OnMoveDeltaRecived?.Invoke(delta);
        }

        
    }
}