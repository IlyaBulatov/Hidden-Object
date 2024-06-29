using System;
using UnityEngine;
using UnityEngine.UI;

namespace HiddenObjects
{
    public class GameplayInput : MonoBehaviour
    {
        public event Action<Vector2> OnMoveDeltaPerformed;

        private TouchInputMap _input;
        private SwipeDetection _swipeDetection;
        //private ApproximationDetection _approximationDetection;

        private void Start()
        {
            _input = new TouchInputMap();

            _swipeDetection = new SwipeDetection(_input);
            _swipeDetection.OnMoveDeltaRecived += OnMoveDelta;
            //_approximationDetection = new ApproximationDetection(_input);
            //
            //_approximationDetection.DoubleTouch += ApproximationDetectionOnDoubleTouch;
            //_approximationDetection.DeltaDoubleTouch += ApproximationDetectionOnDeltaDoubleTouch;
            //_approximationDetection.OnApproximationDetect += OnApproximationDetectAction;

            _input.Enable();
        }

        //private void ApproximationDetectionOnDoubleTouch()
        //{
        //    
        //
        //}
        //
        //private void ApproximationDetectionOnDeltaDoubleTouch()
        //{
        //    
        //}
        //
        //private void OnApproximationDetectAction()
        //{
        //    
        //}

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
