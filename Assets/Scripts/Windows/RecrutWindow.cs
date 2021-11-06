using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecrutWindow : BaseWindow
{
    private const int INIT_HACKERS = 3;

    [SerializeField] private GameObject content;
    [SerializeField] private GameObject prefabItem;

    private List<Hacker.HackerStats> hackerList;

    private void Start()
    {
        hackerList = new List<Hacker.HackerStats>();
        for (int i = 0; i < INIT_HACKERS; i++)
        {
            hackerList.Add(Hacker.CreateRandomStats());
            var panel = Instantiate(prefabItem, content.transform).GetComponent<RecrutHackerInfoPanel>();
            panel.SetIndex(i);
            panel.SetRecrutWindow(this);
            panel.UpdateData(new Hacker { Stats = hackerList[i] });
        }
    }

    public void OnHackerSelected(int index)
    {
        GameManager.Instance.PlayerData.HackerInfoData.Add(new Hacker { Stats = hackerList[index] });
        HideWindow();
    }
}
