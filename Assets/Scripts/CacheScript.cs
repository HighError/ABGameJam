using System.Collections.Generic;
using UnityEngine;

public class CacheScript : MonoBehaviour
{
    [SerializeField] private CacheSO cacheSO;

    private Dictionary<string, GameObject> prefabs;
    private Dictionary<string, BaseWindow> windows;
    private Dictionary<int, MissionData> missions;
    private Dictionary<string, AudioClip> sounds;
    private Dictionary<string, Sprite> sprites;

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
        missions = new Dictionary<int, MissionData>();
        foreach (var mission in cacheSO.missions)
        {
            missions.Add(mission.Id, mission);
        }
        sounds = new Dictionary<string, AudioClip>();
        foreach (var sound in cacheSO.sounds)
        {
            sounds.Add(sound.name, sound);
        }
        sprites = new Dictionary<string, Sprite>();
        foreach (var sprite in cacheSO.sprites)
        {
            sprites.Add(sprite.name, sprite);
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

    public MissionData GetMissionById(int id)
    {
        if (missions.ContainsKey(id))
            return missions[id];
        return null;
    }

    public AudioClip GetSound(string soundName)
    {
        if (sounds.ContainsKey(soundName))
            return sounds[soundName];
        return null;
    }

    public Sprite GetSprite(string spriteName)
    {
        if (sprites.ContainsKey(spriteName))
            return sprites[spriteName];
        return null;
    }
}
