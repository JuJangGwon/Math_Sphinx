using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAnswerWay : MonoBehaviour
{
    public GameObject go;
    public int Answer = 0;

    private void Awake()
    {
        CreateProblem();
    }
    public void PlayerStart(int num)
    {
        if (num == Answer)                  // 플레이어가 밟은 발판이 정답일
        {

        }
        else if (num != Answer)             // 
        {

        }
    }

    void CreateProblem()
    {
        Answer = 1;
    }
    
}
