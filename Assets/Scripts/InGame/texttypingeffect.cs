using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class texttypingeffect : MonoBehaviour
{
    public Text m_TypingText;
    float m_Speed = 0.04f;

    string[] prog_game_text = { "탐험가 : 분명히 여기에 보물이 있다고 했는데? 어? 이상하다?" ,
                                   "스핑크스: 뭐라? 감히 내게 반말이라니! 용서할 수 없다!",
                                   "탐험가: 아아?? 근데 여기 정말 보물이 많아?",
                                   "스핑크스: 물론이다.피라미드 안에 미로가 있고, 그 끝에 값비싼 보물들이 많다.\n 여기까지 탐험을 온 네 용기를 높게 사 기회를 주마.",
                                   "스핑크스: 좋다. 이것으로 널 테스트하지.",
                                   "이곳으로 간다면 피라미드로 가는 길이 있다.",
                                   "하지만 여러 갈래의 길이 있고, 어떤 길을 선택하느냐에 따라 \n 네가 마주하는 피라미드가 달라질 것이다. 음하하하."};



    public void prog_gametext(int i)
    {
        if (i != 7)
        {
            StartCoroutine(Typing(1, prog_game_text[i], m_Speed));
        }
    }
    IEnumerator Typing(int who, string message, float speed)
    {
        if (who == 1)   // 탐험가

            m_TypingText.text = message.Substring(0, 5);
        else if (who == 2)
            m_TypingText.text = message.Substring(0, 6);


        for (int i = who+4; i < message.Length; i++)
        {
            m_TypingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
    }
}
