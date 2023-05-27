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
    public Material ButterflyMaterial;

    private GameManager gameManager;
    private float progress = 0;
    public Material material;
    
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
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //forwardForce.force = pointingDir * speed * Time.deltaTime;
        ButterflyEnable(false);
        ButterflyMaterial.SetFloat("_DissolveAmount", 0);
        material.color = Color.white;
        
    }

    private void Update()
    {
        Death();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            this.isAlive = false;
        }
    }

    void Death()
    {
        if (gameManager.StartingGame == true && isAlive == false)
        {
            progress += Time.deltaTime / 2;
            ButterflyMaterial.SetFloat("_DissolveAmount", Mathf.Lerp(0,1,progress));
        }

        if (progress >= 1)
        {
            material.color = Color.white;
            GameObject.Find("GameManager").GetComponent<SceneLoader>().Loadscene("Lose");
        }
    }
}