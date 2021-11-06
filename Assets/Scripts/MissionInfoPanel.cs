using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MissionInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI baseChanceText;
    [SerializeField] private List<Image> specializationImage;

    public void UpdateData(Mission mission)
    {
        titleText.text = mission.MissionData.Name;
        baseChanceText.text = $"Базовий шанс успіху: {mission.MissionData.SuccessChance}%";
        for (int i = 0; i < specializationImage.Count; i++)
        {
            if (i < mission.MissionData.Specializations.Count)
            {
                specializationImage[i].sprite = GameManager.Instance.Cache.GetSprite(mission.MissionData.Specializations[i].ToString());
            }
            else
            {
                specializationImage[i].gameObject.SetActive(false);
            }
        }
    }
}
