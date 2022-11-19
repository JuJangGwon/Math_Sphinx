using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHomeButton : MonoBehaviour
{
    public GameObject problem_history;
    public ProblemHistory ph;

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

    [Header("팝업 체크")]
    public bool Bpreparing = false;
    public bool Bmenu = false;
    public bool Bproblem_history_popup = false;
    public bool Bstore = false;
    public bool Bstage = false;
    public bool Bexit = false;

    [Header("상점 페이지")]
    public GameObject page_0;
    public GameObject page_1;
    public GameObject page_2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Input_Escape(); }
    }

    public void Input_Escape()
    {
        if (Bpreparing) { Open_Preparing(true); }
        else if (Bmenu) { Close(); }
        else if (Bproblem_history_popup) { ph.Close_PBH(); }
        else if (Bstore) { Go_Shop_Button(false); }
        else if (Bstage) { Go_Stage_Select(true); }
        else { Open_Exit(Bexit); }
    }

    public void ButtonManager(int i)
    {
        switch(i)
        {
            case 1:     // 탐험하기버튼
                PlayerPrefs.SetInt("Mode",2);
                PlayerPrefs.SetInt("pos", 1);
                PlayerPrefs.SetInt("newgame", 1);
                PlayerPrefs.SetFloat("max_handlight", 115f);
                PlayerPrefs.SetFloat("now_handlgiht", 115f);
                PlayerPrefs.SetInt("is_key1", System.Convert.ToInt16(false));
                PlayerPrefs.SetInt("is_key2", System.Convert.ToInt16(false));
                LoadingScene.Load_Scene("InGameScene");
                break;

            case 2:
                problem_history.SetActive(true);
                break;
            case 3:     // 튜토리얼
                PlayerPrefs.SetInt("Mode", 3);
                PlayerPrefs.SetInt("pos", 1);
                PlayerPrefs.SetInt("newgame", 1);
                PlayerPrefs.SetFloat("max_handlight", 100f);
                PlayerPrefs.SetFloat("now_handlgiht", 100f);
                //SceneManager.LoadScene("InGameScene");
                LoadingScene.Load_Scene("TutorialScene");
                PlayerPrefs.SetFloat("max_handlight", 115f);
                PlayerPrefs.SetFloat("now_handlgiht", 115f);
  
                SceneManager.LoadScene("TutorialScene");
                break;
        }
    }

    public void Close_PU()
    {
        fade_io_anime.SetTrigger(close_ph);
        Bproblem_history_popup = false;
    }

    public void Open_PU()
    {
        fade_io_anime.SetTrigger(open_ph);
        Bproblem_history_popup = true;
    }
    public void Open()
    {
        menu.SetActive(true);
        credit.SetActive(false);
        menu_anime.SetTrigger(open);
        Bmenu = true;
    }
    public void Close() { menu_anime.SetTrigger(close); Bmenu = false; }

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
        if (b) { scene_anime.Play("go_main"); Bstage = false; }
        else { scene_anime.Play("go_stage"); Bstage = true; }
    }

    public void Go_Shop_Button(bool b)
    {
        if (b) { scene_anime.Play("go_shop"); Bstore = true; }
        else { scene_anime.Play("go_main_from_shop"); Bstore = false; }
    }

    public void Open_Preparing(bool b)
    {
        if (b) { scene_anime.Play("close_preparing"); Bpreparing = false; }
        else { scene_anime.Play("open_preparing"); Bpreparing = true; }
    }

    public void Open_Exit(bool b)
    {
        if (b) { scene_anime.Play("close_exit"); Bexit = false; }
        else
        {
            if (Bmenu) { Close(); }
            scene_anime.Play("open_exit");
            Bexit = true;
        }
    }

    public void Close_Exit() { scene_anime.Play("close_exit"); Bexit = false; }

    void AnimationArray()
    {
        scene_anime_array = new List<string>();
        foreach (AnimationState state in scene_anime)
            scene_anime_array.Add(state.name);
    }

    public void shop_button(int i)
    {
        switch(i)
        {
            case 0:
                page_0.SetActive(true);
                page_1.SetActive(false);
                page_2.SetActive(false);
                break;
            case 1:
                page_0.SetActive(false);
                page_1.SetActive(true);
                page_2.SetActive(false);
                break;
            case 2:
                page_0.SetActive(false);
                page_1.SetActive(false);
                page_2.SetActive(true);
                break;
        }
    }
}
