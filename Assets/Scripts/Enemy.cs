using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 1f;
    
    private Rigidbody2D rb;
    private Vector2 direction;
    private Vector3 originalScale;

    private float health = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 targetDirection = (player.position - transform.position);
            direction = targetDirection.normalized;

            // Flips
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        if (direction.x > 0){
            // Faces right
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else if (direction.x < 0){
            // Faces left
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
    }

    void FixedUpdate()
    {
        if (player != null){
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void TakeDamage(int amount = 1){
        health -= amount;
        if (health <= 0){
            Destroy(gameObject);
            Stats.points += 1;
        }
    }
}