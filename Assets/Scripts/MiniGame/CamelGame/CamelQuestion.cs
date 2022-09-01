using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CamelQuestion : MonoBehaviour
{
    public WJAPI scWJAPI;
    public TextMeshProUGUI texPorblem;
    public TextMeshProUGUI[] texSelection;
    public int Answer = 0;

    void Awake()
    {
        CreateProblem();
    }

    void CreateProblem()
    {
        scWJAPI.MakeQuestion();
        Selection_Text_Setting();

    }

    void Selection_Text_Setting()
    {
        for (int i = 0; i < texSelection.Length; i++)
            texSelection[i].text = scWJAPI.Answer_Selection[i];
    }
}
