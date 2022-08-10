using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    none,
    idle,
    move
}

public class Character_move : MonoBehaviour
{
    public CharacterState _characterstate = 0; // 캐릭터 상태
    public Vector3 move_dir;
    float Character_speed = 5f;

    
    void Start()
    {

    }
    void Update()
    {
       if (_characterstate == CharacterState.move)
       {
            transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + move_dir,Time.deltaTime * Character_speed);
       }
    }
}
