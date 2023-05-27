using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
