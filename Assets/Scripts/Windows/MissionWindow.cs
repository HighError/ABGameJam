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
        List<int> usedIds = new List<int>();
        int id;
        for (int i = 0; i < MISSSIONS_COUNT; i++)
        {
            do
            {
                id = Random.Range(0, GameManager.Instance.Cache.GetMissionsCount());
            } while (usedIds.Contains(id));
            usedIds.Add(id);

            MissionInfoPanel missionInfoPanel = Instantiate(missionItemPrefab, missionsContainer).GetComponent<MissionInfoPanel>();
            missionInfoPanel.UpdateData(GameManager.Instance.Cache.GetMissionById(id));
        }
    }
}
