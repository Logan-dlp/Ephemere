using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

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
    void FixedUpdate()
    {
        if (!wing.butterfly.isAlive)
            return;
        if (down && angle < 0)
        {
            wing.transform.RotateAround(wing.anchorPoint.position, wing.butterfly.pointingDir, 10 * wing.dir);
            angle += 10;
        }
        if (!down && angle > -45)
        {
            wing.transform.RotateAround(wing.anchorPoint.position, wing.butterfly.pointingDir, -10 * wing.dir);
            angle -= 10;
        }
        Vector3 force = new Vector3(wing.upwardForce * wing.dir, wing.upwardForce / 3, 0);
        if (Input.GetKeyDown(wing.keyCode))
        {
            down = true;
            wing.butterfly.body.AddForceAtPosition(force, transform.position, ForceMode.VelocityChange);
            //wing.butterfly.body.drag += wing.drag;
        }

        if (Input.GetKeyUp(wing.keyCode))
        {
            down = false;
            //wing.butterfly.body.drag -= wing.drag;
        }
        
    }
    
}
