using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum Now_text
{
    none,
    start1stage,
    findkey,
    minigame1,
    minigame2,
    findtreasure,
    prog_game,
    prog_game2,
    prog_game3,
    prog_game4

}

public class texttypingeffect : MonoBehaviour, IPointerDownHandler
{
    public Character_move character_move_cs;
    public InGameManeger ingameManeger_cs;
    public FindAnswerWay findanswerway_cs;

    public GameObject character_nametag;
    public GameObject helper_nametag;
//    public GameObject camel_nametag;

    public GameObject character_sprite;
    public GameObject helper_sprite;
    public Image character_img;
    public Image helper_img;

    public Sprite   [] talkingcharacterilerstrate;  // 1. 주인공 평범 , 2. 주인공 놀람, 3. 주인공 웃음 ,4 조력자 평범 5. 조력자 놀람, 6. 조력자 웃음 , 7 낙타 
    public GameObject darkgb;               
    public Image darkimg;
    public GameObject text_board;
    public GameObject joystick_b;
    public GameObject dash_b;

    int now_textline = 0;
    bool now_typing = false;
    public Text m_TypingText;
    public static Now_text now_text = Now_text.none;

    float m_Speed = 0.04f;

    string[] start1stage_text= {"1 : 분명히 여기에 보물이 있다고 했는데? 어? 이상하다?" ,
                                   "4 : 뭐라? 감히 내게 반말이라니! 용서할 수 없다!",
                                   "1 : 아아?? 근데 여기 정말 보물이 많아?",
                                   "4 : 물론이다.피라미드 안에 미로가 있고, 그 끝에 값비싼 보물들이 많다.\n 여기까지 탐험을 온 네 용기를 높게 사 기회를 주마.",
                                   "1 : 좋다. 이것으로 널 테스트하지.",
                                   "1 : 이곳으로 간다면 피라미드로 가는 길이 있다.",
                                   "1 : 하지만 여러 갈래의 길이 있고, 어떤 길을 선택하느냐에 따라 \n 네가 마주하는 피라미드가 달라질 것이다. 음하하하."};
    Vector2[] start1stage_who = { new Vector2(2, 4), new Vector2(5, 2), new Vector2(1, 5), new Vector2(4, 1), new Vector2(4, 1), new Vector2(4, 1), new Vector2(4, 1) };
    string[] findtreasure_text = { "1 : 엇 보물 상자가 나왔어",
                          "4 : 열쇠가 있다면 열어보라구..!"};
    Vector2[] findtreasure_who = { new Vector2(2, 4), new Vector2(6, 1) };
    string[] findkey_text = { "1 : 키를 발견했어!" };
    Vector2[] findkey_who = { new Vector2(1, 4) };

    string[] minigame1_text = { "2 : 어머 낭떠러지야..!",
                                "2 : 더 이상 지나갈 수 없겠는걸 ...?",
                                "4 : 아니..",
                                "4 : 저기 낭떠러지를 건널 수 있는 마법의 양탄자가 있어...",
                                "6 : 저 마법의 양탄자를 타고 넘어가든지 돌아가든지 알아서 하라구.... 겁쟁이 탐험가..." };
    string[] minigame2_text = { "4 : 여기서부터는 낙타를 타고 이동해야해",
                                "2 : 그럼 낙타를 타고 이동해볼까?",
                                };
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
    string[] prog_game_text3 = { "7 : 덕분에 쉽게 올 수 있었어! \n 아마 이쪽으로 가면 보물이 나올 것 같은데?" };
    string[] prog_game_text4 = { "7 : 오는 길이 너무 헷갈렸어. \n 난 이제 쉬어야겠어." };

    void whostalking(Vector2 v)
    {
        character_nametag.SetActive(false);
        helper_nametag.SetActive(false);
//        camel_nametag.SetActive(false);

        character_sprite.SetActive(false);
        helper_sprite.SetActive(false);
        character_sprite.transform.localScale = new Vector3(1, 1, 1);
        helper_sprite.transform.localScale = new Vector3(1, 1, 1);
        character_img.color = new Color(255, 255, 255);
        helper_img.color = new Color(255, 255, 255);

        switch (v.x)
        {
            case 1:
                character_nametag.SetActive(true);
                character_sprite.SetActive(true);
                character_sprite.transform.localScale = new Vector3(1.1f, 1.1f, 1);
                break;
            case 2:
                character_nametag.SetActive(true);
                character_sprite.SetActive(true);
                character_sprite.transform.localScale = new Vector3(1.1f, 1.1f, 1);
                break;
            case 3:
                character_nametag.SetActive(true);
                character_sprite.SetActive(true);
                character_sprite.transform.localScale = new Vector3(1.1f, 1.1f, 1);
                break;
            case 4:
                helper_nametag.SetActive(true);
                helper_sprite.SetActive(true);
                helper_sprite.transform.localScale = new Vector3(1.1f, 1.1f, 1);
                break;
            case 5:
                helper_nametag.SetActive(true);
                helper_sprite.SetActive(true);
                helper_sprite.transform.localScale = new Vector3(1.1f, 1.1f, 1);
                break;
            case 6:
                helper_nametag.SetActive(true);
                helper_sprite.SetActive(true);
                helper_sprite.transform.localScale = new Vector3(1.1f, 1.1f, 1);
                break;
            case '7':
           //     camel_nametag.SetActive(true);
                break;
        }
            Debug.Log(v.y);
        switch ((int)v.y)
        {
            case 1:
                character_sprite.SetActive(true);
                character_img.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case 2:
                character_sprite.SetActive(true);
                character_img.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case 3:
                character_sprite.SetActive(true);
                character_img.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case 4:
                helper_sprite.SetActive(true);
                helper_img.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case 5:
                helper_sprite.SetActive(true);
                helper_img.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case 6:
                helper_sprite.SetActive(true);
                helper_img.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case '7':
            //    camel_nametag.SetActive(true);
                break;
        }

    }
    void hideUI(bool _onoff)
    {
        if (_onoff)
        {
            character_move_cs.CharacterStop(true);
            joystick_b.SetActive(false);
            dash_b.SetActive(false);
        }
        else
        {
            joystick_b.SetActive(true);
            dash_b.SetActive(true);
            now_textline = 0;
            now_text = Now_text.none;
            text_board.SetActive(false);
            darkgb.SetActive(false);
        }
    }
    public void start1stage(int i)
    {
        hideUI(true);
        now_textline = i;
        now_text = Now_text.start1stage;
        if (i != 6)
        {
            StartCoroutine(Typing(1, start1stage_text[i], m_Speed));
            whostalking(start1stage_who[i]);
        }
        else if (i >= 6)
        {
            hideUI(false);
            findanswerway_cs.ShowProblempopup(true);
            InGameManeger.ingamestate = InGameState.playgame;
        }
    }

    public void findtreasure(int i)
    {
        hideUI(true);
        now_textline = i;
        now_text = Now_text.findtreasure;
        if (i != 2)
            StartCoroutine(Typing(1, findtreasure_text[i], m_Speed));
        else if (i >= 2)
        {
            hideUI(false);
            InGameManeger.ingamestate = InGameState.playgame;
        }
    }

    public void minigame1(int i)
    {
        hideUI(true);
        now_textline = i;
        now_text = Now_text.minigame1;
        if (i != 5)
            StartCoroutine(Typing(1, minigame1_text[i], m_Speed));
        else if (i >= 5)
        {
            hideUI(false);
            InGameManeger.ingamestate = InGameState.playgame;
        }
    }
    public void minigame2(int i)
    {
        hideUI(true);
        now_textline = i;
        now_text = Now_text.minigame2;
        if (i != 2)
            StartCoroutine(Typing(1, minigame2_text[i], m_Speed));
        else if (i >= 2)
        {
            hideUI(false);
            InGameManeger.ingamestate = InGameState.playgame;
        }
    }


    public void findkey(int i)
    {
        hideUI(true);
        now_textline = i;
        now_text = Now_text.findkey;
        if (i != 1)
            StartCoroutine(Typing(1, findkey_text[i], m_Speed));
        else if(i >= 1)
        {
            hideUI(false);
            InGameManeger.ingamestate = InGameState.playgame;
        }
    }
    //



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
        now_typing = true;
       // whostalking(message[0]);
        for (int i = 4; i < message.Length - 1; i++)
        {
            if (now_typing == false)
            {
                m_TypingText.text = message.Substring(4, message.Length - 4);
                break;
            }
            m_TypingText.text = message.Substring(4, i-2);
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
                case Now_text.findkey:
                    findkey(++now_textline);
                    break;
                case Now_text.minigame1:
                    minigame1(++now_textline);
                    break;
                case Now_text.minigame2:
                    minigame2(++now_textline);
                    break;
                case Now_text.findtreasure:
                    findtreasure(++now_textline);
                    break;
                case Now_text.start1stage:
                    start1stage(++now_textline);
                    break;
            }
        }
    }
}
