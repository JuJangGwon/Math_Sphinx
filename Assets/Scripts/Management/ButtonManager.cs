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
