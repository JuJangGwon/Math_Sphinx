using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MonsterState
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

    bool collider_b = false;
    float coollider_time = 0;
    Vector3 v;
    float _time = 0;
    Rigidbody2D rid2d;
    MonsterState monsterstate = MonsterState.move;
    public MonsterDirection monsterdirction = MonsterDirection.upleft;
    float monster_speed = 1f;
    Vector3 monster_dir;
    Vector2[] move_forward = new Vector2[4];
    int my = 0;
    int mx = 0;


    private void Start()
    {
        rid2d = GetComponent<Rigidbody2D>();
        move_forward[0] = new Vector2(-7, 4);
        move_forward[1] = new Vector2(7, 6);
        move_forward[2] = new Vector2(-7, -6);
        move_forward[3] = new Vector2(7, -4);

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
                monster_dir = new Vector2(-7, -4);
                break;
            case MonsterDirection.downright:
                monster_dir = new Vector2(4, -7);
                break;
            case MonsterDirection.upright:
                monster_dir = new Vector2(7, 4);
                break;
            case MonsterDirection.upleft:
                monster_dir = new Vector2(-4, 7);
                break;
        }
        rid2d.velocity = monster_dir * monster_speed;
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + monster_dir, monster_speed * Time.deltaTime);
    }

void Layc()
    {
        float max_dis = 0;
        int next_dir = Random.RandomRange(0,3);
        int layerMask = LayerMask.GetMask("Water");
          
        for (int i = 0; i < 4; i++)
        {
            if (i == (int)monsterdirction)
                continue;
            Debug.DrawRay(transform.position + new Vector3(0, -2.5f), (move_forward[i])* 15, Color.red, 1f);
            RaycastHit2D hitinf = Physics2D.Raycast(this.transform.position + new Vector3(0,-2.5f), move_forward[i]* 15, 1f, layerMask);
            if (hitinf.collider != null)
            {
                float now_dis = Mathf.Abs(Vector2.Distance(gameObject.transform.position, hitinf.collider.transform.position));
      //          Debug.Log(hitinf.collider.transform);
                  if (max_dis < now_dis)
                    {
                        next_dir = i;
                        max_dis = now_dis;
                    }
            }

        }
//        Debug.Log(max_dis);
//        Debug.Log(next_dir);

        MonsterSetRotation((MonsterDirection)next_dir);
    }
    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >1f)
        {
            _time = 0;
            if (v.x == (int)transform.position.x && v.y == (int)transform.position.y)
            {
                Layc();
            }
            v = new Vector3((int)transform.position.x, (int)transform.position.y, 0);
        }
        if (collider_b == true)
        {
            coollider_time += Time.deltaTime;
            if (coollider_time > 0.7f)
            {
                collider_b = false;
                coollider_time = 0;
            }
        }
    }
    void FixedUpdate()
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
        if (collider_b == false)
        {
            if (other.gameObject.tag == "Wall")
            {
                Layc();
                collider_b = true;
            }
        }
    }
}
