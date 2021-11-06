using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecrutWindow : BaseWindow
{
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject prefabItem;

    [SerializeField] private List<RecrutHackerInfoPanel> recrutHackerInfoPanel;

    private void Start()
    {
        recrutHackerInfoPanel = new List<RecrutHackerInfoPanel>();
        for (int i = 0; i < GameManager.Instance.PlayerData.recrutHackerList.Count; i++)
        {
            recrutHackerInfoPanel.Add(Instantiate(prefabItem, content.transform).GetComponent<RecrutHackerInfoPanel>());
            recrutHackerInfoPanel[i].SetIndex(i);
            recrutHackerInfoPanel[i].SetRecrutWindow(this);
            recrutHackerInfoPanel[i].UpdateData(new Hacker { Stats = GameManager.Instance.PlayerData.recrutHackerList[i] });
        }
    }

    public void OnHackerSelected(int index)
    {
        GameManager.Instance.PlaySound("ButtonClick");
        GameManager.Instance.PlayerData.HackerInfoData.Add(new Hacker { Stats = GameManager.Instance.PlayerData.recrutHackerList[index] });
        GameManager.Instance.PlayerData.recrutHackerList.RemoveAt(index);
        HideWindow();
    }
}
