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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            color.a = 0.7f;
            sp.color = color;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            color.a = 1f;
            sp.color = color;
        }
    }
}
