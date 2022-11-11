using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void MoveMainHome()
    {
        SceneManager.LoadScene("MainHomeScene");
    }
    public void DashButtonTouchDown()
    {
       // Character_move._dash_button_pushed = true;
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
