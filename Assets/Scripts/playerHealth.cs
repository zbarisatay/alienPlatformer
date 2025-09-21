using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 5;
    private int currentHealth;

    [Header("Knockback")]
    public float knockbackForce = 5f;
    public float knockbackTime = 0.2f;
    private bool isKnocked = false;

    [Header("Invincibility")]
    public float invincibleTime = 1f;
    private bool isInvincible = false;

    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Hasar alma fonksiyonu
    public void TakeDamage(int damage, Vector2 enemyPosition)
    {
        if (isInvincible) return; // Invincible ise hasar alma

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Player Health: " + currentHealth);

        // Hurt animasyonunu tetikle
        if (anim != null)
        {
            anim.SetTrigger("Hurt");
        }

        if (currentHealth <= 0) Die();

        // Knockback uygulama
        Vector2 knockDirection = (transform.position - (Vector3)enemyPosition).normalized;
        StartCoroutine(KnockbackCoroutine(knockDirection));

        // Invincibility başlat
        StartCoroutine(InvincibleCoroutine());
    }

    private IEnumerator KnockbackCoroutine(Vector2 direction)
    {
        isKnocked = true;
        float timer = 0f;

        while (timer < knockbackTime)
        {
            rb.linearVelocity = direction * knockbackForce;
            timer += Time.deltaTime;
            yield return null;
        }

        rb.linearVelocity = Vector2.zero;
        isKnocked = false;
    }

    private IEnumerator InvincibleCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }

    private void Die()
    {
        Debug.Log("Player öldü!");
        // İsteğe bağlı: animasyon veya sahne reset
    }

    // Düşmanla çarpışmayı kontrol et
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") && !isInvincible)
        {
            TakeDamage(1, collision.transform.position);
        }
    }
}
