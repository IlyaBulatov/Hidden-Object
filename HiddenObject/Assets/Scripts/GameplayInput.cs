using System;
using UnityEngine;

namespace HiddenObjects
{
    public class GameplayInput : MonoBehaviour
    {
        public event Action<float> OnZoomPerformed;
        public event Action<Vector2> OnMoveDeltaPerformed;

        public RectTransform _inputMoveZone;

        private TouchInputMap _input;
        private SwipeDetection _swipeDetection;
        private ZoomDetection _approximationDetection;
        private TouchHendler _touchHandler;

        private void Start()
        {
            _input = new TouchInputMap();

            _swipeDetection = new SwipeDetection(_input, _inputMoveZone);
            _swipeDetection.OnMoveDeltaRecived += OnMoveDelta;
            _approximationDetection = new ZoomDetection(_input);
            _touchHandler = new TouchHendler(_input);
            
            _approximationDetection.OnApproximationDetect += OnApproximationDetectAction;

            _input.Enable();
        }
        
        private void OnApproximationDetectAction(float distance)
        {
            OnZoomPerformed?.Invoke(distance);
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void OnMoveDelta(Vector2 delta)
        {
            OnMoveDeltaPerformed?.Invoke(delta);
        }
    }
}
