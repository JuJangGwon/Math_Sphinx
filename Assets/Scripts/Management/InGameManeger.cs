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

public class InGameManeger : MonoBehaviour
{
    public static GameState gameState = GameState.none;


    void Update()
    {
        
    }
}
