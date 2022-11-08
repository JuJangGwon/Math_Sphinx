using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIOEvents : MonoBehaviour
{
    public void Exit_Camel_Game()
    {
        SceneManager.LoadScene("InGameScene");
    }
}
