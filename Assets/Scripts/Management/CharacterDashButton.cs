using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDashButton : MonoBehaviour
{
    public static bool Dashbutton_onoff = false;

    void Start()
    {
        Dashbutton_onoff = false;
    }

    public void OnButton()
    {
        Dashbutton_onoff = true;
    }
    public void OffButton()
    {
        Dashbutton_onoff = false;
    }
}
