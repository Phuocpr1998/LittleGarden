using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject[] items;
    private Dictionary<int, int> colectedItems;

    public float timeCreateItem = 0.5f;

    private int targetsLength = 0;
    private int itemsLength = 0;
    public int maxRangeRandom = 100;

    Coroutine coroutineCreateItem;

    // Start is called before the first frame update
    void Start()
    {
        colectedItems = new Dictionary<int, int>();
        targetsLength = targets.Length;
        StartCreateItem(timeCreateItem);
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

    void CreateOneItem()
    {
        Vector3 posItem = randomPosition();
        GameObject item = Instantiate(randomItem());
        item.transform.position = posItem;
    }

    Vector3 randomPosition()
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
        return targets[id].transform.position;
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
}
