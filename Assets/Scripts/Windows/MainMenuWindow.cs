using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : MonoBehaviour
{
    [SerializeField] private Button myHackersButton;
    [SerializeField] private Button recruitsButton;
    [SerializeField] private Button missionsButton;
    [SerializeField] private Button settingsButton;

    [SerializeField] private TextMeshProUGUI sabotageProcentText;
    [SerializeField] private TextMeshProUGUI loseProcentText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI recordText;

    private void Awake()
    {
        myHackersButton.onClick.AddListener(HyHackersButtonOnClick);
        recruitsButton.onClick.AddListener(RecruitsButtonOnClick);
        missionsButton.onClick.AddListener(MissionsButtonOnClick);
        settingsButton.onClick.AddListener(SettingsButtonOnClick);

        EventSystem.OnUpdateScoreNeeded += UpdateProcentsAndScore;
        EventSystem.OnRecordUpdateNeeded += UpdateRecord;
    }

    private void HyHackersButtonOnClick()
    {
        GameManager.Instance.PlaySound("ButtonClick");
        EventSystem.CallOnWindowsCloseNeeded();
        GameManager.Instance.InstantiateWindow("MyHackersWindow");
    }

    private void RecruitsButtonOnClick()
    {
        GameManager.Instance.PlaySound("ButtonClick");
        EventSystem.CallOnWindowsCloseNeeded();
        GameManager.Instance.InstantiateWindow("RecrutWindow");
    }

    private void MissionsButtonOnClick()
    {
        GameManager.Instance.PlaySound("ButtonClick");
        EventSystem.CallOnWindowsCloseNeeded();
        GameManager.Instance.InstantiateWindow("MissionsWindow");
    }

    private void SettingsButtonOnClick()
    {
        GameManager.Instance.PlaySound("ButtonClick");
        EventSystem.CallOnWindowsCloseNeeded();
        GameManager.Instance.InstantiateWindow("SettingsWindow");
    }

    private void UpdateProcentsAndScore()
    {
        sabotageProcentText.text = $"{GameManager.Instance.PlayerData.SabotageProcent}%";
        loseProcentText.text = $"{GameManager.Instance.PlayerData.LoseProcent}%";
        scoreText.text = GameManager.Instance.PlayerData.CurrentScore.ToString();

        if (GameManager.Instance.PlayerData.SabotageProcent >= 100)
        {
            GameManager.Instance.PlayerData.NextLevel();
        }
        else if (GameManager.Instance.PlayerData.LoseProcent >= 100)
        {
            GameManager.Instance.PlayerData.EndGame();
        }
    }

    public void UpdateRecord()
    {
        recordText.text = GameManager.Instance.PlayerData.MaxScore.ToString();
    }

    private void OnDestroy()
    {
        EventSystem.OnUpdateScoreNeeded -= UpdateProcentsAndScore;
    }
}
