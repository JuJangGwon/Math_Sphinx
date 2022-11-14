using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject character;
    public Vector3 v3;
  
    
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, character.transform.position + v3, Time.deltaTime*3f);
    }
}
