using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadpirordata : MonoBehaviour
{
    public HandLightSystem handLightsystem_cs;

    public GameObject character;
    public int playerpos;

    float newgame;
    public float max_handlight;
    public float now_handlgiht;

    /*void setDefaultPirorData()
    {
        PlayerPrefs.SetInt("pos",1);
        PlayerPrefs.SetFloat("max_handlight",30);
      //  PlayerPrefs.SetFloat("playerpos", 30);
        PlayerPrefs.SetInt("newgame", 1);
    }
    */
    public void setPirorData(int i)   // i = 1 시작지점 ,  i = 2 낙타게임,   i = 3 양탄자게임 
    {
        Debug.Log(i);
        PlayerPrefs.SetInt("pos", i);
        //PlayerPrefs.SetFloat("max_handlight", handLightsystem_cs.Max_handlight_time);
        //PlayerPrefs.SetFloat("playerpos", handLightsystem_cs.handlight_now_left_time);
        PlayerPrefs.SetInt("newgame", 0);
    }

    public void getPirorData()
    {
      //  setDefaultPirorData();
        playerpos = PlayerPrefs.GetInt("pos");
        //max_handlight = PlayerPrefs.GetFloat("max_handlight");
        //now_handlgiht = PlayerPrefs.GetFloat("now_handlgiht");
        newgame = PlayerPrefs.GetInt("newgame");
        switch(PlayerPrefs.GetInt("pos"))
        {
            case 1:
                character.transform.localPosition = new Vector3(-72, 49, 0);
                break;
            case 2:
                character.transform.localPosition = new Vector3(-14.4f, 102.8f, 0);
                break;
            case 3:
                character.transform.localPosition = new Vector3(-11.2f, 14.6f, 0);
                break;
        }
    }
    private void Update()
    {
        Debug.Log(InGameManeger.ingamestate);
    }
    public float getNewgame()
    {
        return newgame;
    }
}
