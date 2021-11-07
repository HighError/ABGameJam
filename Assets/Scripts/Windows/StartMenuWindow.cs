using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuWindow : BaseWindow
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueButton;

    protected override void Awake()
    {
        base.Awake();

        newGameButton.onClick.AddListener(NewGameButtonOnClick);
        continueButton.onClick.AddListener(ContinueButtonOnClick);

        //TODO: change to some normal check
        continueButton.interactable = File.Exists(Application.persistentDataPath + "/gamesave.save");
    }

    private void NewGameButtonOnClick()
    {
        GameManager.Instance.PlaySound("ButtonClick");
        GameManager.Instance.PlayerData.CreateNewData();
        GameManager.Instance.Updater.enabled = true;
        EventSystem.CallOnUpdateScoreNeeded();
        HideWindow();
    }

    private void ContinueButtonOnClick()
    {
        GameManager.Instance.PlaySound("ButtonClick");
        GameManager.Instance.Updater.enabled = true;
        EventSystem.CallOnUpdateScoreNeeded();
        EventSystem.CallOnNotificationsShowNeeded();
        EventSystem.CallOnOverlayUpdateNeeded();
        HideWindow();
    }
}
