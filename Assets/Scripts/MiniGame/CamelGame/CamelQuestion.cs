using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CamelQuestion : MonoBehaviour
{
    [Header("WJAPI")]
    public WJAPI scWJAPI;

    [Header("문제 상자")]
    public TEXDraw tdr;
    public TextMeshProUGUI[] texSelection;

    [Header("대사 상자")]
    public Image dialogue_box;

    [Header("플레이어")]
    public GameObject camel_object;
    public GameObject camera_camel;

    [System.Serializable] public struct Question_Info
    {
        [Header("출제 수")] public int question_count;
        [Header("현재 문제 수")] public int current_question_count;
        [Header("목표 정답 수")] public int target_correct_value;
        [Header("현재 정답 수")] public int current_correct_value;
    }

    [Header("게임 세팅")]
    public Question_Info question_info;
    [TextArea] public string[] camel_dialogue = new string[2]; // 0: 목표치 달성 시 1: 목표치 달성 못할 시
    public GameObject reward_item;

    void Awake()
    {
        StartCoroutine(CreateProblem());

        question_info.current_question_count++;

        if (question_info.question_count == 0) // 나중에 진단평가 여부에 따라 진단평ㅇ가 안했음 8문제만 제출하게 수정
            question_info.question_count = 5;
    }

    IEnumerator CreateProblem()
    {
        yield return new WaitForSeconds(1f);

        scWJAPI.MakeQuestion();
        StartCoroutine(Selection_Text_Setting());
    }

    IEnumerator Selection_Text_Setting()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < texSelection.Length; i++)
            texSelection[i].text = scWJAPI.Answer_Selection[i];

        tdr.text = "\\scdd" + scWJAPI.Problem_Explain;
    }

    public void Click_Answer(int _nIndex)
    {
        if (Check_Answer(_nIndex))
            Move_Camel();
        else
            Panelty();

        if (question_info.current_question_count < question_info.question_count)
        {
            scWJAPI.OnClick_Ansr(_nIndex);
            question_info.current_question_count++;

            StartCoroutine(Selection_Text_Setting());
        }
        else
        {

        }
    }

    bool Check_Answer(int button_num)
    {
        if (texSelection[button_num].text == scWJAPI.Problem_Answer)
            return true;
        else
            return false;
    }

    void Move_Camel()
    {
        Clear_Answer_Box(true);
        question_info.current_correct_value++;
    }

    void Panelty()
    {
        Clear_Answer_Box(false);
    }

    void Clear_Answer_Box(bool b)
    {
        for (int i = 0; i < texSelection.Length; i++)
            texSelection[i].text = "";

        if (b) { tdr.text = "\\scdd 정답이에요 !"; }
        else { tdr.text = "\\scdd 틀렸어요...!"; }
    }

    void Result()
    {
        //보상 아이템 지급
        //메인게임으로 돌아가기 버튼 활성
    }

    void Change_Main_Scene()
    {

    }
}