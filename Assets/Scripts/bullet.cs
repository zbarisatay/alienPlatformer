using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;      
    public float lifeTime = 2f;     
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
        float direction = Mathf.Sign(transform.localScale.x);
        rb.linearVelocity = new Vector2(direction * speed, 0f);

        
        Destroy(gameObject, lifeTime);
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject); 
    }

}
