using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Battery_lv
{
    none,
    Full,                   // 40 ~ 100
    half,                   // 10 ~ 40
    less,                   // 0  ~ 10
}

public class HandLightSystem : MonoBehaviour
{
    public float Max_handlight_time = 30f;                      // 손전등 최대 시간 
    public float handlight_now_left_time = 30f;                      // 손전등 현재 시간
    public float warning_time = 15f;
    float handlight_left_battery_percentage = 1f;                   // 남은 배터리 % [0~1]

    public InGameManeger inGameManeger_cs;

  //  public GameObject edge_dark2_obj;                           // 죽을때 가에 띄울 어둠 
    public GameObject edge_dark_obj;
    public Image edge_dark_img;
    public Image handlight_img;
    public Image light_img;
    Battery_lv battery_lv = Battery_lv.none;



    void Start()
    {
        InGameManeger.gameState = GameState.playingInGame;
        battery_lv = Battery_lv.Full;
        light_img.color = new Color(255, 255, 255, 255);
    }

    void battery_management()
    {
        if (handlight_left_battery_percentage <= 0f)            // 배터리나갔을때
        {
            Character_move._characterstate = CharacterState.die;
            battery_lv = Battery_lv.none;
            StartCoroutine(CircleFadeIn(3));
            InGameManeger.gameState = GameState.timeout;
        }
        else if (handlight_left_battery_percentage <= 0.1f)
        {
            if (battery_lv != Battery_lv.less)
            {
                StartCoroutine(LightBlink_cor(3, 0));
                StartCoroutine(CircleFadeIn(2));
                battery_lv = Battery_lv.less;
            }
        }
        else if (handlight_left_battery_percentage <= 0.4f)
        {
            if (battery_lv != Battery_lv.half)
            {
                StartCoroutine(LightBlink_cor(3, 0.4f));
                StartCoroutine(CircleFadeIn(1));
                battery_lv = Battery_lv.half;
            }
        }
        else if (handlight_left_battery_percentage >= 0.4f)
            battery_lv = Battery_lv.Full;

    }
    void Update()
    {
        if (InGameManeger.gameState == GameState.playingInGame)
        {
            handlight_now_left_time -= Time.deltaTime;
            handlight_left_battery_percentage = handlight_now_left_time / Max_handlight_time;

            handlight_img.fillAmount = handlight_left_battery_percentage;
            battery_management();
            // 
        }
    }


    public void Get_handlightbettery()
    {
        handlight_now_left_time = 20;
        battery_lv = Battery_lv.Full;
        edge_dark_obj.SetActive(false);
    }




    // 코루틴


    IEnumerator LightBlink_cor(int time, float opacity)   // 손전등 빛 깜빡 깜박 (횟수 , 사용 후 img 투명도)
    {
        for (int i = 0; i < time * 2; i++)
        {
            if (i % 2 == 0)
                light_img.color = new Color(255, 255, 255, 0);
            if (i % 2 == 1)
                light_img.color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(0.3f);
        }
        light_img.color = new Color(255, 255, 255, opacity);
        yield return new WaitForSeconds(0.1f);
    }



    IEnumerator CircleFadeIn(int lv)           // 서클 Fade In.
    {
        switch (lv)                                                     // 주변 잠깐 어둡 
        {
            case 1:
                edge_dark_obj.SetActive(true);
                edge_dark_obj.transform.localScale = new Vector3(2.6f, 2.3f, 1);
                for (int i = 0; i <= 10; i++)
                {
                    edge_dark_obj.transform.localScale = new Vector3(2.6f - (0.06f * i), 2.3f - (0.05f * i), 1f);
                    yield return new WaitForSeconds(0.05f);
                }
                break;
            case 2:                                                   // 아주 많이 어둡
                edge_dark_obj.transform.localScale = new Vector3(2.0f, 1.8f, 1);
                for (int i = 0; i <= 12; i++)
                {
                    edge_dark_obj.transform.localScale = new Vector3(2.0f - (0.08f * i), 1.8f - (0.06f * i), 1f);
                    yield return new WaitForSeconds(0.05f);
                }
                break;
            case 3:                         // 리소스 필요함. 
                //edge_dark2_obj.SetActive(true);                   // 맵 어둠으로 덮어버리기
                //edge_dark_obj.transform.localScale = new Vector3(1.0f, 1.0f, 1);
                //for (int i = 0; i <= 10; i++)
                {
                //    edge_dark_obj.transform.localScale = new Vector3(1.0f - (0.05f * i), 1.0f - (0.05f * i), 1f);
                //    yield return new WaitForSeconds(0.05f);
                }
                break;
        }
    }
}