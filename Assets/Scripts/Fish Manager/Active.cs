using UnityEngine;

public class Fish2D : MonoBehaviour
{
    public float speed = 2f;
    public float directionChangeInterval = 2f;
    public Vector2 swimArea = new Vector2(8f, 4f);

    private Vector2 moveDirection;
    private float changeTimer;
    private Vector2 origin;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        origin = transform.parent != null ? transform.parent.position : Vector2.zero;
        spriteRenderer = GetComponent<SpriteRenderer>();
        PickNewDirection();
    }

    void Update()
    {
        changeTimer -= Time.deltaTime;

        if (changeTimer <= 0f)
            PickNewDirection();

        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Flip sprite based on direction
        if (moveDirection.x != 0)
            spriteRenderer.flipX = moveDirection.x < 0;
    }

    void PickNewDirection()
    {
        Vector2 randomOffset = new Vector2(
            Random.Range(-swimArea.x, swimArea.x),
            Random.Range(-swimArea.y, swimArea.y)
        );

        Vector2 target = origin + randomOffset;
        moveDirection = (target - (Vector2)transform.position).normalized;

        changeTimer = Random.Range(directionChangeInterval * 0.5f, directionChangeInterval * 1.5f);
    }
}
