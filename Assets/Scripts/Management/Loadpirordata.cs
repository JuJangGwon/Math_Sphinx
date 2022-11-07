using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadpirordata : MonoBehaviour
{
    public GameObject character;
    public int playerpos;

    float newgame;
    public float max_handlight;
    public float now_handlgiht;

    void setPirorData()
    {
        PlayerPrefs.SetInt("playerpos",1);
        PlayerPrefs.GetFloat("max_handlight", 1);
        PlayerPrefs.GetFloat("playerpos", 1);
        PlayerPrefs.SetInt("newgame", 1);

    }

    public void getPirorData()
    {
        setPirorData();
        playerpos = PlayerPrefs.GetInt("playerpos");
        max_handlight = PlayerPrefs.GetFloat("max_handlight");
        now_handlgiht = PlayerPrefs.GetFloat("now_handlgiht");
        newgame = PlayerPrefs.GetInt("newgame");
        switch(playerpos)
        {
            case 1:
                character.transform.localPosition = new Vector3(-72, 49, 0);
                break;
            case 2:
                character.transform.localPosition = new Vector3(-15.2f, 10.4f, 0);
                break;
            case 3:
                character.transform.localPosition = new Vector3(10, 13, 0);
                break;
        }
    }
    public float getNewgame()
    {
        return newgame;
    }
}
