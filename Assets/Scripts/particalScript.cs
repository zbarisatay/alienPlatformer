using UnityEngine;

public class particalScript : MonoBehaviour 
{

    void Start() 
    {
        // Partikül sistemini 1 saniye sonra yok et
        Destroy(gameObject, 0.5f);
    }
}
