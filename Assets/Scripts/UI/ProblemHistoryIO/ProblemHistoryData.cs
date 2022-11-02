using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemHistoryData : MonoBehaviour
{
    static ProblemHistoryData ph;
    public static ProblemHistoryData instance
    {
        get
        {
            if (ph == null)
                ph = null;
            return ph;
        }
    }

    void Awake()
    {
        if (ph == null)
        {
            ph = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
    }

    public List<ProblemInformation> solved_problem_list = new List<ProblemInformation>();
    public int i = 0;

    public void Save_Problem(string date_text, TEXDraw problem_text, TEXDraw[] answer_text, TEXDraw select_answer_text)
    {
        ProblemInformation pi = new ProblemInformation(date_text, problem_text.text, answer_text, select_answer_text.text, false);
        for(int i = 0; i < answer_text.Length; i++)
        {
            print(answer_text[i].text+"\n");
        }
        solved_problem_list.Add(pi);
        i++;
    }

    public void Check_Correct()
    {
        solved_problem_list[solved_problem_list.Count - 1].is_correct = true;
    }

    public void test(ProblemInformation p)
    {
        for (int i = 0; i < p.answer_text.Length; i++)
        {
            print(p.answer_text[i] + "\n");
        }
    }
}

public class ProblemInformation
{
    public string date_text;
    public string problem_text;
    public string[] answer_text;
    public string select_answer_text;
    public bool is_correct;

    public ProblemInformation(string date_text, string problem_text, TEXDraw[] answer_text, string select_answer_text, bool is_correct)
    {
        this.date_text = date_text;
        this.problem_text = problem_text;
        this.answer_text = new string[answer_text.Length];
        for (int i = 0; i < answer_text.Length; i++)
            this.answer_text[i] = new string(answer_text[i].text);
        //this.answer_text = answer_text;
        this.select_answer_text = select_answer_text;
        this.is_correct = is_correct;
    }
}