using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecrutHackerInfoPanel : HackerInfoPanel
{
    [SerializeField] private Button selectButton;

    private RecrutWindow recrutWindow;
    private int index;

    public void SetIndex(int _index)
    {
        index = _index;
    }

    public void SetRecrutWindow(RecrutWindow _recrutWindow)
    {
        recrutWindow = _recrutWindow;
    }

    public void ButtonSelectOnClick()
    {
        GameManager.Instance.PlaySound("ButtonClick");
        recrutWindow.OnHackerSelected(index);
    }
}
