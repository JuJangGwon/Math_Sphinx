using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage1 : MonoBehaviour
{
    bool trigger = false;

    public GameObject map_parent;
    public GameObject key_prefebs;
    public GameObject signboard_prefebs;
    public TEXDraw3D[] first_game_text;
    public GameObject first_textbox;
    public FindAnswerWay findAnswerWay_cs;
    public InGameManeger inGameManeger_cs;

    // -65, 66 (180  | -59, 52,(-30 | -56.9, 61 (180
    // -95.26 74 .88  2.1   | -62 86 2.1   |   -59.3, 74.2 , 2.1               | -38.8  , 33.6 2 


    public void stage1_createproblem()
    {
        findAnswerWay_cs.CreateProblem();
        trigger = true;
    }

    public void first_game_setttings()
    {
        key_prefebs = Instantiate(key_prefebs);
        for (int i = 0; i < 4; i++)
        {
             first_game_text[i].text = findAnswerWay_cs.getselection_text(i);
        }

        switch (WJAPI.Answer_num)
        {
            case 0:
                key_prefebs.transform.localPosition = new Vector3(-95.26f, 74.88f, 2.1f);
                break;
            case 1:
                key_prefebs.transform.localPosition = new Vector3(-62f, 86f, 2.1f);
                break;
            case 2:
                key_prefebs.transform.localPosition = new Vector3(-59.3f, 74.2f, 2.1f);
                break;
            case 3:
                key_prefebs.transform.localPosition = new Vector3(-47f, 37.6f, 2.1f);
                break;
        }
    }
    void Update()
    {
        if (trigger == true)
        {
            if (findAnswerWay_cs.makeProblemProgress == MakeProblemProgress.finish)
            {
                first_game_setttings();
                trigger = false;
                findAnswerWay_cs.makeProblemProgress = MakeProblemProgress.none;
            }
        }
    }
}
