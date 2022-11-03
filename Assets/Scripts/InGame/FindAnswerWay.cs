using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MakeProblemProgress
{
none,
making,
finish
}

public class FindAnswerWay : MonoBehaviour
{
    public MakeProblemProgress makeProblemProgress = MakeProblemProgress.none;
    public TEXDraw txdraw;
    public WJAPI wjapi_cs;
    public GameObject Problem_popup;
    public string[] selection_text;
    public GameObject[] answerboard;
    public GameObject go;
    public int Answer = 0;

    private void Awake()
    {
        Problem_popup.transform.localPosition = new Vector3(0, 1400, 0);
        //CreateProblem();
    }
  
    float time = 0;
    bool a = true;
 
    void clear_text()
    {
        for (int i = 0; i < 4; i++)
        {
            selection_text[i] = "";
        }
        txdraw.text = "";
    }
    public void ShowProblempopup(bool onoff)
    {
        if (onoff)
        {
            StartCoroutine(ShowProblem_Popup(true));
        }
        else
        {
            StartCoroutine(ShowProblem_Popup(false));
        }
    }


    public void CreateProblem()
    {
        makeProblemProgress = MakeProblemProgress.making;
        wjapi_cs.MakeQuestion();
        StartCoroutine(Problem_TEXT_setting(false, 0));
    }
    public void SetAnswerCreateProblem(int a)
    {
        wjapi_cs.MakeQuestion();
        StartCoroutine(Problem_TEXT_setting(true, a));
        StartCoroutine(ShowProblem_Popup(true));
    }

    public void progress()
    {
        StartCoroutine(Problem_TEXT_setting(false,0));
        StartCoroutine(ShowProblem_Popup(true));
    }
    void Selection_text_settings()
    {
        for (int i = 0; i < 4; i++)
        {
            selection_text[i] = wjapi_cs.Answer_Selection[i];
        }
        makeProblemProgress = MakeProblemProgress.finish;
    }
    public string getselection_text(int i)
    {
        return selection_text[i];
    }


    public void PlayerSelectAnswer(int selectedAnswer)
    {
       
        wjapi_cs.OnClick_Ansr(selectedAnswer-1);
        StartCoroutine(ShowProblem_Popup(false));
    }
    
    IEnumerator ShowProblem_Popup(bool _on)
    {
        
        if (_on == true)
        {
            for (int i = 0; i <= 20; i++)
            {
                Problem_popup.transform.localPosition = new Vector3(0, 1400 - i * 30, 0);
                yield return new WaitForSeconds(0.02f);
            }
        }
        else
        {
            yield return new WaitForSeconds(1.0f);
            for (int i = 0; i <= 20; i++)
            {
                Problem_popup.transform.localPosition = new Vector3(0, 800 + i * 30, 0);
                yield return new WaitForSeconds(0.025f);
            }
            clear_text();
        }
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator Problem_TEXT_setting(bool set_answer,int a)
    {
        while (true)
        {
            if (wjapi_cs.Problem_Explain.Length > 2)
            {
                if (set_answer == true)
                {
                    wjapi_cs.setAnswer(a, 4);
                }
                txdraw.text = wjapi_cs.Problem_Explain;
                Selection_text_settings();
                break;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void delete_answerboard()
    {
        for (int i = 0; i < 4; i++)
        {
            answerboard[i].transform.tag = "none";
        }
    }
}