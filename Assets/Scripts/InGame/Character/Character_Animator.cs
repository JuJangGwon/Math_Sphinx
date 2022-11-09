using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Animator : MonoBehaviour
{
    public Animator _charactor_animator;


    public void Start()
    {
        Debug.Log("들어왓슝 ");
        _charactor_animator.SetBool("_isFront", true);
        _charactor_animator.SetBool("_isMove", false);
        //_charactor_animator.GetComponent<Animator>();
    }

    void Update()
    {
        if (Character_move._characterstate == CharacterState.none)
        {
            _charactor_animator.SetBool("_isMove", false);
        }
        if (Character_move._characterstate == CharacterState.move)
        {
            _charactor_animator.SetBool("_isMove", true);
            switch (Character_move._characterdirection)
            {
                case CharacterDirection.back_left:
                    _charactor_animator.SetBool("_isFront", false);
                    break;
                case CharacterDirection.back_right:
                    _charactor_animator.SetBool("_isFront", false);
                    break;
                case CharacterDirection.front_left:
                    _charactor_animator.SetBool("_isFront", true);
                    break;
                case CharacterDirection.front_right:
                    _charactor_animator.SetBool("_isFront", true);
                    break;
            }
        }
        if (Character_move._characterstate == CharacterState.die)
        {
            _charactor_animator.SetBool("_isDie", true);
        }
    }
}