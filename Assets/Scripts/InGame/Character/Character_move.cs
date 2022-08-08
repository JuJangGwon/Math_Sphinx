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
    CharacterState _characterstate = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
         //   debug.log("1");
        }
    }
}
