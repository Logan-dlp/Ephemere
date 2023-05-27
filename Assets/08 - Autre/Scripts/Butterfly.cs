using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    public Rigidbody body;
    public float speed;
    public Vector3 pointingDir;
    public bool isAlive;
    public ConstantForce forwardForce;

    public void ButterflyEnable(bool _enable)
    {
        body.useGravity = _enable;
        forwardForce.enabled = _enable;
        if (_enable)
        {
            forwardForce.relativeForce = speed * pointingDir;
            isAlive = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        //forwardForce.force = pointingDir * speed * Time.deltaTime;
        ButterflyEnable(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            this.isAlive = false;
        }
    }
}