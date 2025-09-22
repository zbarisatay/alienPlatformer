using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject closedDoor;
    public GameObject openedDoor;
    private bool isOpen = false;
    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isOpen)
        {
            if (isOpen) return;

            if(collision.CompareTag("Player"))
            {
                
                OpenDoor();
            }   
        }
    }   
     private void OpenDoor()
    {
        isOpen = true;

        if (closedDoor != null)
            closedDoor.SetActive(false);

        if (openedDoor != null)
        {
            
            Instantiate(openedDoor, closedDoor.transform.position, closedDoor.transform.rotation);
            openedDoor.SetActive(true); 
            Debug.Log("Kapı açıldı!");
            

        }
    }

}
