using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_trigger : MonoBehaviour
{
    bool findtreasuretrigger_onoff = false;

    float _time = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "treasurefind" && findtreasuretrigger_onoff == false)
        {
             InGameManeger.ingamestate = InGameState.treasurefind;
            findtreasuretrigger_onoff = true;
        }
        if (other.gameObject.tag == "endpoint")
        {
            InGameManeger.ingamestate = InGameState.victory;
        }
    }
    private void Update()
    {
        if (findtreasuretrigger_onoff == true)
        {
            _time += Time.deltaTime;
            if (_time > 9f)
            {
                findtreasuretrigger_onoff = false;
                _time = 0;
            }
        }

    }
}