using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float MaxTime = 100;

    void Timer()
    {
        if (MaxTime >= 0)
        {
            MaxTime -= Time.deltaTime;
        }
        else
        {
            MaxTime = 0;
        }
    }

    public void CursorMode(bool _on)
    {
        if (_on == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }else if (_on == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
