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
    private float checkLoseTimer = 0f;

    private Mission mission;

    public void SetInformation(Mission mission)
    {
        this.mission = mission;
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
            processText.text = $"{Decimal.Round(percent * 100, 1)}%";
            return;
        }
        else
        {
            checkLoseTimer += Time.deltaTime;
            if (checkLoseTimer > 0.2f)
                CloseNotification();
        }
    }

    protected override void CloseNotification()
    {
        if (!isClosing && !GameManager.Instance.PlayerData.CurrentMissions.Contains(mission))
        {
            isClosing = true;
            LeanTween.cancel(gameObject);

            icon.sprite = mission.IsSuccess ? successfullySprite : failSprite;
            processText.gameObject.SetActive(false);

            LeanTween.delayedCall(2f, () =>
            {
                LeanTween.value(gameObject, rectTransform.sizeDelta.x, hidingPosX, Consts.NOTIFICATION_SHOWING_ANIM_TIME)
                    .setOnUpdate((value) => rectTransform.anchoredPosition3D = new Vector3(value, rectTransform.anchoredPosition3D.y))
                    .setOnComplete(() => Destroy(gameObject));
            });
        }
    }
}
