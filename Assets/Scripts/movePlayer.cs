using UnityEngine;
using UnityEngine.InputSystem;

public class movePlayer : MonoBehaviour
{


    void Update()
    {
        
    }

    void Flip()
    {
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
