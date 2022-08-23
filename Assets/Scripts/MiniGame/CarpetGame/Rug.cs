using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Rug : MonoBehaviour
{
    public RugPlayer player;
    public bool move;
    public TextMeshProUGUI answer;
    public RugMathProblem rmp;
    public int answer_num;

    void Start()
    {
       
    }

    void Update()
    {
        if (move)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, Time.deltaTime * 7f);
            if(player.transform.position == transform.position)
            {
                player.anime.SetTrigger(player.ani_idle);
                move = false;
                player.is_moving = false;
            }
        }
    }
    void OnMouseDown()
    {
        if(!player.is_moving)
        {
            player.select_rug = this;
            player.is_moving = true;
            move = true;
            player.anime.SetTrigger(player.ani_jump);
        }
    }
}
