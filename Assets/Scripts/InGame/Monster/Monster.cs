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
    upleft,
    upright,
    downleft,
    downright
}
public class Monster : MonoBehaviour
{
    public Animator animator;


    MonsterState monsterstate = MonsterState.move;
    MonsterDirection monsterdirction = MonsterDirection.upleft;
    float monster_speed = 1f;
    Vector3 monster_dir;
    int my = 0;
    int mx = 0;


    private void Start()
    {
        monsterstate = MonsterState.move;
        //monsterdirction = _monsterDirection;
        MonsterSetRotation();
    }

    void MonsterSetRotation()
    {
        if (monsterdirction == MonsterDirection.upleft && monsterdirction == MonsterDirection.downleft)
            transform.rotation = Quaternion.Euler(0, -180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    Vector2 FindMyposition()
    {

        int dx, dy;


        int x = (int)transform.position.x + 0;
        int y = (int)transform.position.y + 0;

        dx = x / 4;
        dy = y / 3;
        int my = 0 + dx + dy;
        int mx = 0 - dx + dy;
        return new Vector2(mx, my);

    }
    void Movetranslate()
    {
        switch (monsterdirction)
        {
            case MonsterDirection.downleft:
                monster_dir = new Vector3(-1, -1, 0);
                break;
            case MonsterDirection.downright:
                monster_dir = new Vector3(1, -1, 0);
                break;
            case MonsterDirection.upright:
                monster_dir = new Vector3(1, 1, 0);
                break;
            case MonsterDirection.upleft:
                monster_dir = new Vector3(-1, 1, 0);
                break;
        }

        transform.Translate(monster_dir * monster_speed * Time.deltaTime);
    }

    void WallCollider()
    {
        Vector2 v = FindMyposition();
        my = (int)v.y;
        mx = (int)v.x;
        Debug.Log(v);
        switch (monsterdirction)
        {
            case MonsterDirection.downleft:
                if (MapCreater.map[my, mx-1] == 2)
                {
                    monsterdirction = MonsterDirection.upright;

                }
                break;
            case MonsterDirection.downright:
                if (MapCreater.map[my-1, mx] == 2)
                {
                    monsterdirction = MonsterDirection.upleft;

                }
                break;
            case MonsterDirection.upright:
                if (MapCreater.map[my-1, mx] == 2)
                {
                    monsterdirction = MonsterDirection.downleft;

                }
                break;
            case MonsterDirection.upleft:
                if (MapCreater.map[my, mx + 1] == 2)
                {
                    monsterdirction = MonsterDirection.downright;
                }
                break;
            
        }
    }
        void Update()
        {

            if (monsterstate == MonsterState.move)
            {
                animator.SetBool("move", true);
                MonsterSetRotation();
                Movetranslate();
                WallCollider();
        }
        else
            {
                animator.SetBool("move", false);

            }
        }
    }
