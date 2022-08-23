using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetPlayer : MonoBehaviour
{
    //public Vector3 move_dir;
    public float Character_speed = 5f;
    public Animator anime;
    [HideInInspector] public int right_move = Animator.StringToHash("Right_Move");
    [HideInInspector] public int left_move = Animator.StringToHash("Left_Move");
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + move_dir, Time.deltaTime * Character_speed);
    }

    void Move(Transform current_position, Transform target_position, float speed)
    {
        //포물선 이동
    }
}
