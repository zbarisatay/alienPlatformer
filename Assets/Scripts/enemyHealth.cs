using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 3;   // Düşmanın başlangıç canı
    private int currentHealth;
    public GameObject deadpartical;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Hasar alma fonksiyonu
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deadpartical, transform.position, Quaternion.identity);
        // Düşmanı kapat
        gameObject.SetActive(false);

        // İstersen burada patlama animasyonu veya ses oynatabilirsin
    }

    // Mermiyle çarpışmayı kontrol et
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            TakeDamage(1); // Her mermi 1 hasar versin
           
        }
    }
}

