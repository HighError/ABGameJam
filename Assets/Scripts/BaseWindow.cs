using UnityEngine;
using UnityEngine.UI;

public class BaseWindow : MonoBehaviour
{
    [SerializeField] private Button buttonClose;
    [SerializeField] private RectTransform clicksCatcher;

    private RectTransform rectTransform;
    protected Vector2 hidingPos;

    protected virtual void Awake()
    {
        if (!rectTransform)
            rectTransform = GetComponent<RectTransform>();

        if (!buttonClose)
            buttonClose = transform.Find("ButtonClose").GetComponent<Button>();
        buttonClose.onClick.AddListener(HideWindow);
    }

    public virtual void ShowWindow()
    {
        hidingPos = new Vector3(rectTransform.anchoredPosition3D.x, GameManager.Instance.UICanvas.pixelRect.size.y / 2 + rectTransform.sizeDelta.y);
        rectTransform.anchoredPosition3D = hidingPos;
        clicksCatcher.sizeDelta = GameManager.Instance.UICanvas.GetComponent<RectTransform>().sizeDelta;

        LeanTween.moveLocal(gameObject, Vector3.zero, Consts.WINDOW_SHOWING_ANIM_TIME);
    }

    public virtual void HideWindow()
    {
        LeanTween.moveLocal(gameObject, hidingPos, Consts.WINDOW_SHOWING_ANIM_TIME)
            .setOnComplete(() => Destroy(gameObject));
    }
}
