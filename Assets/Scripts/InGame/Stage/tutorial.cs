using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject ingame_parent;
    public GameObject Character;
    public GameObject Character_prefebs;

    public void TutorialSettings()
    {
        Character = Instantiate(Character_prefebs, ingame_parent.transform);
        Character.transform.localPosition = new Vector3(0, 0, 0);

    }
}
