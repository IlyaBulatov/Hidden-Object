using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenVillis : MonoBehaviour
{
    [SerializeField] private GameObject View;
    [SerializeField] private Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    private Collider2D objectCollider;

    private TouchInputMap _input;

    private void Start()
    {
        spriteRenderer = View.GetComponent<SpriteRenderer>();
        objectCollider = GetComponent<Collider2D>();
        _input = new TouchInputMap();
        _input.Enable();

        _input.Tap.Tap.performed += OnTapDawn;
    }

    private void OnTapDawn(InputAction.CallbackContext context)
    {
        var _touchPosition = _input.Tap.TapPosition.ReadValue<Vector2>();
        RaycastHit2D raycastHit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(_touchPosition), Vector2.zero, 10000f);
        print(raycastHit2D.collider.gameObject.name);
        if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject == gameObject)
        {
            OnMouseDown();
        }
    }

    private void OnMouseDown()
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
        if(objectCollider != null)
        {
            objectCollider.enabled = false;
        }
    }
}