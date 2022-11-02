using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] Image loading_bar;
    [SerializeField] TextMeshProUGUI tool_tip;
    [SerializeField] string[] tool_tip_array;
    static string scene_name;

    void Start()
    {
        Tool_Tip_Setting();
        StartCoroutine(Load_Scene_Process());
    }

    public static void Load_Scene(string scene)
    {
        scene_name = scene;
        SceneManager.LoadScene("LoadingScene");
    }

    void Tool_Tip_Setting()
    {
        int i = Random.Range(0, tool_tip_array.Length);
        tool_tip.text = tool_tip_array[i];
    }

    IEnumerator Load_Scene_Process()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(scene_name);
        op.allowSceneActivation = false;

        float timer = 0f;
        while(!op.isDone)
        {
            yield return null;

            if(op.progress < 0.9f)
            {
                loading_bar.fillAmount = op.progress;
            }
            else
            {
                //timer += Time.unscaledTime;
                timer += 0.005f;
                loading_bar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if(loading_bar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
