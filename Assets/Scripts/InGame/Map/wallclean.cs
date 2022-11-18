using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class wallclean : MonoBehaviour
{
    public GameObject wall;

    public SpriteRenderer sp;
    Color color;
    private void Awake()
    {
        color = sp.color;
    }
}
