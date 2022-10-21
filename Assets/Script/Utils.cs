using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Vector3 ScreenToWorld(Camera cam, Vector3 pos)
    {
        pos.z = cam.nearClipPlane;          //Ray R = cam.ScreenPointToRay(pos); 
        return cam.ScreenToWorldPoint(pos);
    }   
}
