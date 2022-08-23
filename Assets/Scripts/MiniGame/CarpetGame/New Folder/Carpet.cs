using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : MonoBehaviour
{
    //public bool spawned_rug;
    //public GameObject math_problem;
    //public GameObject neighbor_rug;
    //public Vector3 spawn_position;
    public bool is_answer;
    public int carpet_num;
    public CarpetProblem cpm;

    void Start()
    {

    }

    void Update()
    {
        
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Rigidbody2D rg = collision.transform.GetComponent<Rigidbody2D>();
    //    rg.AddForce(Vector2.up * 800);
    //    if(!spawned_rug)
    //    {
    //        Destroy(neighbor_rug);
    //        Instantiate(rugs, transform.position + spawn_position, Quaternion.identity);
    //        spawned_rug = true;
    //    }
    //}

    void OnMouseDown()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        if (is_answer) { cpm.test(transform.gameObject); Debug.Log("정답입니당"); }
        else { Debug.Log("틀렸습니당"); }
        if(carpet_num == 0) { cpm.cp.anime.SetTrigger(cpm.cp.left_move); }
        else { cpm.cp.anime.SetTrigger(cpm.cp.right_move); }
    }
}
