using UnityEngine;

public class Updater : MonoBehaviour
{
    private float time = 0f;
    private float rectuteUpdateTime = Consts.RECRUTE_REFRESH_TIME;

    void Update()
    {
        time += Time.deltaTime;
        rectuteUpdateTime += Time.deltaTime;
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
        if (rectuteUpdateTime > Consts.RECRUTE_REFRESH_TIME)
        {
            rectuteUpdateTime = 0f;
            GameManager.Instance.PlayerData.recrutHackerList.Clear();
            for (int i = 0; i < Consts.RECRUTE_MAX_COUNT; i++)
            {
                GameManager.Instance.PlayerData.recrutHackerList.Add(Hacker.CreateRandomStats());
            }
        }
    }

    void OnEnable()
    {
        Debug.Log("Reset");
        time = 0f;
        rectuteUpdateTime = Consts.RECRUTE_REFRESH_TIME;
    }

    public float GetRecruteUpdateTime()
    {
        return rectuteUpdateTime;
    }

    public void SetRecruteUpdateTime(float _rectuteUpdateTime)
    {
        rectuteUpdateTime = _rectuteUpdateTime;
    }
}
