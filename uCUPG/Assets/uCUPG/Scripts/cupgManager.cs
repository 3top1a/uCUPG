using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupgManager : MonoBehaviour
{
    public enum gType
    {
        Standart, Faux, FauxWithRotation
    } 

    public gType gravityType = gType.Standart;

    public float gravity = 9.8f;

    //Direction of gravity
    public Vector3 gDir = -Vector3.up;

    //Controlls how much the timeInAir var will change
    public float timeDevider = 2;

    public bool debug = true;


    void OnDrawGizmos()
    {
        if(debug)
        {
            if (gravityType == gType.Standart) 
            {

            }
            else if (gravityType == gType.Faux)
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawSphere(gDir, 5f);
            }
            else if (gravityType == gType.FauxWithRotation)
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawSphere(gDir, 5f);
            }
        }
    }

}
