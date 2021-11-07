using System.Collections.Generic;
using UnityEngine;

public class MissionWindow : BaseWindow
{
    [SerializeField] private GameObject missionItemPrefab;
    [SerializeField] private RectTransform missionsContainer;

    private const int MISSSIONS_COUNT = 6;

    protected override void Awake()
    {
        base.Awake();
        InitMissions();
    }

    private void InitMissions()
    {
        if (GameManager.Instance.PlayerData.CurrentMissionsIds == null) //for old saves
            GameManager.Instance.PlayerData.CurrentMissionsIds = new List<int>();

        int id;
        for (int i = 0; i < MISSSIONS_COUNT; i++)
        {
            if (i >= GameManager.Instance.PlayerData.CurrentMissionsIds.Count)
            {
                do
                {
                    id = Random.Range(0, GameManager.Instance.Cache.GetMissionsCount());
                } while (GameManager.Instance.PlayerData.CurrentMissionsIds.Contains(id));
                GameManager.Instance.PlayerData.CurrentMissionsIds.Add(id);
            }
            else
                id = GameManager.Instance.PlayerData.CurrentMissionsIds[i];

            MissionInfoPanel missionInfoPanel = Instantiate(missionItemPrefab, missionsContainer).GetComponent<MissionInfoPanel>();
            missionInfoPanel.UpdateData(GameManager.Instance.Cache.GetMissionById(id));
        }
    }
}
