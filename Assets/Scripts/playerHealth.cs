using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<GameObject> healths = new List<GameObject>();

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
        healths[currentHealth].SetActive(false);

        Debug.Log("Player Health: " + currentHealth);

        // Hurt animasyonunu tetikle
        if (anim != null)
        {
            anim.SetTrigger("Hurt");
        }

        if (currentHealth <= 0)
        {
            Die();
            return; // Ölünce diğer şeyleri yapma
        }

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

        // Ölüm animasyonu varsa çalıştır
        if (anim != null)
        {
            anim.SetTrigger("Die");
        }

        // Game Over ekranını aç
        FindObjectOfType<GameManager>().GameOver();

        // Karakteri kapatmak istersen:
        // gameObject.SetActive(false);
    }

    // Düşmanla çarpışmayı kontrol et
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") && !isInvincible)
        {
            TakeDamage(1, collision.transform.position);
        }

        if (collision.CompareTag("heart"))
        {
            if (currentHealth < maxHealth)
            {
                currentHealth++;
                healths[currentHealth - 1].SetActive(true);
                Destroy(collision.gameObject);
            }
        }
    }
}
