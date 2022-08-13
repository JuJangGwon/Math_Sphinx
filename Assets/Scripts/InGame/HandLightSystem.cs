using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandLightSystem : MonoBehaviour
{
    public float Max_handlight_time = 30f;
    public float handlight_lifetime = 30f;
    public float warning_time = 15f;
    Image handlight_img;
    float handlightTimer_percentage = 1f;
    void Start()
    {
        handlight_img = GetComponent<Image>();
    }

    void Update()
    {
        handlight_lifetime -= Time.deltaTime;
        handlight_img.fillAmount = handlight_lifetime / Max_handlight_time;


        if (handlight_lifetime == 0)        // 끝났음
        {

        }
    }
    public void Get_handlightbettery()
    {
        handlight_lifetime += 30;
    }
}
