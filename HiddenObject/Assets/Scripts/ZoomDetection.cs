using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace HiddenObjects
{
    public class ZoomDetection
    {
        public event Action<float> OnApproximationDetect;

        private TouchInputMap _input;

        private Vector2 _firstTouchStartPosition;
        private Vector2 _secondTouchStartPosition;

        public ZoomDetection(TouchInputMap input)
        {
            this._input = input;

            _input.Approximation.TouchContact.started += DoubleTouchPerformed;
            _input.Approximation.TouchContact.canceled -= DoubleTouchPerformed;
        }

        private void DoubleTouchPerformed(InputAction.CallbackContext context)
        {
            _firstTouchStartPosition = _input.Approximation.FirctTouchPosition.ReadValue<Vector2>();
            _secondTouchStartPosition = _input.Approximation.FirctTouchPosition.ReadValue<Vector2>();

            _input.Approximation.Delta.performed += DeltaDoubleTouchPerformed;
        }

        private void DeltaDoubleTouchPerformed(InputAction.CallbackContext context)
        {
            DetectApproximation();
        }

        private void DetectApproximation()
        {
            Vector2 firstTouchPosition = _input.Approximation.FirctTouchPosition.ReadValue<Vector2>();
            Vector2 secondTouchPosition = _input.Approximation.FirctTouchPosition.ReadValue<Vector2>();

            float startDistance = Vector2.Distance(_firstTouchStartPosition, _secondTouchStartPosition);
            float distance = Vector2.Distance(firstTouchPosition, secondTouchPosition);

            var distanceDelta = distance - startDistance;

            OnApproximationDetect?.Invoke(distanceDelta);
        }
    }
}