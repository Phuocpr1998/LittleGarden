using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public Slider loadingSlider;

    // Start is called before the first frame update
    void Start()
    {
        StartToTreeMap();
    }

    // Update is called once per frame
    void Update()
    {}

    public void StartToTreeMap()
    {
        StartCoroutine(LoadingTreeScene());
    }

    IEnumerator LoadingTreeScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("TreeScene");
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            loadingSlider.value = async.progress;
            if (async.progress >= 0.9f)
            {
                async.allowSceneActivation = true;
                Time.timeScale = 1f;
            }
            yield return null;
        }
    }
}
