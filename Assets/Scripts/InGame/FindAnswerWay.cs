using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindAnswerWay : MonoBehaviour
{
    public WJAPI wjapi_cs;
    public GameObject Problem_popup;
    public Text Problem_text;
    public TextMesh[] selection_text;
    public GameObject go;
    public int Answer = 0;

    private void Awake()
    {
        clear_text();
        Problem_popup.transform.localPosition = new Vector3(0, 1400, 0);
    }
  
    float time = 0;
    bool a = true;
    private void Update()
    {
        time += Time.deltaTime;
        if (time > 2 && a== true)
        {
            print("#");
            a = false;
            CreateProblem();
        }

    }
    void clear_text()
    {
        for (int i = 0; i < 4; i++)
        {
            selection_text[i].text = "";
        }
        Problem_text.text = "";
    }

    void CreateProblem()
    {
        wjapi_cs.MakeQuestion();
        StartCoroutine(Problem_TEXT_setting());
        StartCoroutine(ShowProblem_Popup(true));
    }
    void Selection_text_settings()
    {
        for (int i = 0; i < 4; i++)
        {
            selection_text[i].text = wjapi_cs.Answer_Selection[i];
        }
    }

    public void PlayerSelectAnswer(int selectedAnswer)
    {
        print("3");
        wjapi_cs.OnClick_Ansr(selectedAnswer-1);
        clear_text();
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
            for (int i = 0; i <= 20; i++)
            {
                Problem_popup.transform.localPosition = new Vector3(0, 800 + i * 30, 0);
                yield return new WaitForSeconds(0.02f);
            }
        }
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator Problem_TEXT_setting()
    {
        while (true)
        {
            if (wjapi_cs.Problem_Explain.Length > 2)
            {
                Problem_text.text = wjapi_cs.Problem_Explain;
                Selection_text_settings();
                wjapi_cs.Problem_Explain = "";
                break;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}