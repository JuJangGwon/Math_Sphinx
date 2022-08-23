using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugPlayer : MonoBehaviour
{
    public Animator anime;
    public bool is_moving;
    public Rug select_rug;
    public RugMathProblem rmp;

    [HideInInspector] public int ani_idle = Animator.StringToHash("IDLE");
    [HideInInspector] public int ani_jump = Animator.StringToHash("JUMP");

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Select_Answer()
    {
        Debug.Log(0);
        rmp.OnClick_Ansr(select_rug.answer_num);
    }
}
