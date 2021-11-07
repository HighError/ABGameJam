using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpWindow : BaseWindow
{
    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;

    [SerializeField] private List<GameObject> pages;

    private int currentPage = 0;

    protected override void Awake()
    {
        base.Awake();

        buttonRight.onClick.AddListener(ButtonRightOnClick);
        buttonLeft.onClick.AddListener(ButtonLeftOnClick);
    }

    private void ButtonRightOnClick()
    {
        if (currentPage < pages.Count - 2)
        {
            pages[currentPage].SetActive(false);
            currentPage++;
            pages[currentPage].SetActive(true);
        }
    }

    private void ButtonLeftOnClick()
    {
        if (currentPage > 0)
        {
            pages[currentPage].SetActive(false);
            currentPage--;
            pages[currentPage].SetActive(true);
        }
    }
}
