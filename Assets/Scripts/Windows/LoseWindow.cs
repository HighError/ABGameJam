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
        GameManager.Instance.InstantiateWindow("MainWindow");
        ButtonCloseOnClick();
    }

    private void SetScoreText()
    {
        if (GameManager.Instance.PlayerData.CurrentScore >= GameManager.Instance.PlayerData.MaxScore)
        {
            scoreText.color = Color.yellow;
            GameManager.Instance.PlayerData.MaxScore = GameManager.Instance.PlayerData.CurrentScore;
        }
        EventSystem.CallOnRecordUpdateNeeded();
        scoreText.text = "Рахунок: " + GameManager.Instance.PlayerData.CurrentScore.ToString();
        GameManager.Instance.PlayerData.CreateNewData();
    }
}
