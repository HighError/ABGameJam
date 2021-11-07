using UnityEngine;

public class BaseNotification : MonoBehaviour
{
    protected RectTransform rectTransform;
    protected float hidingPosX;
    protected bool isClosing = false;

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

    protected virtual void CloseNotification()
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
