using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProblemHistory : MonoBehaviour
{
    public ProblemInformation output_plroblem;

    [Header("UI")]
    public Canvas can;
    public TextMeshProUGUI date;
    public TEXDraw problem;
    public TEXDraw[] answer;
    public TEXDraw select_answer;
    public Image correct_stamp;

    public Animator anime;
    int open = Animator.StringToHash("open");
    int close = Animator.StringToHash("close");

    int sovled_problem_index = 0;

    void OnEnable()
    {
        sovled_problem_index = 0;
        Setting_Problem_History(sovled_problem_index);
    }
    
    public void Setting_Problem_History(int i)
    {
        if(ProblemHistoryData.instance.solved_problem_list.Count == 0)
        {

        }
        else
        {
            for (int c = 0; c < 4; c++)
                answer[c].enabled = false;

            output_plroblem = ProblemHistoryData.instance.solved_problem_list[i];

            date.text = (sovled_problem_index + 1).ToString("D2") + output_plroblem.date_text;
            problem.text = output_plroblem.problem_text;
            for (int c = 0; c < output_plroblem.answer_text.Length; c++)
            {
                answer[c].enabled = true;
                answer[c].text = output_plroblem.answer_text[c];
            }
            select_answer.text = output_plroblem.select_answer_text;

            if (output_plroblem.is_correct) { correct_stamp.enabled = true; }
            else { correct_stamp.enabled = false; }
        }
    }

    public void Next_Histroy()
    {
        if (sovled_problem_index != ProblemHistoryData.instance.solved_problem_list.Count - 1)
            sovled_problem_index++;
        Setting_Problem_History(sovled_problem_index);
    }

    public void Previous_Histroy()
    {
        if(sovled_problem_index != 0)
            sovled_problem_index--;
        Setting_Problem_History(sovled_problem_index);
    }

    public void Open_PBH() {gameObject.SetActive(true); anime.SetTrigger(open); }
    public void Close_PBH() { anime.SetTrigger(close); }
    public void Set_Active_False() { gameObject.SetActive(false); }
}