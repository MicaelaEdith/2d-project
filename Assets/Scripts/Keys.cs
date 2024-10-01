using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [SerializeField]
    private int num;
    private void OnTriggerEnter2D(Collider2D other)
{
            if (other.tag == "Player")
            {
                Destroy(gameObject);
            UIManager.instance.ShowItem(num-1);
            }
        }
 
}

