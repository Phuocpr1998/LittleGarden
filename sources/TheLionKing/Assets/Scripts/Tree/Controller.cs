using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject optionsScreen;
    public GameObject loadingScreen;
    public Slider loadingSlider;
    public CountItemManager SlItem;

    public GameObject DrawWater;
    public GameObject DrawLight;
    public GameObject DrawPhanBon;

    // Start is called before the first frame update
    void Start()
    {
        SlItem = GameObject.FindGameObjectWithTag("LeftBar").GetComponent<CountItemManager>();
        optionsScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeScenePlay()
    {
      
            PlayerPrefs.SetFloat("ScaleOfWater", DrawWater.transform.localScale.y);
        
       
            PlayerPrefs.SetFloat("ScaleOfLight", DrawLight.transform.localScale.y);
        
       
            PlayerPrefs.SetFloat("ScalePhanBon", DrawPhanBon.transform.localScale.y);
        
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

    public void OnOptionsButtonClick()
    {
        optionsScreen.SetActive(true);
    }
}
