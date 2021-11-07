using UnityEngine;

public class BaseNotification : MonoBehaviour
{
    private RectTransform rectTransform;
    private float hidingPosX;
    private bool isClosing = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OpenNotification()
    {
        hidingPosX = rectTransform.sizeDelta.x * 2;
        rectTransform.anchoredPosition3D = new Vector3(hidingPosX, rectTransform.anchoredPosition3D.y);

        LeanTween.value(gameObject, hidingPosX, rectTransform.sizeDelta.x, Consts.NOTIFICATION_SHOWING_ANIM_TIME)
            .setOnUpdate((value) => rectTransform.anchoredPosition3D = new Vector3(value, rectTransform.anchoredPosition3D.y));
    }

    protected void CloseNotification()
    {
        if (!isClosing)
        {
            isClosing = true;
            LeanTween.cancel(gameObject);
            LeanTween.value(gameObject, rectTransform.sizeDelta.x, hidingPosX, Consts.NOTIFICATION_SHOWING_ANIM_TIME)
                .setOnUpdate((value) => rectTransform.anchoredPosition3D = new Vector3(value, rectTransform.anchoredPosition3D.y))
                .setOnComplete(() => Destroy(gameObject));
        }
    }
}
