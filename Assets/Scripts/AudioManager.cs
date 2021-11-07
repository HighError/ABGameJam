using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource MusicAudioSource;
    [SerializeField] private AudioSource SoundAudioSource;

    private void Awake()
    {
        EventSystem.OnSoundSettingsUpdateNeeded += OnSoundSettingsUpdateNeeded;
    }

    private void OnDestroy()
    {
        EventSystem.OnSoundSettingsUpdateNeeded -= OnSoundSettingsUpdateNeeded;
    }

    public void PlaySound(string soundName)
    {
        SoundAudioSource.PlayOneShot(GameManager.Instance.Cache.GetSound(soundName));
    }

    private void OnSoundSettingsUpdateNeeded()
    {
        MusicAudioSource.enabled = !GameManager.Instance.PlayerData.NoMusic;
        SoundAudioSource.enabled = !GameManager.Instance.PlayerData.NoSound;
    }
}
