using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HackerInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hackerNameText;
    [SerializeField] private List<Image> specializationList;
    [SerializeField] private Image avatar;
    [SerializeField] private TextMeshProUGUI statusText;
    public void UpdateData(Hacker hacker)
    {
        hackerNameText.text = hacker.Stats.Name;
        avatar.sprite = GameManager.Instance.Cache.GetSprite(hacker.Stats.AvatarName);
        for (int i = 0; i < specializationList.Count; i++)
        {
            if (i < hacker.Stats.Specialization.Count)
            {
                specializationList[i].sprite = GameManager.Instance.Cache.GetSprite(hacker.Stats.Specialization[i].ToString());
            }
            else
            {
                specializationList[i].gameObject.SetActive(false);
            }
        }
        if (!statusText)
        {
            return;
        }
        if (hacker.IsBusy)
        {
            statusText.text = "Зайнятий";
            statusText.color = Color.red;
        }
        else
        {
            statusText.text = "Доступний";
            statusText.color = Color.green;
        }
    }
}
