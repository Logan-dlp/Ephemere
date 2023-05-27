using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFan : MonoBehaviour
{
    public Vector3 dir;
    public float strength;
    public GameObject particule;

    public GameObject fan;
    // Start is called before the first frame update
    void Start()
    {
        particule.SetActive(true);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        float distance = Vector3.Distance(fan.transform.position.normalized, other.transform.position.normalized);
        if (other.GetComponent<Butterfly>())
        {
            print(dir * strength * Time.deltaTime * (1 / distance));
            other.GetComponent<Rigidbody>().AddForce(dir * strength * Time.deltaTime * (1 / distance), ForceMode.Impulse);
        }
    }
}
