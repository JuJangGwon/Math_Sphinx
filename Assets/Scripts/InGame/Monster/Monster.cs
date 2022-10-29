using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum MonsterState
{
    none,
    move
}

public enum MonsterDirection
{
    upleft = 0,
    upright,
    downleft ,
    downright
}


public class Monster : MonoBehaviour
{
    public Animator animator;


    MonsterState monsterstate = MonsterState.move;
    public MonsterDirection monsterdirction = MonsterDirection.upleft;
    float monster_speed = 8f;
    Vector3 monster_dir;
    Vector2[] move_forward = new Vector2[4];
    int my = 0;
    int mx = 0;


    private void Start()
    {
        move_forward[0] = new Vector2(-1, 1);
        move_forward[1] = new Vector2(3, 2);
        move_forward[2] = new Vector2(-3, -2);
        move_forward[3] = new Vector2(1, -1);

        monsterstate = MonsterState.move;
        MonsterSetRotation(MonsterDirection.upleft);
    }

    void MonsterSetRotation(MonsterDirection _monsterDirection)
    {
        monsterdirction = _monsterDirection;
        if (monsterdirction == MonsterDirection.upleft || monsterdirction == MonsterDirection.downleft)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    void Movetranslate()
    {
        switch (monsterdirction)
        {
            case MonsterDirection.downleft:
                monster_dir = new Vector2(-1, -1);
                break;
            case MonsterDirection.downright:
                monster_dir = new Vector2(1, -1);
                break;
            case MonsterDirection.upright:
                monster_dir = new Vector2(1, 1);
                break;
            case MonsterDirection.upleft:
                monster_dir = new Vector2(-1, 1);
                break;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + monster_dir, monster_speed * Time.deltaTime);
    }

    void Layc()
    {
        float max_dis = 0;
        int next_dir = 0;
        for (int i = 0; i < 4; i++)
        {
            if (i == (int)monsterdirction)
                continue;
            Debug.DrawRay(transform.position + new Vector3(2, -2), (move_forward[i])* 15, Color.red, 1f);
            RaycastHit2D hitinf = Physics2D.Raycast(this.transform.position + new Vector3(2,-2), move_forward[i]* 15);
            if (hitinf.collider.name != null)
            {
                    float now_dis = hitinf.distance;
                    if (max_dis < now_dis)
                    {
                        next_dir = i;
                        max_dis = now_dis;
                    }
            }
            Debug.Log(max_dis);

        }
        MonsterSetRotation((MonsterDirection)next_dir);
    }
        void Update()
        {

            if (monsterstate == MonsterState.move)
            {
                animator.SetBool("move", true);
                Movetranslate();
        }
        else
            {
                animator.SetBool("move", false);

            }
        }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Debug.Log("부딪");
            Layc();
        }
    }
}
