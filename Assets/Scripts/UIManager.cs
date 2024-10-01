using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> gridItems;


    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void ShowItem(int itemIndex)
    {
        gridItems[itemIndex].SetActive(true);
    }

    private void Start()
    {
        foreach (GameObject item in gridItems)
        {
            item.SetActive(false);
        }
    }
}
