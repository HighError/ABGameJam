using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextLevelWindow : BaseWindow
{
    [SerializeField] private TextMeshProUGUI locationNameText;
    [SerializeField] private TextMeshProUGUI debafText;

    void Start()
    {
        locationNameText.text = $"Ваша наступна локація: {GameManager.Instance.PlayerData.CurrentCity.Name}";
        debafText.text = $"Ускладнювач:\n{GameManager.Instance.PlayerData.CurrentCity.GetDebafInfo()}";
    }
}
