using UnityEngine;

public class MissionsUpdater : MonoBehaviour
{
    private float time = 0f;

    void Update()
    {
        time += Time.deltaTime;
        if (time > 1f)
        {
            time = 0f;
            if (GameManager.Instance.PlayerData.CurrentMissions != null)
            {
                for (int i = 0; i < GameManager.Instance.PlayerData.CurrentMissions.Count; i++)
                {
                    if (GameManager.Instance.PlayerData.CurrentMissions[i].CheckCompleted())
                        i--;
                }
            }
        }
    }
}
