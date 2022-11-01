using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RunMonster : MonoBehaviour
{
    public Animator animator;
    public GameObject parents;

    float _time = 0;
    Rigidbody2D rid2d;
    public MonsterState monsterstate = MonsterState.none;
    public MonsterDirection monsterdirction = MonsterDirection.downleft;
    float monster_speed = 11f;
    Vector3 monster_dir;
    Vector2[] move_forward = new Vector2[4];

    private void Start()
    {
        rid2d = GetComponent<Rigidbody2D>();
        move_forward[0] = new Vector2(-7, 4);
        move_forward[1] = new Vector2(7, 6);
        move_forward[2] = new Vector2(-5, -8);
        move_forward[3] = new Vector2(7, -4);
        monsterstate = MonsterState.none; 
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
                monster_dir = new Vector2(5, -7);
                break;
            case MonsterDirection.upright:
                monster_dir = new Vector2(7, 5);
                break;
            case MonsterDirection.upleft:
                monster_dir = new Vector2(-4, 7);
                break;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + monster_dir, monster_speed * Time.deltaTime);
    }

    private void Update()
    {
        if (monsterstate == MonsterState.move)
        {
            animator.SetBool("move", false);
        }
        if (monsterstate == MonsterState.move)
        {
            animator.SetBool("move", true);
            Movetranslate();
        }
    }
 
    void OnCollisionEnter2D(Collision2D other)
    {
       
            if (other.gameObject.tag == "Wall")
            {
                 Destroy(parents, 4f);
                 monsterstate = MonsterState.none;
                rid2d.velocity = Vector2.zero;
                animator.SetBool("move", false);
            }
            if (other.gameObject.tag == "Character")
            {
                InGameManeger.gameState = GameState.death;
                rid2d.velocity = Vector2.zero;
            }
    }
}
