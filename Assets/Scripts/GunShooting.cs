using UnityEngine;
using UnityEngine.InputSystem;
public class GunShooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public GameManager gameManager;
    public AudioSource audioSource;
    public AudioClip shootingSound;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(!gameManager.isGameStarted)
            return;
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            audioSource.PlayOneShot(shootingSound);
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

            
            bullet.transform.localScale = new Vector3(transform.localScale.x, 1, 1);
        }

    }
}
