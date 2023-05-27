using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class swing_wing : MonoBehaviour
{
    public Wing wing;
    public bool down;
    public float angle;

    public Quaternion initRotation;
    // Start is called before the first frame update
    void Start()
    {
        angle = -45;
        initRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!wing.butterfly.isAlive)
            return;
        if (down && angle < 0)
        {
            wing.transform.RotateAround(wing.anchorPoint.position, wing.butterfly.pointingDir, 500 * wing.dir * Time.deltaTime);
            angle += 500 * Time.deltaTime;
        }
        if (!down && angle > -45)
        {
            wing.transform.RotateAround(wing.anchorPoint.position, wing.butterfly.pointingDir, -500 * wing.dir * Time.deltaTime);
            angle -= 500 * Time.deltaTime;
        }
        Vector3 force = new Vector3(wing.upwardForce * wing.dir, wing.upwardForce / 3, 0);
        if (Input.GetKeyDown(wing.keyCode) || Input.GetButtonDown(wing.buttonName))
        {
            down = true;
            wing.butterfly.body.AddForceAtPosition(force, transform.position, ForceMode.VelocityChange);
        }

        if (Input.GetKeyUp(wing.keyCode) || Input.GetButtonUp(wing.buttonName))
        {
            down = false;
        }
        
    }
    
}
