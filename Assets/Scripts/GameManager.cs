using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Canvas UICanvas { get; private set; }
    public CacheScript Cache { get; private set; }
    public PlayerData PlayerData { get; private set; }

    private void Awake()
    {
        Instance = this;
        UICanvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        Cache = GetComponent<CacheScript>();
        PlayerData = GetComponent<PlayerData>();
        PlayerData.LoadData();
    }

    public BaseWindow InstantiateWindow(string windowName)
    {
        return Instantiate(Cache.GetWindowByName(windowName), Consts.DEFAULT_WINDOW_SPAWN_POSITION, Quaternion.identity, UICanvas.transform);
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
