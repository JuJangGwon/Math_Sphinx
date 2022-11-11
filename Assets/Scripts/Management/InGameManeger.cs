using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    none,
    playingInGame,
    playingMiniGame,
    timeout,
    texting,
    death,
}
public enum DeathReason
{
    none,
    trap,
    timemout,
    mummy,

}
public enum InGameState
{
    start,
    createMap,
    darkfadeout,
    texttyping,
    findkey,
    texttyping2,
    _4selectgame,
    playgame,
    minigame1,
    minigame1init,
    minigame2,
    minigame2init,
    treasurefind,
    finalarea,
    finalareaing,
    problemclear,
    victory,
    playerdeath,
    playerdetah2,
}

public class InGameManeger : MonoBehaviour
{
    public static GameState gameState = GameState.none;
    public static InGameState ingamestate = InGameState.createMap;
    public static DeathReason deathreason = DeathReason.none;

    public GameObject proces_text;

    public Loadpirordata Loadpirordata_cs;
    public MapCreater mapcreater_cs;
    public FindAnswerWay findanswerway_cs;
    public HandLightSystem handlightsystem_cs;
    public texttypingeffect texttypingeffect_cs;
    public Character_Animator character_animator_cs;
    public Character_move character_move_cs;

    public stage1 stage1_cs;
    public float _time = 0;

    private void Start()
    {
        gameState = GameState.none; 
        ingamestate = InGameState.createMap;
        deathreason = DeathReason.none;
    }
    void Update()
    {
        if (ingamestate == InGameState.createMap)
        {
            character_animator_cs.Start();
            mapcreater_cs.CreateMap();
            Loadpirordata_cs.getPirorData();
            handlightsystem_cs.startFadein(false);
            gameState = GameState.playingInGame;
            stage1_cs.stage1_createproblem();

            ingamestate++;
        }
        if (ingamestate == InGameState.darkfadeout)
        {
            // default
        }
        if(ingamestate == InGameState.texttyping)
        {
            if (Loadpirordata_cs.getNewgame() == 1)
            {
                texttypingeffect_cs.start1stage(0);
                ingamestate = InGameState._4selectgame;
            }
            else
            {
                ingamestate = InGameState.playgame;
            }
        }
        if (ingamestate == InGameState.findkey)
        {
            texttypingeffect_cs.findkey(0);
            ingamestate = InGameState.texttyping2;
        }
        if (ingamestate == InGameState.minigame1)
        {
            texttypingeffect_cs.minigame1(0);
            ingamestate++;
        }
        if (ingamestate == InGameState.minigame2)
        {
            texttypingeffect_cs.minigame2(0);
            ingamestate++;
        }
        if (ingamestate == InGameState.treasurefind)
        {
            if (stage1_cs.is_key1 == true || stage1_cs.is_key2 == true)
            {
                texttypingeffect_cs.findtreasure(0);
                ingamestate = InGameState.texttyping2;
            }
            else
            {
                texttypingeffect_cs.findtreasure_notfoundkey(0);
                ingamestate = InGameState.texttyping2;
            }
        }
        if (ingamestate == InGameState.finalarea)
        {
            stage1_cs.final_game_settgings();
            findanswerway_cs.ShowProblempopup(true);
            ingamestate++;
        }
        if (ingamestate == InGameState.playerdeath)
        {
            Character_move._characterstate = CharacterState.die;
            character_move_cs.ShowDeathReason(deathreason);
            ingamestate++;
        }
    }
}