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
    public TextMeshProUGUI texPorblem;
    public TextMeshProUGUI[] texSelection;

    [Header("플레이어 라이프")]
    public int current_life = 3;
    public Image[] life_images = new Image[3];
    public Color[] life_colours = new Color[2];         //추후에 이미지로 변경 예정

    [Header("플레이어")]
    public GameObject camel_object;
    public GameObject camera_camel;

    void Awake()
    {
        StartCoroutine(CreateProblem());
    }

    IEnumerator CreateProblem()
    {
        yield return new WaitForSeconds(0f);
        scWJAPI.MakeQuestion();
        StartCoroutine(Selection_Text_Setting());
        texPorblem.text = scWJAPI.Problem_Explain;
    }

    IEnumerator Selection_Text_Setting()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < texSelection.Length; i++)
            texSelection[i].text = scWJAPI.Answer_Selection[i];
    }

    public void Click_Answer(int _nIndex)
    {
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
        print("맞았습니다.");
    }

    void Panelty()
    {
        current_life--;
        life_images[current_life].color = life_colours[1];

        if (current_life == 0)
        {
            print("으앙 쥬금");
        }
    }
}