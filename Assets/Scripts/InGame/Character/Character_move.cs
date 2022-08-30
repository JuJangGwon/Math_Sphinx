using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    none,
    idle,
    move,
    die
}
public enum CharacterDirection
{
    none = 0,
    front_left,
    front_right,
    back_left,
    back_right
}

public class Character_move : MonoBehaviour
{
    public static CharacterState _characterstate = 0; // 캐릭터 상태
    public static CharacterDirection _characterdirection = 0;
    public Vector3 move_dir;
    Animator _animator;
    float Character_speed = 5f;

    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (_characterstate == CharacterState.move && InGameManeger.gameState == GameState.playingInGame)
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + move_dir, Time.deltaTime * Character_speed);
            if (move_dir.x >= 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                if (move_dir.y >= 0)
                    _characterdirection = CharacterDirection.back_right;
                else
                    _characterdirection = CharacterDirection.front_right;
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                if (move_dir.y >= 0)
                    _characterdirection = CharacterDirection.back_left;
                else
                    _characterdirection = CharacterDirection.front_left;
            }
        }
    }
}
