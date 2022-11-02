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
    death
}
public enum InGameState
{
    start,
    createMap,
    darkfadeout,
    texttyping,
    findkey,
    texttyping2,
    playgame,
    minigame1,
    minigame1init,
    minigame2,
    minigame2init,


}

public class InGameManeger : MonoBehaviour
{
    public static GameState gameState = GameState.none;
    public static InGameState ingamestate = InGameState.createMap;

    public GameObject proces_text;

    public MapCreater mapcreater_cs;
    public FindAnswerWay findanswerway_cs;
    public HandLightSystem handlightsystem_cs;
    public texttypingeffect texttypingeffect_cs;

    public stage1 stage1_cs;
    public float _time = 0;

    void Update()
    {
        _time += Time.deltaTime;

        if (ingamestate == InGameState.createMap)
        {
            mapcreater_cs.CreateMap();
            gameState = GameState.playingInGame;
            ingamestate++;
        }
        if (ingamestate == InGameState.darkfadeout)
        {
            stage1_cs.stage1_createproblem();
            ingamestate++;
        }
        if (ingamestate == InGameState.findkey)
        {
            texttypingeffect_cs.findkey(0);
            ingamestate++;
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
    }
}