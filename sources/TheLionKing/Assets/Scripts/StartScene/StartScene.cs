using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public Slider loadingSlider;
    int secondLoading;

    // Start is called before the first frame update
    void Start()
    {
        secondLoading = 5;
        loadingSlider.maxValue = secondLoading;
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
        int second = 0;
        while (true)
        {
            loadingSlider.value = second++;
            if (second >= secondLoading)
            {
                SceneManager.LoadScene("TreeScene");
                yield break;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
