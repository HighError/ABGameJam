using UnityEngine;

[CreateAssetMenu(fileName = "GameCache", menuName = "ScriptableObjects/CacheSO")]
public class CacheSO : ScriptableObject
{
    public GameObject[] prefabs;
    public BaseWindow[] windows;
    public MissionData[] missions;
    public AudioClip[] sounds;
    public Sprite[] sprites;
    public City[] cities;
}
