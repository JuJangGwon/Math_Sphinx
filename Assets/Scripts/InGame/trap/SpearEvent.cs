using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearEvent : MonoBehaviour
{
    public GameObject spear_collider;
    public void unactive()
    {
        spear_collider.SetActive(false);
        gameObject.SetActive(false);
    }
}
