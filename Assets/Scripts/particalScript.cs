using UnityEngine;
using UnityEngine.Audio;

public class particalScript : MonoBehaviour 
{
    public AudioSource audioSource;
    public AudioClip killEnemySound;

    void Start() 
    {
        
        Destroy(gameObject, 0.5f);
        audioSource.PlayOneShot(killEnemySound);
    }
}
