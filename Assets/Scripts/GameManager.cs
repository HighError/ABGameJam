using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Canvas UICanvas { get; private set; }
    public CacheScript Cache { get; private set; }
    public PlayerData PlayerData { get; private set; }
    public Updater Updater { get; private set; }
    public NotificationManager NotificationManager {get; private set;}
    public AudioManager AudioManager { get; private set;}

    private void Awake()
    {
        Instance = this;
        UICanvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        NotificationManager = GameObject.FindGameObjectWithTag("NotificationManager").GetComponent<NotificationManager>();
        Cache = GetComponent<CacheScript>();
        PlayerData = GetComponent<PlayerData>();
        Updater = GetComponent<Updater>();
        AudioManager = GetComponent<AudioManager>();
        PlayerData.LoadData();

        EventSystem.CallOnSoundSettingsUpdateNeeded();
    }

    private void Start()
    {
        InstantiateWindow("MainWindow");
    }

    public BaseWindow InstantiateWindow(string windowName)
    {
        return Instantiate(Cache.GetWindowByName(windowName), Consts.DEFAULT_WINDOW_SPAWN_POSITION, Quaternion.identity, UICanvas.transform);
    }

    public void PlaySound(string soundName)
    {
        AudioManager.PlaySound(soundName);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
            PlayerData.SaveData();
    }

    private void OnApplicationQuit()
    {
        PlayerData.SaveData();
    }
}
