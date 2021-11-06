using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HackerForMissionInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hackerNameText;
    [SerializeField] private List<Image> specializationList;
    [SerializeField] private Button cancelButton;

    private MissionsDetailInfoWindow detailInfoWindow;
    private Hacker hacker;
    private int hackerIndex = 9999;

    private void Awake()
    {
        cancelButton.onClick.AddListener(CancelButtonOnClick);
    }

    public void SetDataAndInit(MissionsDetailInfoWindow _detailInfoWindow, Hacker _hacker, int _hackerIndex)
    {
        hackerIndex = _hackerIndex;
        detailInfoWindow = _detailInfoWindow;
        hacker = _hacker;
        hackerNameText.text = _hacker.Stats.Name;

        for (int i = 0; i < specializationList.Count; i++)
        {
            if (i < hacker.Stats.Specialization.Count)
                specializationList[i].sprite = GameManager.Instance.Cache.GetSprite(hacker.Stats.Specialization[i].ToString());
            else
                specializationList[i].gameObject.SetActive(false);
        }
    }

    private void CancelButtonOnClick()
    {
        detailInfoWindow.CancelButtonOnClick(hackerIndex);
    }
}
