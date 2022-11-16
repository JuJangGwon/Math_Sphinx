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

    [Header("메뉴")]
    public GameObject menu;
    public GameObject credit;

    [Header("화면 좌우 이동 슥슥")]
    public Animation scene_anime;
    public List<string> scene_anime_array = new List<string>();

    public void ButtonManager(int i)
    {
        switch(i)
        {
            case 1:     // 탐험하기버튼
                PlayerPrefs.SetInt("pos", 1);
                PlayerPrefs.SetInt("newgame", 1);
                PlayerPrefs.SetFloat("max_handlight", 100f);
                PlayerPrefs.SetFloat("now_handlgiht", 100f);
                //SceneManager.LoadScene("InGameScene");
                LoadingScene.Load_Scene("InGameScene");
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
    public void Open()
    {
        menu.SetActive(true);
        credit.SetActive(false);
        menu_anime.SetTrigger(open);
    }
    public void Close() { menu_anime.SetTrigger(close); }

    public void On_Credit()
    {
        menu.SetActive(false);
        credit.SetActive(true);
    }

    public void Off_Credit()
    {
        menu.SetActive(true);
        credit.SetActive(false);
    }

    public void Go_Stage_Select(bool b)
    {
        AnimationArray();
        if (b) { scene_anime.Play(scene_anime_array[0]); }
        else { scene_anime.Play(scene_anime_array[1]); }
    }

    public void Go_Shop_Button()
    {
        AnimationArray();
        scene_anime.Play(scene_anime_array[2]);
    }

    void AnimationArray()
    {
        foreach (AnimationState state in scene_anime)
            scene_anime_array.Add(state.name);
    }
}
