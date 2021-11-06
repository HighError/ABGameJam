using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoseWindow : BaseWindow
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button okButton;

    protected override void Awake()
    {
        base.Awake();

        okButton.onClick.AddListener(OKButtonOnClick);
        SetScoreText();
    }

    private void OKButtonOnClick()
    {
        ButtonCloseOnClick();
    }

    private void SetScoreText()
    {
        scoreText.text = "Рахунок: " + GameManager.Instance.PlayerData.CurrentScore.ToString();
    }
}
