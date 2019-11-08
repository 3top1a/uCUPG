using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupgManager : MonoBehaviour
{
    //I.. I really dont know why 2
    //Pls someone fix my equation 
    public float g = 10;
    public float gravity = 9.8f;

    //Direction of gravity
    public Vector3 gDir = -Vector3.up;

    //Controlls how much the timeInAir var will change
    public float timeDevider = 5;
}
