using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHomeButton : MonoBehaviour
{
    public void ButtonManager(int i)
    {
        switch(i)
        {
            case 1:     // 탐험하기버튼
                PlayerPrefs.SetInt("pos", 1);
                PlayerPrefs.SetInt("newgame", 1);
                PlayerPrefs.SetFloat("max_handlight", 80f);
                PlayerPrefs.SetFloat("now_handlgiht", 80f);
                SceneManager.LoadScene(0);
                break;
            case 2:
                break;
        }
    }
}
