using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Animator _animator;
    public Rigidbody2D _rigidbody2D;
    float Character_speed = 10f;
    public AudioSource audiosource;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


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
   
  
    public void CharacterStop(bool _stop)
    {
        if (_stop)
        {
            _characterstate = CharacterState.none;
           _rigidbody2D.velocity = Vector2.zero;
            _animator.SetBool("move", false);

        }
    }


   

    void Update()
    {
        if (_characterstate == CharacterState.move && InGameManeger.gameState == GameState.playingInGame)
        {
            //transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + move_dir, Time.deltaTime * Character_speed);
            _rigidbody2D.velocity = move_dir * Character_speed;
            audiosource.mute = false;
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
            audiosource.mute = true;
            _rigidbody2D.velocity = move_dir * 0;
        }
    }
}
