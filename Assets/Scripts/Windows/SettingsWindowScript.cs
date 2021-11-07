using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindowScript : BaseWindow
{
    [SerializeField] private Button musicButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button resetRecordButton;

    [SerializeField] private Sprite enabledSprite;
    [SerializeField] private Sprite disabledSprite;

    protected override void Awake()
    {
        base.Awake();

        musicButton.onClick.AddListener(MusicButtonOnClick);
        soundButton.onClick.AddListener(SoundButtonOnClick);
        resetRecordButton.onClick.AddListener(ResetButtonOnClick);

        UpdateButtonSprites();
    }

    private void UpdateButtonSprites()
    {
        musicButton.image.sprite = GameManager.Instance.PlayerData.NoMusic ? disabledSprite : enabledSprite;
        soundButton.image.sprite = GameManager.Instance.PlayerData.NoSound ? disabledSprite : enabledSprite;
    }

    private void MusicButtonOnClick()
    {
        GameManager.Instance.PlaySound("ButtonClick");

        GameManager.Instance.PlayerData.NoMusic = !GameManager.Instance.PlayerData.NoMusic;
        musicButton.image.sprite = GameManager.Instance.PlayerData.NoMusic ? disabledSprite : enabledSprite;
        EventSystem.CallOnSoundSettingsUpdateNeeded();
    }

    private void SoundButtonOnClick()
    {
        GameManager.Instance.PlayerData.NoSound = !GameManager.Instance.PlayerData.NoSound;
        soundButton.image.sprite = GameManager.Instance.PlayerData.NoSound ? disabledSprite : enabledSprite;
        EventSystem.CallOnSoundSettingsUpdateNeeded();

        GameManager.Instance.PlaySound("ButtonClick");
    }

    private void ResetButtonOnClick()
    {
        GameManager.Instance.PlayerData.MaxScore = 0;
        EventSystem.CallOnRecordUpdateNeeded();
    }
}
