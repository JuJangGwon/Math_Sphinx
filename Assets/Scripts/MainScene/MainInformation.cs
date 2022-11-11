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
    string score_text { get { return AWS.instance.current_user.score.ToString(); } }
    string ranking_text { get { return AWS.instance.current_user.nickname; } }
    string money_text { get { return AWS.instance.current_user.money.ToString(); } }

    void Awake()
    {
        info_udater = new Info_Udate(money_tmp, score_tmp);
        Text_Setting();
    }

    void Update()
    {

    }

    void Text_Setting()
    {
        nickname_tmp.text = AWS.instance.current_user.nickname;
        money_tmp.text = info_udater.Money.ToString();
        score_tmp.text = info_udater.Score.ToString();
    }
}
