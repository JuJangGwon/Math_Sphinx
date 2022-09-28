using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    none,
    playingInGame,
    playingMiniGame,
    timeout,
    death
}
public enum InGameState
{
    start,
    createMap,
    darkfadeout,
    texttyping,
    proggamestart,
    proggameing,

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

    public float _time = 0;

    void Update()
    {
        _time += Time.deltaTime;

        if (ingamestate == InGameState.createMap)
        {
            mapcreater_cs.CreateMap();
            ingamestate++;
        }
        if (ingamestate == InGameState.darkfadeout)
        {
            texttypingeffect_cs.darkfadeoutf();
            ingamestate = 0;
        }
        if (ingamestate == InGameState.texttyping)
        {
            proces_text.SetActive(true);
            texttypingeffect_cs.prog_gametext(0);
            ingamestate = 0;
        }
        if (ingamestate == InGameState.proggamestart)
        {
            findanswerway_cs.SetAnswerCreateProblem(1);
            ingamestate++;
        }
    }
}
