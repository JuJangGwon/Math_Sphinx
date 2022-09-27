using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1 = 땅 , 2 벽, 3 배터리아이템, 4 표지판 , 5 발판 

// 맵 배열 알고리즘 x = i * 3.4f + j * -3.7f,           y = i * 3f + j * 3.1f

/*int[,] map = new int[,] { { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 , 2 }
*/

// 기본 

public class MapCreater : MonoBehaviour
{
    public FindAnswerWay findanswerway_cs;
    public GameObject[] prefebs;
    public GameObject[] answerboard;
    public GameObject MapParent;
    public GameObject answerboard_prefeb;
    int[,] map = new int[,] { { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 , 2 },
                          { 2, 1, 1, 1, 4, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 4, 5, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 4, 2, 4, 2, 2, 2, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 5, 2, 5, 2, 1, 1, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 , 2 }


};
   // 5,1 | 5,3 | 5,3 | 1, 5 
   // 4,1 | 4,3 | 3,4 | 4, 1
    public void CreateMap()
    {
        for (int i = 0; i < 22; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                int num = map[i, j];
                if (num == 5) num = 1;
                GameObject gb = Instantiate(prefebs[num]);
                gb.transform.SetParent(MapParent.transform);
                gb.transform.localPosition = new Vector3((i * 3.4f) + (j * -3.7f), (i * 3f) + (j * 3.1f),0 );
                first(gb, i, j);
            }
        }
      
    }
    void first(GameObject gb, int i, int j)
    {
        
        if (i == 1 && j == 5)
        {
            answerboard[0] = Instantiate(answerboard_prefeb);
            answerboard[0].transform.SetParent(MapParent.transform);
            answerboard[0].transform.localPosition = new Vector3((i * 3.4f) + (j * -3.7f), (i * 3f) + (j * 3.1f), 0);
            answerboard[0].transform.tag = "AnswerFootBoard1";
        }
        else if (i == 4 && j == 1)
        {
            findanswerway_cs.selection_text[0] = gb.transform.GetChild(0).GetComponent<TextMesh>();
        }
        else if (i == 4 && j == 3)
        {
            findanswerway_cs.selection_text[1] = gb.transform.GetChild(0).GetComponent<TextMesh>();
        }
        else if (i == 3 && j == 4)
        {
            findanswerway_cs.selection_text[2] = gb.transform.GetChild(0).GetComponent<TextMesh>();
        }
        else if (i == 1 && j == 4)
        {
            findanswerway_cs.selection_text[3] = gb.transform.GetChild(0).GetComponent<TextMesh>();
        }
        else if (i == 3 && j == 5)
        {
            answerboard[1] = Instantiate(answerboard_prefeb);
            answerboard[1].transform.SetParent(MapParent.transform);
            answerboard[1].transform.localPosition = new Vector3((i * 3.4f) + (j * -3.7f), (i * 3f) + (j * 3.1f), 0);
            answerboard[1].transform.tag = "AnswerFootBoard2";
        }
        else if (i == 5 && j == 3)
        {
            answerboard[2] = Instantiate(answerboard_prefeb);
            answerboard[2].transform.SetParent(MapParent.transform);
            answerboard[2].transform.localPosition = new Vector3((i * 3.4f) + (j * -3.7f), (i * 3f) + (j * 3.1f), 0);
            answerboard[2].transform.tag = "AnswerFootBoard3";
        }
        else if (i == 5 && j == 1)
        {
            answerboard[3] = Instantiate(answerboard_prefeb);
            answerboard[3].transform.SetParent(MapParent.transform);
            answerboard[3].transform.localPosition = new Vector3((i * 3.4f) + (j * -3.7f), (i * 3f) + (j * 3.1f), 0);
            answerboard[3].transform.tag = "AnswerFootBoard4";
        }
    }
}
