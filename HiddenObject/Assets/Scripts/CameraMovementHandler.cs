using UnityEngine;

namespace HiddenObjects
{
    public class CameraMovementHandler : MonoBehaviour
    {
        public Transform playerObject;

        [SerializeField] private float _sensitivity = 1f;

        private GameplayInput _gameplayInput;
        private bool _enabled = true;

        private void Start()
        {
            _gameplayInput = GetComponent<GameplayInput>();

            _gameplayInput.OnMoveDeltaPerformed += SetDeltaMove;
        }
        public void OnSetEnable(bool value)
        {
            _enabled = value;
        }
        private void SetDeltaMove(Vector2 delta)
        {
            if(!_enabled)
            {
                return;
            }

            var dt = Time.deltaTime;

            var horizontal = dt * _sensitivity * delta.x;
            var vertical = dt * _sensitivity * delta.y;

            playerObject.position += new Vector3(-horizontal, -vertical, 0);
        }
    }
}