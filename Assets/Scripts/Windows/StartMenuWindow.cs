using UnityEngine;
using UnityEngine.UI;

public class StartMenuWindow : BaseWindow
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button settingsButton;

    protected override void Awake()
    {
        base.Awake();

        newGameButton.onClick.AddListener(NewGameButtonOnClick);
        settingsButton.onClick.AddListener(SettingsButtonOnClick);
    }

    private void NewGameButtonOnClick()
    {

    }

    private void SettingsButtonOnClick()
    {

    }
}
