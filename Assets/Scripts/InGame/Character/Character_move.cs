using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CharacterState
{
    none,
    idle,
    move
}

public class Character_move : MonoBehaviour
{
    Vector move_dir;
    CharacterState _characterstate = 0;
    
    void Start()
    {

    }
    void Update()
    {
       if (!(move_dir == new Vector2(0,0)))
       {
            transform.position = Vector2.Lerp(transform.position, transform.position + move_dir)
       }

    }
}
