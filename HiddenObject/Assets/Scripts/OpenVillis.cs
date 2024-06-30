using UnityEngine;

public class OpenVillis : MonoBehaviour
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