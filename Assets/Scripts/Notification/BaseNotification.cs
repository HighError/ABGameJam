using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNotification : MonoBehaviour
{
    protected void OpenNotification()
    {
        // TODO: Зробити анімацію заповзання і виповзання нотифікацій
    }
    protected void CloseNotification()
    {
        // TODO: Зробити анімацію заповзання і виповзання нотифікацій
        Destroy(gameObject);
    }
}
