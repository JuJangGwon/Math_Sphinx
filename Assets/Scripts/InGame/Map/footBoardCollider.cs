using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footBoardCollider : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite pushed_sprite;
    public Sprite unpushed_sprite;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            sr.sprite = pushed_sprite;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            sr.sprite = unpushed_sprite;
        }
    }
}
