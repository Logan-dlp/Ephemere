using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float MaxTime = 100;
    public Text TimeText;

    public void DisplayTime(float _timer)
    {
        if (_timer <= 0)
        {
            _timer = 0;
        }

        float _hour = Mathf.FloorToInt(_timer / 60);
        float _minute = Mathf.FloorToInt(_timer % 60);

        TimeText.text = string.Format("{0:00}:{1:00}", _hour, _minute);
    }
    
    void Timer()
    {
        if (MaxTime >= 0)
        {
            MaxTime -= Time.deltaTime; // à changer pour pas que la partie dur 24min pcq Agathe veut pas :,(
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