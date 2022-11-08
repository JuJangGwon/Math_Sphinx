using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Character_trigger : MonoBehaviour
{
    public stage1 _stage1cs;
    bool findtreasuretrigger_onoff = false;

    float _time = 0;

    void selectedFootboard(int i)
    {
        if (InGameManeger.ingamestate == InGameState._4selectgame)
        {
            _stage1cs.selected_answer(i);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "treasurefind" && InGameManeger.ingamestate == InGameState.finalarea)
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "treasurefind" && findtreasuretrigger_onoff == false)
        {
             InGameManeger.ingamestate = InGameState.treasurefind;
            findtreasuretrigger_onoff = true;
        }
        
        if (other.gameObject.tag == "endpoint")
        {
            InGameManeger.ingamestate = InGameState.victory;
        }
        if (other.gameObject.tag == "AnswerFootBoard1")
        {
            Debug.Log("1번 정답 발판 밟음");
            selectedFootboard(1);
        }
        else if (other.gameObject.tag == "AnswerFootBoard2")
        {
            selectedFootboard(2);
            Debug.Log("2번 정답 발판 밟음");
        }
        else if (other.gameObject.tag == "AnswerFootBoard3")
        {
            selectedFootboard(3);
            Debug.Log("3번 정답 발판 밟음");
        }
        else if (other.gameObject.tag == "AnswerFootBoard4")
        {
            selectedFootboard(4);
            Debug.Log("4번 정답 발판 밟음");
        }


        if (other.gameObject.tag == "AnswerFootBoard1" || other.gameObject.tag == "AnswerFootBoard2" ||
             other.gameObject.tag == "AnswerFootBoard3" || other.gameObject.tag == "AnswerFootBoard4")
        {
          //  findAnswerWay_cs.PlayerSelectAnswer((int)nowPushedFootboard);
          //  if (mapcreate_cs.stage == 3)
            {
                //       InGameManeger.ingamestate = InGameState.batteryex;
           //     findAnswerWay_cs.delete_answerboard();
            }
        }
    }
    private void Update()
    {
        if (findtreasuretrigger_onoff == true)
        {
            _time += Time.deltaTime;
            if (_time > 9f)
            {
                findtreasuretrigger_onoff = false;
                _time = 0;
            }
        }

    }
}