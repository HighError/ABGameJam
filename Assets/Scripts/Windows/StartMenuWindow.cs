using UnityEngine;
using UnityEngine.UI;

public class StartMenuWindow : BaseWindow
{
    [SerializeField] private Button newGameButton;

    protected override void Awake()
    {
        base.Awake();

        newGameButton.onClick.AddListener(NewGameButtonOnClick);
    }

    private void NewGameButtonOnClick()
    {
        GameManager.Instance.PlayerData.CreateNewData();
        GameManager.Instance.Updater.enabled = true;
        EventSystem.CallOnUpdateScoreNeeded();
        HideWindow();
    }
}
