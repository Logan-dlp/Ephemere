using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    public Rigidbody body;
    public float speed;
    public Vector3 pointingDir;

    public ConstantForce forwardForce;
    // Start is called before the first frame update
    void Start()
    {
        //forwardForce.force = pointingDir * speed * Time.deltaTime;
        forwardForce.relativeForce = pointingDir * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
