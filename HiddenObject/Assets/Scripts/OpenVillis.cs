using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HiddenObjects {
    public class OpenVillis : MonoBehaviour, ITouchable
    {
        [SerializeField] private GameObject View;
        [SerializeField] private Sprite newSprite;
        private SpriteRenderer spriteRenderer;
        private Collider2D objectCollider;


        private void Start()
        {
            spriteRenderer = View.GetComponent<SpriteRenderer>();
            objectCollider = GetComponent<Collider2D>();
        }

        public void Touch()
        {
            if (spriteRenderer != null && newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
            }
            if (objectCollider != null)
            {
                objectCollider.enabled = false;
            }
        }
    }
}