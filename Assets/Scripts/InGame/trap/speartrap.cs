using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speartrap : MonoBehaviour
{
    public Animator animator;
    public float operator_cycle = 2.5f;
    public float start_time = 0f;
    public GameObject spear_gb;
    public GameObject spear_col;

    bool operation = false;
    bool _spear = false;
    public float _time = 0;

    void Update()
    {
        if (InGameManeger.ingamestate != InGameState.problemclear || InGameManeger.ingamestate != InGameState.victory)
        {
            if (!operation)
            {
                _time += Time.smoothDeltaTime;
                if (start_time < _time)
                {
                    _time = 0;
                    operation = true;
                }
            }
            else
            {
                _time += Time.smoothDeltaTime;
                if (_time > operator_cycle)
                {
                    _time = 0;
                    if (_spear)
                        _spear = false;
                    else
                    {
                        _spear = true;
                        spear_col.SetActive(true);
                        spear_gb.SetActive(true);
                    }
                    animator.SetBool("setspear", _spear);

                }
            }
        }
    }
    public void unactive()
    {
        gameObject.SetActive(false);
    }
}
