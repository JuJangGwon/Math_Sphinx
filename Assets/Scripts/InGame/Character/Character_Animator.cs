using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Animator : MonoBehaviour
{
    public Animator _charactor_animator;

    void Awake()
    {
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
        }
        if (Character_move._characterstate == CharacterState.die)
        {
            _charactor_animator.SetBool("_isDie", true);
        }
    }
}