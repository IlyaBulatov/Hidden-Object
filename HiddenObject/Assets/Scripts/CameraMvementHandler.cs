using System;
using UnityEngine;

namespace HiddenObjects
{
    public class CameraMvementHandler : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 1f;

        private GameplayInput _gameplayInput;

        private void Start()
        {
            _gameplayInput = GetComponent<GameplayInput>();

            _gameplayInput.OnMoveDeltaPerformed += SetDeltaMove;
        }

        private void SetDeltaMove(Vector2 delta)
        {
            var dt = Time.deltaTime;

            var horizontal = dt * _sensitivity * delta.x;
            var vertical = dt * _sensitivity * delta.y;

            transform.position += new Vector3(-horizontal, -vertical, 0);
        }
    }
}