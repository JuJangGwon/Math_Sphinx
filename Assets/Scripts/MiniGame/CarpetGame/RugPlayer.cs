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
        if(select_rug != null)
        {
            int destroy_num = (select_rug.answer_num == 0) ? 1 : 0;
            Destroy(rmp.btAnsr[destroy_num].gameObject);

            rmp.OnClick_Ansr(select_rug.answer_num);

            select_rug = null;
        }
    }
}
