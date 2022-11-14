using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHomeButton : MonoBehaviour
{
    public GameObject problem_history;

    [Header("FadeIO Animator")]
    public Animator fade_io_anime;
    int open_ph = Animator.StringToHash("Open_ph");
    int close_ph = Animator.StringToHash("Close_ph");
    public Animator menu_anime;
    int open = Animator.StringToHash("Open");
    int close = Animator.StringToHash("Close");

    public void ButtonManager(int i)
    {
        switch(i)
        {
            case 1:     // 탐험하기버튼
                PlayerPrefs.SetInt("pos", 1);
                PlayerPrefs.SetInt("newgame", 1);
                PlayerPrefs.SetFloat("max_handlight", 115f);
                PlayerPrefs.SetFloat("now_handlgiht", 115f);
                PlayerPrefs.SetInt("is_key1", System.Convert.ToInt16(false));
                PlayerPrefs.SetInt("is_key2", System.Convert.ToInt16(false));
                SceneManager.LoadScene("InGameScene");
                break;
            case 2:
                problem_history.SetActive(true);
                break;
        }
    }

    public void Close_PU()
    {
        fade_io_anime.SetTrigger(close_ph);
    }

    public void Open_PU()
    {
        fade_io_anime.SetTrigger(open_ph);
    }
    public void Open() { menu_anime.SetTrigger(open); }
    public void Close() { menu_anime.SetTrigger(close); }
}
