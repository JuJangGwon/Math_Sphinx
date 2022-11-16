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
        if (other.gameObject.tag == "potal")
        {
            InGameManeger.ingamestate = InGameState.texttyping;
            Destroy(other.gameObject);
        }
    }


}


