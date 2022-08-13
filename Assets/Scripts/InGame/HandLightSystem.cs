using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Dark_lv
{
    none,
    _1lv,
    _2lv
}

public class HandLightSystem : MonoBehaviour
{
    public float Max_handlight_time = 30f;
    public float handlight_lifetime = 30f;
    public float warning_time = 15f;
    float handlightTimer_percentage = 1f;

    public InGameManeger inGameManeger_cs;

    public GameObject edge_dark_obj;
    public Image edge_dark_img;
    Image handlight_img;

    Dark_lv dark_lv = Dark_lv.none;

    void Start()
    {
        handlight_img = GetComponent<Image>();
    }

    void Update()
    {
        //if (inGameManeger_cs.gameState == GameState.playingInGame)
        {
            handlight_lifetime -= Time.deltaTime;
            handlight_img.fillAmount = handlight_lifetime / Max_handlight_time;
            if (handlight_lifetime < 28 && dark_lv == Dark_lv.none)
            {
                dark_lv = Dark_lv._1lv;
                StartCoroutine(CircleFadeIn_step1());
            }
            if (handlight_lifetime == 0)        // 끝났음
            {
                inGameManeger_cs.gameState = GameState.timeout;
            }
        }
    }
    public void Get_handlightbettery()
    {
        handlight_lifetime += 30;
    }
    
    IEnumerator CircleFadeIn_step1()           // 1단계
    {
        edge_dark_obj.SetActive(true);
        edge_dark_obj.transform.localScale = new Vector3(2.6f, 2.3f, 1);
        for (int i = 0; i <= 20; i++)
        {
            edge_dark_obj.transform.localScale = new Vector3(2.6f - (0.06f * i), 2.3f - (0.05f * i), 1f);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
