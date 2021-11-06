using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionsDetailInfoPanel : BaseWindow
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI chanceText;
    [SerializeField] private List<Image> specializationImages;
    [SerializeField] private List<GameObject> addButtons;
    [SerializeField] private List<GameObject> hackersInfo;

    private MissionData missionData;

    public void UpdateData(MissionData _missionData)
    {
        missionData = _missionData;
        titleText.text = _missionData.Name;
        chanceText.text = $"Ўанс на усп≥х: {CalculateSuccessChance()}%";
        for (int i = 0; i < specializationImages.Count; i++)
        {
            if (i < _missionData.Specializations.Count)
                specializationImages[i].sprite = GameManager.Instance.Cache.GetSprite(_missionData.Specializations[i].ToString());
            else
                specializationImages[i].gameObject.SetActive(false);
        }
    }

    private int CalculateSuccessChance()
    {
        //TODO: create proc calculation
        return missionData.RewardProcent;
    }
}
