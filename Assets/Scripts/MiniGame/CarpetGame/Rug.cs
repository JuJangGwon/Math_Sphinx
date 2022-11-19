using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Rug : MonoBehaviour
{
    public RugPlayer player;
    public bool move;
    public TEXDraw answer;
    public RugQuestion rq;
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
                player.is_moving = false;
                player.rmp.player_audio.PlayOneShot(player.rmp.player_audio.clip);
                player.anime.SetTrigger(player.ani_idle);
                move = false;
            }
        }
    }
    void OnMouseDown()
    {
        if(!player.is_moving)
        {
            player.anime.SetTrigger(player.ani_jump);

            player.select_rug = this;
            //move = true;
        }
    }
}
