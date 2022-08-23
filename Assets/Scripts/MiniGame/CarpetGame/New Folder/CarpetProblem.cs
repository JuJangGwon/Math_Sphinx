using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetProblem : MonoBehaviour
{
    //public bool spawned_rug;
    public CarpetPlayer cp;
    public GameObject math_problem;
    public Carpet[] rugs;
    int answer_rug;
    //public GameObject neighbor_rug;
    public Vector3 spawn_position;

    void Start()
    {
        rug_setting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void rug_setting()
    {
        answer_rug = Random.Range(0, rugs.Length);
        rugs[answer_rug].is_answer = true;
    }

    public void test(GameObject rug)
    {
        GameObject prob = Instantiate(math_problem, rug.transform.position + spawn_position, Quaternion.identity);
        CarpetProblem cpm = prob.GetComponent<CarpetProblem>();
        cpm.cp = cp;
    }
}
