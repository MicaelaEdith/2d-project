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
    [SerializeField]
    private Image imgPause;
    private bool pause = false;
    [SerializeField]
    private GameObject btnPause;
    [SerializeField]
    private GameObject menu;


    private void Awake()
    {
        instance = this;
        imgPause.enabled = false;
        menu.SetActive(false);
    }

    void Start()
    {
        foreach (GameObject item in gridItems)
        {
            item.SetActive(false);
        }

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

    public void OnButtonClick(string btnPause)
    {
        PauseMenu(pause);
        pause = !pause;
    }

    public void PauseMenu(bool pause)
    {
        if (!pause)
        {
            imgPause.enabled = true;
            Time.timeScale = 0f;
            menu.SetActive(true);
            btnPause.SetActive(false);
        }
        else
        {
            imgPause.enabled = false;
            Time.timeScale = 1f;
            menu.SetActive(false);
            btnPause.SetActive(true);
        }

    }

}
