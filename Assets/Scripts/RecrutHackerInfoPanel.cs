using UnityEngine;
using UnityEngine.UI;

public class RecrutHackerInfoPanel : HackerInfoPanel
{
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

    protected override void SelectButtonOnClick()
    {
        GameManager.Instance.PlaySound("ButtonClick");
        recrutWindow.OnHackerSelected(index);
    }
}
