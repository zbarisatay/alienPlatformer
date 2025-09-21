using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    private Animator anim;
    

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            
         
             anim.SetTrigger("DrawGun"); 
               
           
        }

        
        bool isMoving = Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01f;
        anim.SetBool("isShootingRun",isMoving);
        
    }
}
