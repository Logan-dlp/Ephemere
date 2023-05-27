using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool StartingGame = false;
    
    public float MaxTime = 1440;
    public Text TimeText;
    public GameObject PressKey;

    [SerializeField] private Butterfly butterfly;

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

    void Starting()
    {
        if (StartingGame == false)
        {
            PressKey.SetActive(true);
            if (Input.anyKey)
            {
                PressKey.SetActive(false);
                butterfly.ButterflyEnable(true);
                StartingGame = true;
            }
        }
    }

    private void Start()
    {
        butterfly = GameObject.FindWithTag("Player").GetComponent<Butterfly>();
    }

    private void Update()
    {
        Starting();
        DisplayTime(MaxTime);
        if (StartingGame == true)
        {
            Timer();
        }
    }
}
