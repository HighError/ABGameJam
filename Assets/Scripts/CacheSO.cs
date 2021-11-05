using UnityEngine;

[CreateAssetMenu(fileName = "GameCache", menuName = "ScriptableObjects/CacheSO")]
public class CacheSO : ScriptableObject
{
    public GameObject[] prefabs;
    public BaseWindow[] windows;
}
