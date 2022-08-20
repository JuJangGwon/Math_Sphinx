using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Collider : MonoBehaviour
{
    public GameObject Problem_popup;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ABC")
        {
            print("###");
            Problem_popup.SetActive(true);
        }
    }
}
