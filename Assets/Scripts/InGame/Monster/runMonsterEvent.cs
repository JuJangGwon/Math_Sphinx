using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runMonsterEvent : MonoBehaviour
{
    public RunMonster runmonster_cs;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Character")
        {
            Debug.Log("밟ㅇ므 ");
            runmonster_cs.monsterstate = MonsterState.move;
            Destroy(gameObject);
        }

    }
}