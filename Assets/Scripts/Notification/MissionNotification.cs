using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionNotification : BaseNotification
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI processText;

    [SerializeField] private Sprite progressBar;
    [SerializeField] private Sprite failSprite;
    [SerializeField] private Sprite successfullySprite;

    private bool done;
    private long endTime;
    private long startTime;

    public void SetInformation(Mission mission)
    {
        title.text = mission.MissionData.Name;
        icon.sprite = progressBar;
        done = false;
        startTime = mission.StartMissionTicks;
        endTime = mission.EndMissionTicks;
    }

    private void Update()
    {
        if (!done && startTime != 0 && endTime != 0)
        {
            long passedTime = DateTime.Now.Ticks - startTime;
            long totalTime = endTime - startTime;

            decimal percent = Decimal.Round((decimal)passedTime / totalTime, 3);
            if (percent >= 1)
            {
                percent = 1;
                done = true;
            }
            icon.fillAmount = (float)percent;
            processText.text = $"{Decimal.Round(percent * 100,1)}%";
            return;
        }
        else CloseNotification();
    }

}
