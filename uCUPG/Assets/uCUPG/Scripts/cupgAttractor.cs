using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupgAttractor : MonoBehaviour
{
    public float pull = 9.8f;

    public Vector3 point = Vector3.zero;

    public bool debug = true;

    private cupgManager cm;

    void Start()
    {
        cm = FindObjectOfType<cupgManager>().GetComponent<cupgManager>();
    }

    void FixedUpdate()
    {
        cupgBody[] bodies = GameObject.FindObjectsOfType<cupgBody>();

        for (int i = 0; i < bodies.Length; i++)
        {
            Vector3 dirToPoint = (bodies[i].transform.position - point).normalized;    
            bodies[i].rb.AddForce(-dirToPoint * pull * bodies[i].mass);
        }              
    }

    void OnDrawGizmosSelected()
    {
        if(debug)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(point, 5f);
        }
    }
}
