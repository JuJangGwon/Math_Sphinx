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

    [Header("플레이어 라이프")]
    public int current_life = 3;
    public Image[] life_images = new Image[3];
    public Color[] life_colours = new Color[2];         //추후에 이미지로 변경 예정

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

        tdr.text = scWJAPI.Problem_Explain;
    }

    public void Click_Answer(int _nIndex)
    {
        question_info.current_question_count++;

        if (Check_Answer(_nIndex))
            Move_Camel();
        else
            Panelty();

        scWJAPI.OnClick_Ansr(_nIndex);

        StartCoroutine(Selection_Text_Setting());
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
        print("정답입니다.");

        question_info.current_correct_value++;
    }

    void Panelty()
    {
        print("오답입니다.");

        current_life--;
        life_images[current_life].color = life_colours[1];

        if (current_life == 0)
        {
            print("으앙 쥬금");
        }
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