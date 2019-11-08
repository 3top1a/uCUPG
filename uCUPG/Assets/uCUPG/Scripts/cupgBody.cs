using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Copyright (c) 2019 3top1a

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions
*/


public class cupgBody : MonoBehaviour
{
    //The title in the inspector 
    [Header("Physics properties")]
    //Mass of the object 
    public float mass = 1;

    //Density of the object (if zero, expect kraken)
    public float density = 1;

    //How bouncy the object is  
    public float bounciness = .6f;

    //Static friction of the object
    public float staticFriction = .6f;

    //A space only visible in the inspector
    [Space]

    //The force the object will have on creation 
    public Vector3 InitForce = Vector3.zero;

    //This script uses the rigidbody component
    private Rigidbody rb;

    //Time in air the object has. Detection made poorly.
    private float timeInAir = 1;

    //Refrence to the Gravity Manager
    private cupgManager cm;

    void Start()
    {
        cm = FindObjectOfType<cupgManager>().GetComponent<cupgManager>();

        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.mass = mass;
        rb.SetDensity(density);
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.AddForce(InitForce * cm.gravity);

        if(this.GetComponent<Collider>() != null){
            PhysicMaterial pm = new PhysicMaterial();
            pm.bounciness = bounciness;
            pm.staticFriction = staticFriction;
            gameObject.GetComponent<Collider>().material = pm;
        }
    }
    
    void FixedUpdate()
    {
        if (CheckIfGrounded())
            timeInAir = 1;
        else
            timeInAir += Time.fixedDeltaTime / cm.timeDevider;
        

        rb.AddForce(cm.gDir * cm.gravity * mass * timeInAir * timeInAir);
    }

    bool CheckIfGrounded()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, cm.gDir , out hit)){
            if(hit.distance < (transform.localScale.y / 2) + .1f){
                return true;
            }
        }

        return false;
    }

    void OnDrawGizmosSelected()
    {
        if(GetComponent<Rigidbody>() != null)
        {
            Gizmos.color = Color.blue;
            //Gizmos.DrawSphere(rb.centerOfMass, 0.5f);
            Gizmos.DrawSphere(rb.worldCenterOfMass, 0.5f);
        }

        if(InitForce != Vector3.zero){
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, (transform.position + InitForce));
        }
    }
}
