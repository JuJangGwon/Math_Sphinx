using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum Now_text
{
    none,
    prog_game,
    prog_game2,
    prog_game3,
    prog_game4

}

public class texttypingeffect : MonoBehaviour, IPointerDownHandler
{
    public GameObject darkgb;
    public Image darkimg;
    public InGameManeger ingameManeger_cs;
    public GameObject text_board;

    public GameObject joystick_b;
    public GameObject dash_b;
    int now_textline = 0;
    bool now_typing = false;
    public Text m_TypingText;
    Now_text now_text = Now_text.none;
    float m_Speed = 0.04f;

    string[] prog_game_text = { "탐험가 : 분명히 여기에 보물이 있다고 했는데? 어? 이상하다?" ,
                                   "스핑크스: 뭐라? 감히 내게 반말이라니! 용서할 수 없다!",
                                   "탐험가: 아아?? 근데 여기 정말 보물이 많아?",
                                   "스핑크스: 물론이다.피라미드 안에 미로가 있고, 그 끝에 값비싼 보물들이 많다.\n 여기까지 탐험을 온 네 용기를 높게 사 기회를 주마.",
                                   "스핑크스: 좋다. 이것으로 널 테스트하지.",
                                   "이곳으로 간다면 피라미드로 가는 길이 있다.",
                                   "하지만 여러 갈래의 길이 있고, 어떤 길을 선택하느냐에 따라 \n 네가 마주하는 피라미드가 달라질 것이다. 음하하하."};
    string[] prog_game_text2 = { "탐험가 : 어라? 손전등 배터리가 얼마 남지 않았어",
                                 "스핑크스 : 손전등의 배터리는 미니게임과 보물상자를 통해 얻을 수 있지",
                                 "탐험가 : 그럼 미니게임은 어디서 할 수 있는데 ?",
                                 "스핑크스 : 저기 저 앞에 파란색 포탈에 들어가봐 ... "

    };
    //낙타게임
    string[] prog_game_text3 = { "낙타 : 덕분에 쉽게 올 수 있었어! \n 아마 이쪽으로 가면 보물이 나올 것 같은데?" };
    string[] prog_game_text4 = { "낙타 : 오는 길이 너무 헷갈렸어. \n 난 이제 쉬어야겠어." };
    int findWho(string str)
    {
        for (int i = 0; i < str.Length;i++)
        {
            if (str[i] == ':')
            {
                return i + 1;
            }
        }
        return 0;
    }
    public void darkfadeoutf()
    {
        StartCoroutine(Darkfadeout());
    }
    public void darkfadeinf()
    {
        StartCoroutine(DarkfadeIn());
    }
    public void prog_gametext(int i)
    {
        joystick_b.SetActive(false);
        dash_b.SetActive(false);

        now_textline = i;
        now_text = Now_text.prog_game;
        if (i != 7)
        {
            StartCoroutine(Typing(1, prog_game_text[i], m_Speed));
        }
        if (i >= 7)
        {
            joystick_b.SetActive(true);
            dash_b.SetActive(true);
            now_textline = 0;
            now_text = Now_text.none;
          //  InGameManeger.ingamestate = InGameState.proggamestart;
            text_board.SetActive(false);
            darkgb.SetActive(false);
        }
    }
    public void prog_gametext2(int i)
    {
        joystick_b.SetActive(false);
        dash_b.SetActive(false);
        now_textline = i;
        now_text = Now_text.prog_game2;
        if (i != 4)
        {
            StartCoroutine(Typing(1, prog_game_text2[i], m_Speed));
        }
        if (i >= 4)
        {
            now_textline = 0;
            now_text = Now_text.none;
            text_board.SetActive(false);
            darkgb.SetActive(false);
            joystick_b.SetActive(true);
            dash_b.SetActive(true);
            InGameManeger.gameState = GameState.playingInGame;
        }
    }

    public void prog_gametext3(int i)
    {
        darkgb.SetActive(true);
        now_textline = i;
        now_text = Now_text.prog_game3;
        if (i != 1)
        {
            StartCoroutine(Typing(1, prog_game_text3[i], m_Speed));
        }
        if (i >= 1)
        {
            now_textline = 0;
            now_text = Now_text.none;
            text_board.SetActive(false);
            darkgb.SetActive(false);
            InGameManeger.gameState = GameState.playingInGame;
        }
    }

    public void prog_gametext4(int i)
    {
        darkgb.SetActive(true);
        now_textline = i;
        now_text = Now_text.prog_game4;
        if (i != 1)
        {
            StartCoroutine(Typing(1, prog_game_text4[i], m_Speed));
        }
        if (i >= 1)
        {
            now_textline = 0;
            now_text = Now_text.none;
            text_board.SetActive(false);
            darkgb.SetActive(false);
            InGameManeger.gameState = GameState.playingInGame;
        }
    }

    IEnumerator Typing(int who, string message, float speed)
    {
        text_board.SetActive(true);
        m_TypingText.text = message.Substring(0, findWho(message));
        now_typing = true;
        for (int i = who+4; i < message.Length; i++)
        {
            if (now_typing == false)
            {
                m_TypingText.text = message;
                break;
            }
            m_TypingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(0.0f);
    }

    public IEnumerator Darkfadeout()
    {
        darkgb.SetActive(true);
        for (int i = 0; i < 32;i++)
        {
            darkimg.color = new Vector4(0, 0,0, 1 - i * 0.02f);
            yield return new WaitForSeconds(0.03f);
        }
        InGameManeger.ingamestate = InGameState.texttyping;
    }
    public IEnumerator DarkfadeIn()
    {
        darkgb.SetActive(true);
        for (int i = 0; i < 33; i++)
        {
            darkimg.color = new Vector4(0, 0, 0, 0 + i * 0.03f);
            yield return new WaitForSeconds(0.03f);
        }
       // InGameManeger.ingamestate = InGameState.batteryex4;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (now_typing == true)
        {
            now_typing = false;
        }
        else
        {
            switch (now_text)
            {
                case Now_text.prog_game:
                    prog_gametext(++now_textline);
                    break;
                case Now_text.prog_game2:
                    prog_gametext2(++now_textline);
                    break;
                case Now_text.prog_game3:
                    prog_gametext3(++now_textline);
                    break;
                case Now_text.prog_game4:
                    prog_gametext4(++now_textline);
                    break;
            }
        }
    }
}
