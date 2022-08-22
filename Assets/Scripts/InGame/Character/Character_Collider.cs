using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Collider : MonoBehaviour
{
    public GameObject Problem_popup;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ABC")
        {
            Problem_popup.SetActive(true);
        }
        //
        if (other.gameObject.tag == "AnswerFootBoard1")
        {
            Debug.Log("1번 정답 발판 밟음");
        }
        else if (other.gameObject.tag == "AnswerFootBoard2")
        {
            Debug.Log("2번 정답 발판 밟음");
        }
        else if (other.gameObject.tag == "AnswerFootBoard3")
        {
            Debug.Log("3번 정답 발판 밟음");
        }
        else if (other.gameObject.tag == "AnswerFootBoard4")
        {
            Debug.Log("4번 정답 발판 밟음");
        }
    }
}
