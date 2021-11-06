using System.Collections.Generic;
using UnityEngine;

public class CacheScript : MonoBehaviour
{
    [SerializeField] private CacheSO cacheSO;

    private Dictionary<string, GameObject> prefabs;
    private Dictionary<string, BaseWindow> windows;

    private void Awake()
    {
        prefabs = new Dictionary<string, GameObject>();
        foreach (var prefab in cacheSO.prefabs)
        {
            prefabs.Add(prefab.name, prefab);
        }
        windows = new Dictionary<string, BaseWindow>();
        foreach (var window in cacheSO.windows)
        {
            windows.Add(window.name, window);
        }
    }

    public GameObject GetPrefabByName(string prefabName)
    {
        if (prefabs.ContainsKey(prefabName))
            return prefabs[prefabName];
        return null;
    }

    public BaseWindow GetWindowByName(string windowName)
    {
        if (windows.ContainsKey(windowName))
            return windows[windowName];
        return null;
    }
}
