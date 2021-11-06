using UnityEngine;

public class MyHackersWindowScript : BaseWindow
{
    [SerializeField] private GameObject hackerInfoPrefab;
    [SerializeField] private RectTransform hackersInfoContainer;

    private void Start()
    {
        InitHackersInfo();
    }

    private void InitHackersInfo()
    {
        foreach (var hacker in GameManager.Instance.PlayerData.HackerInfoData)
        {
            HackerInfoPanel hackerInfo = Instantiate(hackerInfoPrefab, hackersInfoContainer).GetComponent<HackerInfoPanel>();
            hackerInfo.UpdateData(hacker);
        }
    }
}
