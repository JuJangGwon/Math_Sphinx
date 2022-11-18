using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject dark_fade;
    
    public void MoveMainHome()
    {
        dark_fade.SetActive(true);
        Invoke("movescene", 2f);
    }
    public void movescene()
    {
        SceneManager.LoadScene("MainHomeScene");
    }
    public void DashButtonTouchUp()
    {
    //    Character_move._dash_button_pushed = false;
    }
    public void ClearGamePopup(int num)
    {
        switch(num)
        {
            case 1:
                PlayerPrefs.SetInt("Mode", 2);
                PlayerPrefs.SetInt("pos", 1);
                PlayerPrefs.SetInt("newgame", 1);
                PlayerPrefs.SetFloat("max_handlight", 115f);
                PlayerPrefs.SetFloat("now_handlgiht", 115f);
                PlayerPrefs.SetInt("is_key1", System.Convert.ToInt16(false));
                PlayerPrefs.SetInt("is_key2", System.Convert.ToInt16(false));
                SceneManager.LoadScene("InGameScene");
                break;
            case 2:
                SceneManager.LoadScene("MainHomeScene");
                break;
        }
    }
    public void MathProblemSolveButton(int num)
    {
        switch(num)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }
}
