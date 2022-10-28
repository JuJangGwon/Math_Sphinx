using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] Image loading_bar;
    static string scene_name;

    void Start()
    {
        StartCoroutine(Load_Scene_Process());
    }

    public static void Load_Scene(string scene)
    {
        scene_name = scene;
        SceneManager.LoadScene("LoadingScene");
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
