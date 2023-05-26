using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class Wing : MonoBehaviour
{
    public UnityEngine.KeyCode keyCode;
    public Butterfly butterfly;
    public float upwardForce;
    public Transform anchorPoint;
    public float drag;
    public int dir;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        butterfly.transform.rotation = Quaternion.Inverse(Quaternion.identity);
    }
}
