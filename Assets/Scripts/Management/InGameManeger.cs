using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Stage
{
    none,
    tutorial,
    stage1,
    stage2,
    stage3,

}

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
    public GameObject character;

    public static GameState gameState = GameState.none;
    public static InGameState ingamestate = InGameState.createMap;
    public static DeathReason deathreason = DeathReason.none;
    public static Stage seletedStage = Stage.tutorial;

    public GameObject proces_text;
    public GameObject end_gb;

    public Loadpirordata Loadpirordata_cs;
    public MapCreater mapcreater_cs;
    public FindAnswerWay findanswerway_cs;
    public HandLightSystem handlightsystem_cs;
    public texttypingeffect texttypingeffect_cs;
    public Character_Animator character_animator_cs;
    public Character_move character_move_cs;
    public JoystickScripts JoystickScripts_cs;
    public FinishGameManager finishgamemanager_cs;

    public CameraMove camera_move_cs;
    public stage1 stage1_cs;
    public tutorial tutoral_cs;
    public float _time = 0;

    private void Start()
    {
        seletedStage = Stage.stage1;
        gameState = GameState.none;
        ingamestate = InGameState.createMap;
        deathreason = DeathReason.none;
    }
  
    void Update()
    {
        switch(seletedStage)
        {
            case Stage.tutorial:
                tutorial();
                break;
            case Stage.stage1:
                stage1();
                break;
        }
    }


    void tutorial()
    {
        if (ingamestate == InGameState.createMap)
        {
            mapcreater_cs.CreateMap();
            tutoral_cs.TutorialSettings();
            handlightsystem_cs.startFadein(false);
            ingamestate= InGameState.texttyping2;
        }
        if (ingamestate == InGameState.texttyping)
        {
            ingamestate = InGameState.texttyping2;
            tutoral_cs.now_tutorial_stage++;
            Debug.Log(tutoral_cs.now_tutorial_stage);
            if (tutoral_cs.now_tutorial_stage == Tutorial_stage.tutorial1)
            {
                texttypingeffect_cs.tutorial1(0);
            }
            else if (tutoral_cs.now_tutorial_stage == Tutorial_stage.tutorial2)
            {
                texttypingeffect_cs.tutorial2(0);
            }
        }
    }

    void stage1()
    {
        if (ingamestate == InGameState.createMap)
        {
            mapcreater_cs.CreateMap();
            stage1_cs.createCharacter();
            Loadpirordata_cs.getPirorData();
            handlightsystem_cs.startFadein(false);
            gameState = GameState.playingInGame;
            character_animator_cs.Start();
            stage1_cs.stage1_createproblem();

            ingamestate++;
        }
        if (ingamestate == InGameState.darkfadeout)
        {
            // default
        }
        if (ingamestate == InGameState.texttyping)
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
            stage1_cs.SetKey_UI();
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
            finishgamemanager_cs.ShowDeathReason(deathreason);
            end_gb.SetActive(true);
            ingamestate++;

        }

    }
}