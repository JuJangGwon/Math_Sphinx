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
    public GameState gameState = GameState.none;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
