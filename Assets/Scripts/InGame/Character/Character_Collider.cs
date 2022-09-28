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
    Rigidbody2D _rigidbody2d;
    BoxCollider2D _boxcollider2d;
    //public WJAPI WJAPI_CS;

    public HandLightSystem handlightsystem_cs;
    public FindAnswerWay findAnswerWay_cs;
    public GameObject Problem_popup;
    public MapCreater mapcreate_cs;
    public NowPushedFootBoard nowPushedFootboard = NowPushedFootBoard.none;
    
    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _boxcollider2d = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "AnswerFootBoard1" || other.gameObject.tag == "AnswerFootBoard2" ||
             other.gameObject.tag == "AnswerFootBoard3" || other.gameObject.tag == "AnswerFootBoard4")
        {
            _boxcollider2d.isTrigger = true;
        }
    }
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
            findAnswerWay_cs.PlayerSelectAnswer((int)nowPushedFootboard);
            if (mapcreate_cs.stage == 3)
            {
                InGameManeger.ingamestate = InGameState.batteryex;
                findAnswerWay_cs.delete_answerboard();
            }
        }
        if (other.gameObject.tag == "Battery")
        {
            handlightsystem_cs.Get_handlightbettery();
        }
        if (other.gameObject.tag == "prog_next_stage")
        {
            mapcreate_cs.progstage();
            findAnswerWay_cs.progress();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "potal")
        {
    
            Destroy(other.gameObject);
            InGameManeger.ingamestate = InGameState.batteryex3;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "AnswerFootBoard1" || other.gameObject.tag == "AnswerFootBoard2" ||
            other.gameObject.tag == "AnswerFootBoard3" || other.gameObject.tag == "AnswerFootBoard4")
        {
            nowPushedFootboard = NowPushedFootBoard.none;
            _boxcollider2d.isTrigger = false;
                Debug.Log("발판 땜");
        }
    }
}


