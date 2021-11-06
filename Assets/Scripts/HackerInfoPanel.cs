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
    [SerializeField] private Button selectButton;

    private bool isBusy;

    private void Awake()
    {
        selectButton.onClick.AddListener(SelectButtonOnClick);
    }

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

        isBusy = hacker.IsBusy;

        if (isBusy)
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

    public bool IsHackerBusy()
    {
        return isBusy;
    }

    public void DisableStatusAndEnableButton()
    {
        statusText.gameObject.SetActive(false);
        selectButton.gameObject.SetActive(true);
    }

    private void SelectButtonOnClick()
    {

    }
}
