using System.Collections.Generic;
using UnityEngine;

public class MyHackersWindowScript : BaseWindow
{
    [SerializeField] private GameObject hackerInfoPrefab;
    [SerializeField] private RectTransform hackersInfoContainer;
    [SerializeField] private List<HackerInfoPanel> hackerInfoPanels;

    private const float SPACING = 10;

    private void Start()
    {
        InitHackersInfo();
    }

    private void InitHackersInfo()
    {
        hackersInfoContainer.sizeDelta = new Vector3(hackersInfoContainer.sizeDelta.x,
            (hackerInfoPrefab.GetComponent<RectTransform>().sizeDelta.y + SPACING) * GameManager.Instance.PlayerData.HackerInfoData.Count);
        foreach (var hacker in GameManager.Instance.PlayerData.HackerInfoData)
        {
            HackerInfoPanel hackerInfo = Instantiate(hackerInfoPrefab, hackersInfoContainer).GetComponent<HackerInfoPanel>();
            hackerInfo.UpdateData(hacker);

            hackerInfoPanels.Add(hackerInfo);
        }
    }

    public void HideBusyHackers()
    {
        foreach (var hackerInfo in hackerInfoPanels)
        {
            if (hackerInfo.IsHackerBusy())
                hackerInfo.gameObject.SetActive(false);
        }
    }

    public void EnableButtonsAndHideStatus()
    {
        foreach (var hackerInfo in hackerInfoPanels)
        {
            hackerInfo.DisableStatusAndEnableButton();
        }
    }
}
