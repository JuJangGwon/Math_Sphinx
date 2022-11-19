using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainInformation : MonoBehaviour
{
    Info_Udate info_udater;
    public TextMeshProUGUI nickname_tmp;
    public TextMeshProUGUI money_tmp;
    public TextMeshProUGUI score_tmp;

    string nickname_text { get { return AWS.instance.current_user.nickname; } }
    string score_text { get { return PlayerPrefs.GetInt("Score").ToString(); } }
    string ranking_text { get { return AWS.instance.current_user.nickname; } }
    string money_text { get { return PlayerPrefs.GetInt("Money").ToString(); } }

    void Awake()
    {
        info_udater = new Info_Udate(money_tmp, score_tmp);
        Text_Setting();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) { info_udater.Money -= 10; }
    }

    void Text_Setting()
    {
        nickname_tmp.text = AWS.instance.current_user.nickname;
        money_tmp.text = PlayerPrefs.GetInt("Money").ToString();
        money_tmp.text = money_text;
        score_tmp.text = PlayerPrefs.GetInt("Score").ToString();
    }

    public void buy()
    {
        info_udater.Money -= 1000;
    }
}
