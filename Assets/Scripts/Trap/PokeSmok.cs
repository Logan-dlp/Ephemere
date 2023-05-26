using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PokeSmok : MonoBehaviour
{
    public float ExplosionForce = 100;
    public float ExplosionRaduis = 100;
    public GameObject Particule;

    private void Start()
    {
        Particule.SetActive(false);
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.GetComponent<Rigidbody>())
        {
            Particule.SetActive(true);
            _other.GetComponent<Rigidbody>().AddExplosionForce(ExplosionForce, transform.position, ExplosionRaduis);
        }
    }
}
