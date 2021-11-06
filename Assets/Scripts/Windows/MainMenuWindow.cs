using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : MonoBehaviour
{
    [SerializeField] private Button myHackersButton;
    [SerializeField] private Button recruitsButton;
    [SerializeField] private Button missionsButton;
    [SerializeField] private Button settingsButton;

    private void Awake()
    {
        myHackersButton.onClick.AddListener(HyHackersButtonOnClick);
        recruitsButton.onClick.AddListener(RecruitsButtonOnClick);
        missionsButton.onClick.AddListener(MissionsButtonOnClick);
        settingsButton.onClick.AddListener(SettingsButtonOnClick);
    }

    private void HyHackersButtonOnClick()
    {
        EventSystem.CallOnWindowsCloseNeeded();
        GameManager.Instance.InstantiateWindow("MyHackersWindow");
    }

    private void RecruitsButtonOnClick()
    {
        EventSystem.CallOnWindowsCloseNeeded();
        GameManager.Instance.InstantiateWindow("RecrutWindow");
    }

    private void MissionsButtonOnClick()
    {
        EventSystem.CallOnWindowsCloseNeeded();
        GameManager.Instance.InstantiateWindow("MissionsWindow");
    }

    private void SettingsButtonOnClick()
    {
        EventSystem.CallOnWindowsCloseNeeded();
        GameManager.Instance.InstantiateWindow("SettingsWindow");
    }
}
