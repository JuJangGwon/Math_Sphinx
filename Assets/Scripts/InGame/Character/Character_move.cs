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
// (-15, 15) ,(-11, 17) (-11,13,) , (-7,15)
// 8, 6

public class Character_move : MonoBehaviour
{
    
    public static CharacterState _characterstate = 0; // 캐릭터 상태
    public static CharacterDirection _characterdirection = 0;
    public Vector3 move_dir;
    Animator _animator;
    Rigidbody2D _rigidbody2D;
    float Character_speed = 10f;

    public void Set_character_speed(bool _buttonOn)
    {
        if (_buttonOn)
        {
            Character_speed = 15f;
            _animator.speed = 1.5f;
        }
        else
        {
            Character_speed = 10f;
            _animator.speed = 1.5f;
        }
    }
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FindMyposition()
    {

        int dx, dy, tx, ty;
       

        int x = (int)transform.position.x + 0;
        int y = (int)transform.position.y + 0;

        dx = x / 4;
        dy = y / 3;
        tx = x % 4;
        ty = y % 3;
        int mx = 0 + dx + dy;
        int my = 0 - dx + dy;
    }

    void Update()
    {
        if (_characterstate == CharacterState.move && InGameManeger.gameState == GameState.playingInGame)
        {
            FindMyposition();
            //transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + move_dir, Time.deltaTime * Character_speed);
            _rigidbody2D.velocity = move_dir * Character_speed;
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
        else
        {
            _rigidbody2D.velocity = move_dir * 0;
        }
    }
}
