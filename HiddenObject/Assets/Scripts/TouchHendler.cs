using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HiddenObjects
{
    public class TouchHendler
    {
        private TouchInputMap _input;

        public TouchHendler(TouchInputMap input)
        {
            _input = input;

            _input.Tap.Tap.performed += OnTapDawn;
        }

        private void OnTapDawn(InputAction.CallbackContext context)
        {
            var _touchPosition = _input.Tap.TapPosition.ReadValue<Vector2>();
            RaycastHit2D raycastHit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(_touchPosition), Vector2.zero, 10000f);

            
            if (
                raycastHit2D.collider != null 
                && raycastHit2D.collider.gameObject.TryGetComponent<ITouchable>(out var touchble))
            {
                touchble.Touch();
            }
        }
    }
}