using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> gridItems;
    private List<GameObject> visibleItems = new List<GameObject>();
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void ShowItem(int itemIndex)
    {
        if (itemIndex < gridItems.Count)
        {
            gridItems[itemIndex].SetActive(true);
            visibleItems.Add(gridItems[itemIndex]);
        }
    }
    public void DestroyItem(int itemIndex)
    {
        if (itemIndex < gridItems.Count)
        {
            gridItems[itemIndex].SetActive(false);
            visibleItems.Remove(gridItems[itemIndex]);
        }
    }

    public List<GameObject> GetVisibleItems()
    {
        return visibleItems;
    }

    private void Start()
    {
        foreach (GameObject item in gridItems)
        {
            item.SetActive(false);
        }
    }
}
