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

}

public class InGameManeger : MonoBehaviour
{
    public static GameState gameState = GameState.none;
    public static InGameState ingamestate = InGameState.start;

    public GameObject character_text;

    public MapCreater mapcreater_cs;
    public FindAnswerWay findanswerway_cs;
    public HandLightSystem handlightsystem_cs;
    public texttypingeffect texttypingeffect_cs;

    float _time = 0;

    void Update()
    {
        _time += Time.deltaTime;

        if (ingamestate == 0)
        {
            mapcreater_cs.CreateMap();
            ingamestate++;
        }
    }
}
