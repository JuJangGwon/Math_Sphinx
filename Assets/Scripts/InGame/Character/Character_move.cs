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
    Animator _animator;
    float Character_speed = 5f;

    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
       if (_characterstate == CharacterState.none)
        {
            _animator.SetBool("_isMove", false);
        }

        if (_characterstate == CharacterState.move)
       {
            _animator.SetBool("_isMove", true);

            transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + move_dir,Time.deltaTime * Character_speed);
            if (move_dir.x >= 0)
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            else
                transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
