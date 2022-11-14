using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGameManager : MonoBehaviour
{
    public GameObject darkgb;
    public Image darkimg;
    public GameObject death_reason_gb;
    public Text deathreason_text;

    public void ShowDeathReason(DeathReason reason)
    {
        death_reason_gb.SetActive(true);
        switch (reason)
        {
            case DeathReason.trap:
                deathreason_text.text = "함정에 의해 죽었습니다.";
                break;
            case DeathReason.mummy:
                deathreason_text.text = "미라에게 습격당했습니다.";
                break;
            case DeathReason.timemout:
                deathreason_text.text = "손전등 배터리가 다 떨어졌습니다.";
                break;
        }
    }
    public IEnumerator DarkfadeIn()
    {
        yield return new WaitForSeconds(2f);
        darkgb.SetActive(true);
        for (int i = 0; i < 33; i++)
        {
            darkimg.color = new Vector4(0, 0, 0, 0 + i * 0.03f);
            yield return new WaitForSeconds(0.03f);
        }
    }
}
