using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI baseChanceText;
    [SerializeField] private List<Image> specializationImages;
    [SerializeField] private Button selectButton;

    private void Awake()
    {
        selectButton.onClick.AddListener(SelectButtonOnClick);
    }

    public void UpdateData(MissionData missionData)
    {
        titleText.text = missionData.Name;
        baseChanceText.text = $"Базовий шанс успіху: {missionData.SuccessChance}%";
        for (int i = 0; i < specializationImages.Count; i++)
        {
            if (i < missionData.Specializations.Count)
            {
                specializationImages[i].sprite = GameManager.Instance.Cache.GetSprite(missionData.Specializations[i].ToString());
            }
            else
            {
                specializationImages[i].gameObject.SetActive(false);
            }
        }
    }

    private void SelectButtonOnClick()
    {
        MissionsDetailInfoPanel missionInfoWindow = GameManager.Instance.InstantiateWindow("MissionsDetailInfoPanel").GetComponent<MissionsDetailInfoPanel>();
        //missionInfoWindow
    }

}
