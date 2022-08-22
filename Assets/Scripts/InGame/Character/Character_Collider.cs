using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NowPushedFootBoard
{
    none = 0,
    footboard_1,
    footboard_2,
    footboard_3,
    footboard_4
}

public class Character_Collider : MonoBehaviour
{
    public FindAnswerWay findAnswerWay_cs;
    public GameObject Problem_popup;
    public NowPushedFootBoard nowPushedFootboard = NowPushedFootBoard.none;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ABC")
        {
            Problem_popup.SetActive(true);
        }


        //    정답 발판 충돌 처리


        if (other.gameObject.tag == "AnswerFootBoard1")
        {
            nowPushedFootboard = NowPushedFootBoard.footboard_1;
            Debug.Log("1번 정답 발판 밟음");
        }
        else if (other.gameObject.tag == "AnswerFootBoard2")
        {
            nowPushedFootboard = NowPushedFootBoard.footboard_2;
            Debug.Log("2번 정답 발판 밟음");
        }
        else if (other.gameObject.tag == "AnswerFootBoard3")
        {
            nowPushedFootboard = NowPushedFootBoard.footboard_3;
            Debug.Log("3번 정답 발판 밟음");
        }
        else if (other.gameObject.tag == "AnswerFootBoard4")
        {
            nowPushedFootboard = NowPushedFootBoard.footboard_4;
            Debug.Log("4번 정답 발판 밟음");
        }
        if (other.gameObject.tag == "AnswerFootBoard1" || other.gameObject.tag == "AnswerFootBoard2" ||
             other.gameObject.tag == "AnswerFootBoard3" || other.gameObject.tag == "AnswerFootBoard4")
        {
            findAnswerWay_cs.PlayerStart((int)nowPushedFootboard);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "AnswerFootBoard1" || other.gameObject.tag == "AnswerFootBoard2" ||
            other.gameObject.tag == "AnswerFootBoard3" || other.gameObject.tag == "AnswerFootBoard4")
        {
            nowPushedFootboard = NowPushedFootBoard.none;
            Debug.Log("발판 땜");
        }
    }
}

