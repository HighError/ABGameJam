using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OverlayScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cityNameText;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button helpButton;

    private void Awake()
    {
        EventSystem.OnOverlayUpdateNeeded += OnOverlayUpdateNeeded;

        exitButton.onClick.AddListener(ExitButtonOnClick);
        helpButton.onClick.AddListener(HelpButtonOnClick);
    }

    private void HelpButtonOnClick()
    {
        GameManager.Instance.InstantiateWindow("HelpWindow");
    }

    private void ExitButtonOnClick()
    {
        Application.Quit();
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
