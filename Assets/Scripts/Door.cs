using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private int doorKey;
    private bool open = false;
 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (player.selectedObject == doorKey)
                {
                    Debug.Log("puerta: " + player.selectedObject + " = true");
                    OpenDoor();
                }
            }
        }
    }

    private void OpenDoor()
    {
        open = true;
        //GetComponent<Collider2D>().enabled = false;
        UIManager.instance.DestroyItem(doorKey-1);
    }
}
