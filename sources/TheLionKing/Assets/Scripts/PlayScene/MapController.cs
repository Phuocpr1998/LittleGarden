using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public UnityEngine.UI.VerticalLayoutGroup listItemsColected;
    public UnityEngine.UI.Text textTimer;
    public GameObject endMapUI;
    public GameObject loadingScreen;

    public GameObject[] targets;
    public GameObject[] lineTargets;
    public GameObject[] items;
    public int maxRangeRandom = 100;
    public int mapDuration = 30; // second

    public float timeCreateItem = 0.5f;

    private int targetsLength = 0;
    private int itemsLength = 0;
    private Dictionary<int, int> colectedItems;

    private Coroutine coroutineCreateItem;
    private int duration;

    // Start is called before the first frame update
    void Start()
    {
        endMapUI.SetActive(false);
        duration = 0;
        colectedItems = new Dictionary<int, int>();
        targetsLength = targets.Length;

        StartCreateItem(timeCreateItem);
        StartCoroutine(MapDurationTimerCountdown());
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
        GameObject item = Instantiate(randomItem());
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
        if (nid > maxRangeRandom / 2)
        {
            id = 1;
        }
        items[id].GetComponent<ItemController>().indexType = id;
        return items[id];
    }

    public void AddColectedItem(int itemType)
    {
        if (colectedItems.ContainsKey(itemType))
        {
            colectedItems[itemType] += 1;
        } else
        {
            colectedItems.Add(itemType, 1);
        }
    }
    
    void showItemColected()
    {
        RectTransform parent = listItemsColected.GetComponent<RectTransform>();
        RectTransform parentOfParent = listItemsColected.GetComponent<RectTransform>().parent.parent.GetComponent<RectTransform>();
        foreach (KeyValuePair<int, int> entry in colectedItems)
        {
            GameObject g = new GameObject(entry.Key.ToString());
            UnityEngine.UI.Text t = g.AddComponent<UnityEngine.UI.Text>();
            g.transform.SetParent(parent);
            g.AddComponent<UnityEngine.UI.LayoutElement>().flexibleHeight = 30;
            t.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            t.text = entry.Value.ToString();
            t.alignment = TextAnchor.MiddleCenter;
            t.rectTransform.sizeDelta = new Vector2(parentOfParent.sizeDelta.x, 30);
        }
    }

    void EndMap()
    {
        Time.timeScale = 0;
        StopCreateItem();
        showItemColected();
        endMapUI.SetActive(true);
    }

    public void StartToTreeMap()
    {
        StartCoroutine(LoadingTreeScene());
    }

    IEnumerator LoadingTreeScene()
    {
        // loadingScreen.SetActive(true);
        AsyncOperation async = SceneManager.LoadSceneAsync("TreeScene");
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            if (async.progress >= 0.9f)
            {
                if (Input.anyKeyDown)
                {
                    async.allowSceneActivation = true;
                    Time.timeScale = 1f;
                }
            }
            yield return null;
        }
    }

}
