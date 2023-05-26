using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing_wing : MonoBehaviour
{
    public Wing wing;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = new Vector3(0, wing.upwardForce, 0);
        if (Input.GetKeyDown(wing.keyCode))
        {
            wing.transform.RotateAround(wing.anchorPoint.position, new Vector3(1, 0, 0), 45 * wing.dir);
            wing.body.AddForceAtPosition(force, transform.position, ForceMode.VelocityChange);
            wing.body.drag += wing.drag;
        }

        if (Input.GetKeyUp(wing.keyCode))
        {
            wing.transform.RotateAround(wing.anchorPoint.position, new Vector3(1, 0, 0), -45 * wing.dir);
            wing.body.drag -= wing.drag;
        }
    }
    
}
