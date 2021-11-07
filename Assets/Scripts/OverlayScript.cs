using TMPro;
using UnityEngine;

public class OverlayScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cityNameText;

    private void Awake()
    {
        EventSystem.OnOverlayUpdateNeeded += OnOverlayUpdateNeeded;
    }

    private void OnDestroy()
    {
        EventSystem.OnOverlayUpdateNeeded -= OnOverlayUpdateNeeded;
    }

    private void OnOverlayUpdateNeeded()
    {
        cityNameText.text = GameManager.Instance.PlayerData.CurrentCity.Name;
    }
}
