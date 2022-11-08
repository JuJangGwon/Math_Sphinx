using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public GameObject darkgb;
    public Image darkimg;
    public HandLightSystem handlightsystem_cs;
    public FindAnswerWay findAnswerWay_cs;
    public GameObject Problem_popup;
    public stage1 stage1_cs;
    public MapCreater mapcreate_cs;
    public NowPushedFootBoard nowPushedFootboard = NowPushedFootBoard.none;
    public Loadpirordata loadpirordata_cs;
    
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
        if (other.gameObject.tag == "key")
        {
            InGameManeger.ingamestate = InGameState.findkey;
            findAnswerWay_cs.ShowProblempopup(false);
            stage1_cs.is_key1 = true;
            Destroy(stage1_cs.stargame_gb);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Minigame1")
        {
            InGameManeger.ingamestate = InGameState.minigame1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Minigame1potal")
        {
            loadpirordata_cs.setPirorData(3);
            InGameManeger.ingamestate = InGameState.createMap;
            SceneManager.LoadScene(1);
                
        }
        if (other.gameObject.tag == "Minigame2")
        {
            InGameManeger.ingamestate = InGameState.minigame2;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Minigame2potal")
        {
            loadpirordata_cs.setPirorData(2);
            InGameManeger.ingamestate = InGameState.createMap;
            SceneManager.LoadScene(3);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ABC")
        {
            Problem_popup.SetActive(true);
        }


        //    정답 발판 충돌 처리

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
          //  InGameManeger.ingamestate = InGameState.batteryex3;
        }
        if (other.gameObject.tag == "return")
        {
            handlightsystem_cs.handlight_now_left_time = 8;
            handlightsystem_cs.handlight_now_left_time = 1;
            StartCoroutine(DarkfadeIn());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
      /*  if (other.gameObject.tag == "AnswerFootBoard1" || other.gameObject.tag == "AnswerFootBoard2" ||
            other.gameObject.tag == "AnswerFootBoard3" || other.gameObject.tag == "AnswerFootBoard4")
        {
            nowPushedFootboard = NowPushedFootBoard.none;
            _boxcollider2d.isTrigger = false;
                Debug.Log("발판 땜");
        }
      */
    }
    public IEnumerator DarkfadeIn()
    {
        yield return new WaitForSeconds(2f);
        darkgb.SetActive(true);
        for (int i = 0; i < 33; i++)
        {
            darkimg.color = new Vector4(0, 0, 0, 0 + i * 0.03f);
            yield return new WaitForSeconds(0.03f);
        }
        //InGameManeger.ingamestate = InGameState.batteryex4;
    }
}


