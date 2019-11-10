using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public VerticalLayoutGroup listItemsColected;
    public Text textTimer;
    public GameObject endMapUI;
    public GameObject loadingScreen;
    public Slider loadingSlider;

    public Font fontText;

    public GameObject[] targets;
    public GameObject[] lineTargets;
    public GameObject[] goodItems;
    public GameObject[] badItems;
    public int maxRangeRandom = 100;
    public int mapDuration = 30; // second

    public float timeCreateItem = 0.5f;

    private int targetsLength = 0;
    private int goodItemsLength = 0;
    private int badItemsLength = 0;
    private Dictionary<int, int> colectedItems;

    private Coroutine coroutineCreateItem;
    private int duration;

    public Dictionary<int, int> ColectedItems { get => colectedItems; set => colectedItems = value; }

    // Start is called before the first frame update
    void Start()
    {
        endMapUI.SetActive(false);
        loadingScreen.SetActive(false);
        duration = 0;
        colectedItems = new Dictionary<int, int>();

        targetsLength = targets.Length;
        goodItemsLength = goodItems.Length;
        badItemsLength = badItems.Length;

        StartCreateItem(timeCreateItem);
        StartCoroutine(MapDurationTimerCountdown());

        // set score for item
        for (int i = 0; i < goodItemsLength; i++)
        {
            goodItems[i].GetComponent<ItemController>().Score = (i + 1) * 2;
        }

        for (int i = 0; i < badItemsLength; i++)
        {
            badItems[i].GetComponent<ItemController>().Score = (i + 1) * (-3);
        }

    }

    // Update is called once per frame
    void Update()
    {}

    void StartCreateItem(float seconds)
    {
        coroutineCreateItem = StartCoroutine(CreateItems(seconds));
    }

    void StopCreateItem()
    {
        if (coroutineCreateItem != null) {
            StopCoroutine(coroutineCreateItem);
        }
    }

    IEnumerator CreateItems(float seconds)
    {
        while (true)
        {
            CreateOneItem();
            yield return new WaitForSeconds(seconds);
        }
    }

    IEnumerator MapDurationTimerCountdown()
    {
        while (true)
        {
            duration += 1;
            textTimer.text = duration.ToString();
            if (duration >= mapDuration)
            {
                EndMap();
                yield break;
            }
            else
            {
                yield return new WaitForSeconds(1);
            }
        }
    }

    void CreateOneItem()
    {
        int targetIndex = randomTargetIndex();
        Vector3 posItem = targets[targetIndex].transform.position;
        GameObject itemParent = randomItem();
        GameObject item = Instantiate(itemParent);
        item.GetComponent<ItemController>().vecDrirection = lineTargets[targetIndex].transform.position - posItem;
        item.transform.position = posItem;
    }

    int randomTargetIndex()
    {
        int nid = Random.Range(1, maxRangeRandom);
        int id = 0;
        if (nid <= (2* maxRangeRandom) /3 && nid > maxRangeRandom / 3)
        {
            id = 1;
        }
        else if (nid > (2 * maxRangeRandom) / 3)
        {
            id = 2;
        }
        return id;
    }

    GameObject randomItem()
    {
        int nid = Random.Range(1, maxRangeRandom);
        int id = 0;
        int itemsLength = goodItemsLength + badItemsLength;
        for (id = 0; id < itemsLength - 1; id ++)
        {
            if (id * (maxRangeRandom / itemsLength) <= nid && (id + 1) * (maxRangeRandom / itemsLength) > nid)
                break;
        }
        if (id < goodItemsLength)
        {
            goodItems[id].GetComponent<ItemController>().indexType = id;
            return goodItems[id];
        }
        else
        {
            badItems[id - goodItemsLength].GetComponent<ItemController>().indexType = id;
            return badItems[id - goodItemsLength];
        }
    }

    public void AddColectedItem(int indexType)
    {
        if (colectedItems.ContainsKey(indexType))
        {
            colectedItems[indexType] += 1;
        } else
        {
            colectedItems.Add(indexType, 1);
        }
    }
    
    void showItemColected()
    {
        RectTransform parent = listItemsColected.GetComponent<RectTransform>();
        RectTransform parentOfParent = listItemsColected.GetComponent<RectTransform>().parent.parent.GetComponent<RectTransform>();
        foreach (KeyValuePair<int, int> entry in colectedItems)
        {
            GameObject p = new GameObject(entry.Key.ToString());
            p.AddComponent<HorizontalLayoutGroup>().childScaleWidth = true;
            p.GetComponent<HorizontalLayoutGroup>().childScaleHeight = false;
            p.GetComponent<HorizontalLayoutGroup>().childControlWidth = false;
            p.transform.SetParent(parent);
            ((RectTransform)p.transform).sizeDelta = new Vector2(255, 50);
            p.transform.localScale = new Vector3(1, 2.5f, 1);
            p.AddComponent<LayoutElement>().flexibleHeight = 30;
            p.GetComponent<LayoutElement>().flexibleWidth = 50;

            GameObject c1 = new GameObject("image");
            c1.transform.parent = p.transform;
            Image image = c1.AddComponent<Image>();
            image.rectTransform.localScale = new Vector3(0.2f, 0.2f, 0);
            if (entry.Key < goodItemsLength)
            {
                image.sprite = goodItems[entry.Key].GetComponent<SpriteRenderer>().sprite;
            } else
            {
                image.sprite = badItems[entry.Key - goodItemsLength].GetComponent<SpriteRenderer>().sprite;
            }
            image.rectTransform.sizeDelta = new Vector2(255, 30);
            image.gameObject.AddComponent<LayoutElement>().flexibleHeight = 30;
            image.gameObject.GetComponent<LayoutElement>().flexibleWidth = 30;

            GameObject c2 = new GameObject("X");
            c2.transform.parent = p.transform;
            Text text2 = c2.AddComponent<Text>();
            text2.font = fontText;
            text2.text = "X";
            text2.alignment = TextAnchor.MiddleCenter;
            text2.rectTransform.sizeDelta = new Vector2(50, 30);
            text2.gameObject.AddComponent<LayoutElement>().flexibleHeight = 30;
            text2.gameObject.GetComponent<LayoutElement>().flexibleWidth = 30;

            GameObject c3 = new GameObject("text");
            c3.transform.parent = p.transform;
            Text text3 = c3.AddComponent<Text>();
            text3.font = fontText;
            text3.text = entry.Value.ToString();
            text3.alignment = TextAnchor.MiddleCenter;
            text3.rectTransform.sizeDelta = new Vector2(50, 30);
            text3.gameObject.AddComponent<LayoutElement>().flexibleHeight = 30;
            text3.gameObject.GetComponent<LayoutElement>().flexibleWidth = 30;
        }
    }

    void EndMap()
    {
        Time.timeScale = 0;
        StopCreateItem();
        showItemColected();
        DontDestroyOnLoad(gameObject);
        endMapUI.SetActive(true);
    }

    public void StartToTreeMap()
    {
        StartCoroutine(LoadingTreeScene());
    }

    IEnumerator LoadingTreeScene()
    {
        loadingScreen.SetActive(true);
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
