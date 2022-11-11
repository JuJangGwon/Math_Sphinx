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
        if (other.gameObject.tag == "key2")
        {
            InGameManeger.ingamestate = InGameState.findkey;
            stage1_cs.is_key2 = true;
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
            SceneManager.LoadScene("CarpetGame");
                
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
            SceneManager.LoadScene("CamelGame");
        }
        if (other.gameObject.tag == "Monster")
        {
            InGameManeger.gameState = GameState.death;
            InGameManeger.deathreason = DeathReason.mummy;
            InGameManeger.ingamestate = InGameState.playerdeath;
        }
        if (other.gameObject.tag == "spear")
        {
            InGameManeger.deathreason = DeathReason.trap;
            InGameManeger.gameState = GameState.death;
            InGameManeger.ingamestate = InGameState.playerdeath;
        }
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


