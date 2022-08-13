using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetPlayer : MonoBehaviour
{
    public Vector3 move_dir;
    public float Character_speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + move_dir, Time.deltaTime * Character_speed);
    }
}
