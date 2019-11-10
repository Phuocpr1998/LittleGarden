using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingSlider;
    public CountItemManager SlItem;

    // Start is called before the first frame update
    void Start()
    {
        SlItem = GameObject.FindGameObjectWithTag("LeftBar").GetComponent<CountItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeScenePlay()
    {
        PlayerPrefs.SetInt("slNuoc", SlItem.slNuoc);
        StartToTreeMap();
    }


    public void StartToTreeMap()
    {
        StartCoroutine(LoadingTreeScene());
    }

    IEnumerator LoadingTreeScene()
    {
        loadingScreen.SetActive(true);
        AsyncOperation async = SceneManager.LoadSceneAsync("PlayScene");
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
