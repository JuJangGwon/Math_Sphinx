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
    Animator _animator;
    Rigidbody2D _rigidbody2D;
    float Character_speed = 10f;
    public GameObject death_reason_gb;
    public Text deathreason_text;


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
  
    public void CharacterStop(bool _stop)
    {
        if (_stop)
        {
            _characterstate = CharacterState.none;
           _rigidbody2D.velocity = Vector2.zero;
            _animator.SetBool("move", false);

        }
    }


    public void ShowDeathReason(DeathReason reason)
    {
        death_reason_gb.SetActive(true);
        switch (reason)
        {
            case DeathReason.trap:
                deathreason_text.text = "함정에 의해 죽었습니다.";
                break;
            case DeathReason.mummy:
                deathreason_text.text = "미라에게 습격당했습니다.";
                break;
            case DeathReason.timemout:
                deathreason_text.text = "손전등 배터리가 다 떨어졌습니다.";
                break;
        }
    }

    void Update()
    {
        if (_characterstate == CharacterState.move && InGameManeger.gameState == GameState.playingInGame)
        {
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
