using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    //arrays containing the tabs and pages
    [SerializeField] private Image[] tabs;
    [SerializeField] private GameObject[] pages;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pressTab(0); //default to the first tab
    }


    public void pressTab(int tabIndex) {
        //make sure to disable all pages before enabling the selected one
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        pages[tabIndex].SetActive(true);
    }
}
