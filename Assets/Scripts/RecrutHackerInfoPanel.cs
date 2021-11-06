using UnityEngine;
using UnityEngine.UI;

public class RecrutHackerInfoPanel : HackerInfoPanel
{
    [SerializeField] private Button selectButton;

    private RecrutWindow recrutWindow;
    private int index;

    private void Awake()
    {
        selectButton.onClick.AddListener(ButtonSelectOnClick);
    }

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
