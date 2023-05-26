using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    public Rigidbody body;
    public float speed;
    public Vector3 pointingDir;

    public ConstantForce forwardForce;

    public void ButterflyEnable(bool _enable)
    {
        body.useGravity = _enable;
        forwardForce.enabled = _enable;
    }
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        //forwardForce.force = pointingDir * speed * Time.deltaTime;
        forwardForce.relativeForce = pointingDir * speed * Time.deltaTime;
        ButterflyEnable(false);
    }
    
}
