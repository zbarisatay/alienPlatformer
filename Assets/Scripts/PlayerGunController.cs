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
        // get the gun with mause click
        if (Input.GetMouseButtonDown(1))
        {
            
         
             anim.SetTrigger("DrawGun"); 
               
           
        }

        // move with gun
        bool isMoving = Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01f;
        anim.SetBool("isShootingRun",isMoving);
        
    }
}
