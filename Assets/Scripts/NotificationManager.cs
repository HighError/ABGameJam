using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    [SerializeField] private GameObject content;

    [SerializeField] private GameObject missionPrefab;
    [SerializeField] private GameObject errorPrefab;

    private const float PREFAB_SIZE = 200;
    private const float SPACE_BETWEEN_PREFABS = 10;

    private void Awake()
    {
        EventSystem.OnNotificationsShowNeeded += OnNotificationsShowNeeded;
    }

    private void OnDestroy()
    {
        EventSystem.OnNotificationsShowNeeded -= OnNotificationsShowNeeded;
    }

    public void UpdateSizeContent()
    {
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(
            content.GetComponent<RectTransform>().sizeDelta.x, 
            (PREFAB_SIZE + SPACE_BETWEEN_PREFABS)*content.transform.childCount);
    }

    public void AddNotification(Enums.Notification type, Mission mission = null)
    {
        if (type == Enums.Notification.Mission && mission != null)
        {
            MissionNotification missionNotification = Instantiate(missionPrefab, content.transform).GetComponent<MissionNotification>();
            missionNotification.SetInformation(mission);
            missionNotification.OpenNotification();
        }
        else if (type == Enums.Notification.Error)
        {
            ErrorNotification notification = Instantiate(errorPrefab, content.transform).GetComponent<ErrorNotification>();
            notification.OpenNotification();
        }
        UpdateSizeContent();
    }

    private void OnNotificationsShowNeeded()
    {
        foreach (var mission in GameManager.Instance.PlayerData.CurrentMissions)
        {
            GameManager.Instance.NotificationManager.AddNotification(Enums.Notification.Mission, mission);
        }
    }
}
