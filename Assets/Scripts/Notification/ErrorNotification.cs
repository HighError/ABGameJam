using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorNotification : BaseNotification
{
    private const float SHOW_TIME = 3;

    private float time = 0;
    private bool closed = false;

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= SHOW_TIME && !closed)
        {
            closed = true;
            CloseNotification();
        }
    }
}
