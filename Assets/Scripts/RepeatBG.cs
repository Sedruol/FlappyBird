using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    private float spriteWidth;
    private BoxCollider2D groundCollider;
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        spriteWidth = groundCollider.size.x;
    }
    private void ResetPosition()
    {
        transform.Translate(new Vector3(2 * spriteWidth, 0f, 0f));
    }
    void Update()
    {
        if (transform.position.x < -spriteWidth)
        {
            ResetPosition();
        }
    }
}