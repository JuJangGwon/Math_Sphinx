using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RugQuestion : MonoBehaviour
{
    [Header("WJAPI")]
    public WJAPI scWJAPI;

    [Header("문제 상자")]
    public TEXDraw tdr;
    public GameObject rug_prefab;
    public Rug[] btAnsr = new Rug[2];
    public TEXDraw[] texSelection;
    //public TextMeshProUGUI[] texSelection;

    [Header("플레이어 라이프")]
    public int current_life = 3;
    public Image[] life_images = new Image[3];
    public Sprite[] life_imagess = new Sprite[2];         //추후에 이미지로 변경 예정

    [Header("플레이어")]
    public RugPlayer player;

    [System.Serializable]
    public struct Question_Info
    {
        [Header("출제 수")] public int question_count;
        [Header("현재 문제 수")] public int current_question_count;
        [Header("목표 정답 수")] public int target_correct_value;
        [Header("현재 정답 수")] public int current_correct_value;
    }

    [Header("게임 세팅")]
    public Vector3 spawn_position;
    public Question_Info question_info;
    public Animator fade_io;
    int fade_in_hashcode = Animator.StringToHash("In");
    int fade_out_hashcode = Animator.StringToHash("Out");
    public Animation infomation_anime;
    bool can_solve = false;

    void Awake()
    {
        fade_io.SetTrigger(fade_in_hashcode);
        StartCoroutine(CreateProblem());
        if (question_info.question_count == 0) // 나중에 진단평가 여부에 따라 진단평ㅇ가 안했음 8문제만 제출하게 수정
            question_info.question_count = 8;
    }

    IEnumerator CreateProblem()
    {
        yield return new WaitForSeconds(1f);

        question_info.current_question_count++;

        scWJAPI.MakeQuestion();
        StartCoroutine(Selection_Text_Setting());
    }

    IEnumerator Selection_Text_Setting()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < texSelection.Length; i++)
            texSelection[i].text = scWJAPI.Answer_Selection[i];

        tdr.text = /*"\\scdd" +*/ "\\centering" + scWJAPI.Problem_Explain;

        can_solve = true;
    }

    public void Click_Answer(int _nIndex)
    {
        if (can_solve)
        {
            ProblemHistoryData.instance.Save_Problem(DateTime.Now.ToString("yyyy년 MM월 dd일"), tdr, texSelection, texSelection[_nIndex]);

            if (Check_Answer(_nIndex))
                Move_Camel();
            else
                Panelty();

            if (question_info.current_question_count < question_info.question_count)
            {
                scWJAPI.OnClick_Ansr(_nIndex);
                Spawn_Rug();
                StartCoroutine(Selection_Text_Setting());
            }
            else
            {
                Result();
            }
            question_info.current_question_count++;
            can_solve = false;
        }
    }

    bool Check_Answer(int button_num)
    {
        if (texSelection[button_num].text == scWJAPI.Problem_Answer)
        {
            ProblemHistoryData.instance.Check_Correct();
            return true;
        }
        else
            return false;
    }

    void Move_Camel()
    {
        print("정답입니다.       양탄자 유지");
        tdr.text = "\\scdd 정답이에요 !";

        question_info.current_correct_value++;
    }

    public void Spawn_Rug()
    {
        texSelection = new TEXDraw[btAnsr.Length];

        GameObject rugs = Instantiate(rug_prefab, player.select_rug.transform.position + spawn_position, Quaternion.identity);
        for (int i = 0; i < btAnsr.Length; i++)
        {
            btAnsr[i] = rugs.transform.GetChild(i).GetComponent<Rug>();
            //btAnsr[i].rmp = this;
            btAnsr[i].player = player;

            texSelection[i] = btAnsr[i].answer;
        }
    }

    void Panelty()
    {
        print("오답입니다.       양탄자 삭제 떨어지는 애니메이션");
        tdr.text = "\\scdd 틀렸어요...!";
        current_life--;
        life_images[current_life].sprite = life_imagess[1];

        if (current_life == 0)
        {
            Change_Main_Scene();
        }
    }

    void Result()
    {
        fade_io.SetTrigger(fade_out_hashcode);
    }

    void Change_Main_Scene()
    {
        fade_io.SetTrigger(fade_out_hashcode);
    }

    void Start_Infomation_Ani()
    {
        infomation_anime.Play();
    }
}
