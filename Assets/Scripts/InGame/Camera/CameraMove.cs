using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Character;
    public Vector3 v3 = new Vector3(0,0,-5);
  
    
    void FixedUpdate()
    {
       
  
        //transform.position = Character.transform.position + v3;
        transform.position = Vector3.Lerp(transform.position, Character.transform.position + v3, Time.deltaTime*4);
    }
}
