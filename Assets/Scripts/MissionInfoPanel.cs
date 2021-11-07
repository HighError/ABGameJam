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

    private MissionData missionData;

    private void Awake()
    {
        selectButton.onClick.AddListener(SelectButtonOnClick);
    }

    public void UpdateData(MissionData _missionData)
    {
        missionData = _missionData;

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
        GameManager.Instance.PlaySound("ButtonClick");

        EventSystem.CallOnWindowsCloseNeeded();
        MissionsDetailInfoWindow missionInfoWindow = GameManager.Instance.InstantiateWindow("MissionsDetailInfoWindow").GetComponent<MissionsDetailInfoWindow>();
        missionInfoWindow.UpdateData(missionData);
    }
}
