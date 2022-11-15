using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProblemHistory : MonoBehaviour
{
    public ProblemInformation output_plroblem;

    [Header("UI")]
    public Image nothing;
    public Canvas can;
    [Header("페이지")]
    public Sprite[] correct_image;
    public List<Page> page_;
    [System.Serializable]public struct Page
    {
        public GameObject page_0;
        public TextMeshProUGUI date_0;
        public TEXDraw problem_0;
        public TEXDraw[] answer_0;
        public TEXDraw select_answer_0;
        public Image correct_stamp_0;
        public TextMeshProUGUI correct_text;
    }

    public Animator anime;
    int open = Animator.StringToHash("open");
    int close = Animator.StringToHash("close");

    public int sovled_problem_index = 0;

    void OnEnable()
    {
        sovled_problem_index = 0;
        Setting_Problem_History(sovled_problem_index);
    }
    
    public void Setting_Problem_History(int i)
    {
        if(ProblemHistoryData.instance.solved_problem_list.Count == 0)
        {
            nothing.gameObject.SetActive(true);
            page_[0].page_0.SetActive(false);
            page_[1].page_0.SetActive(false);
        }
        else
        {
            nothing.gameObject.SetActive(false);
            page_[0].page_0.SetActive(true);
            Setting(i, 0);
            if (ProblemHistoryData.instance.solved_problem_list.Count > i + 1)
            {
                page_[1].page_0.SetActive(true);
                Setting(i + 1, 1);
            }
            else { page_[1].page_0.SetActive(false); }
        }
    }

    void Setting(int i, int j)
    {
        for (int c = 0; c < 4; c++)
            page_[j].answer_0[c].enabled = false;

        output_plroblem = ProblemHistoryData.instance.solved_problem_list[i];

        page_[j].date_0.text = (sovled_problem_index + 1).ToString("D2") + output_plroblem.date_text;
        page_[j].problem_0.text = output_plroblem.problem_text;
        for (int c = 0; c < output_plroblem.answer_text.Length; c++)
        {
            page_[j].answer_0[c].enabled = true;
            page_[j].answer_0[c].text = output_plroblem.answer_text[c];
        }
        page_[j].select_answer_0.text = output_plroblem.select_answer_text;

        if (output_plroblem.is_correct)
        {
            page_[j].correct_stamp_0.sprite = correct_image[0];
            page_[j].correct_text.text = "정 답 !";
        }
        else
        {
            page_[j].correct_stamp_0.sprite = correct_image[1];
            page_[j].correct_text.text = "오 답 !";
        }
    }

    public void Next_Histroy()
    {
        if (sovled_problem_index + 2 <= ProblemHistoryData.instance.solved_problem_list.Count - 1)
            sovled_problem_index += 2;
        Setting_Problem_History(sovled_problem_index);
    }

    public void Previous_Histroy()
    {
        if(sovled_problem_index - 2 >= 0)
            sovled_problem_index -= 2;
        Setting_Problem_History(sovled_problem_index);
    }

    public void Open_PBH() {gameObject.SetActive(true); anime.SetTrigger(open); }
    public void Close_PBH() { anime.SetTrigger(close); }
    public void Set_Active_False() { gameObject.SetActive(false); }
}