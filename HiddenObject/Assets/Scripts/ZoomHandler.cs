using System;
using UnityEngine;

namespace HiddenObjects
{
    public class ZoomHandler : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 1f;

        private Camera _camera;
        private GameplayInput _gameplayInput;

        private void Start()
        {
            _gameplayInput = GetComponent<GameplayInput>();
            _camera = GetComponent<Camera>();

            _gameplayInput.OnZoomPerformed += OnZoomPerformed;
        }

        private void OnZoomPerformed(float obj)
        {
            var dt = Time.deltaTime;
            var zoom = obj * _sensitivity * dt;
            _camera.orthographicSize += zoom;
        }
    }
}