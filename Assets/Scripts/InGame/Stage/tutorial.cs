using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Tutorial_stage
{
    none,
    tutorial1,
    tutorial2,
    tutorial3,
    tutorial4,
    tutorial5,
    tutorial6,
    tutorial7,
    tutorial8,
    tutorial9,
    tutorial10,
    tutorial11

}

public class tutorial : MonoBehaviour
{
    public Tutorial_stage now_tutorial_stage = Tutorial_stage.none;
    public InGameManeger inGameManeger_cs;
    public GameObject ingame_parent;
   // public GameObject Character;
    public GameObject Character_prefebs;

    public GameObject treasure_box;

    public Image key;
    public Sprite new_key;

    public void TutorialSettings()
    {

        inGameManeger_cs.character = Instantiate(Character_prefebs, ingame_parent.transform);
        inGameManeger_cs.character.transform.localPosition = new Vector3(6, 11, 1);

        inGameManeger_cs.character.GetComponent<Character_Collider>().handlightsystem_cs = inGameManeger_cs.handlightsystem_cs;
        inGameManeger_cs.character.GetComponent<Character_Collider>().findAnswerWay_cs = inGameManeger_cs.findanswerway_cs;
        //    inGameManeger_cs.character.GetComponent<Character_Collider>().stage1_cs = inGameManeger_cs.stage1_cs;
        inGameManeger_cs.character.GetComponent<Character_Collider>().mapcreate_cs = inGameManeger_cs.mapcreater_cs;
        // inGameManeger_cs.character.GetComponent<Character_Collider>().loadpirordata_cs = inGameManeger_cs.Loadpirordata_cs;
        //  inGameManeger_cs.character.GetComponentInChildren<Character_trigger>()._stage1cs = inGameManeger_cs.stage1_cs;
        inGameManeger_cs.character_animator_cs = inGameManeger_cs.character.GetComponent<Character_Animator>();
        inGameManeger_cs.character_move_cs = inGameManeger_cs.character.GetComponent<Character_move>();
        inGameManeger_cs.camera_move_cs.character = inGameManeger_cs.character;
        inGameManeger_cs.JoystickScripts_cs.cm = inGameManeger_cs.character_move_cs;
        inGameManeger_cs.texttypingeffect_cs.character_move_cs = inGameManeger_cs.character_move_cs;

    }
    public void ChangeKey()
    {
        key.sprite = new_key;
    }
    public void ChangeBox()
    {
        treasure_box.SetActive(true);
    }
}