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
    batteryex,
    batteryex2,
    batteryex3,
    batteryex4,
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
        if (ingamestate == InGameState.batteryex)
        {
            handlightsystem_cs.Max_handlight_time = 30;
            handlightsystem_cs.handlight_now_left_time = 13f;
            ingamestate++;
            _time = 0;
        }
        if (ingamestate == InGameState.batteryex2)
        {
            if (_time > 3f)
            {
                gameState = GameState.playingMiniGame;
                texttypingeffect_cs.prog_gametext2(0);
                ingamestate = 0;
            }
        }
        if (ingamestate == InGameState.batteryex3)
        {
            texttypingeffect_cs.darkfadeinf();
            ingamestate = 0;
        }
        if (ingamestate == InGameState.batteryex4)
        {
            SceneManager.LoadScene(1);
        }
    }
}