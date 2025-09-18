using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;       // Mermi hızı
    public float lifeTime = 2f;     // Merminin maksimum yaşam süresi
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Karakterin baktığı yöne göre hareket
        float direction = Mathf.Sign(transform.localScale.x);
        rb.linearVelocity = new Vector2(direction * speed, 0f);

        // Belirli bir süre sonunda yok et (önlem: boşa sonsuza gitmesin)
        Destroy(gameObject, lifeTime);
    }

    // Bir şeye çarptığında yok et
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); // trigger’a girince yok olur
    }

}
