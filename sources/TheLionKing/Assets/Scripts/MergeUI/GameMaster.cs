using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isMerge = false;
    public int CountItem = 9;
    public GameObject ReturnHomeFlower;

    private GameObject mapController;
    private GameObject[] items;
    private Dictionary<int, int> colectedItems;

    public GameObject[] slotItem;

    void Start()
    {
        gameObject.SetActive(true);
        ReturnHomeFlower.SetActive(false);
        mapController = GameObject.FindGameObjectWithTag("map_controller");
        if (mapController != null)
        {
            slotItem = GameObject.FindGameObjectsWithTag("SlotItem");
            //all items
            items = mapController.GetComponent<MapController>().items;
            //Item nhat duoc + length
            colectedItems = mapController.GetComponent<MapController>().ColectedItems;
            int i = 0;
            foreach(KeyValuePair<int, int> dictionaryEntry in colectedItems)
            {
                GameObject item = items[dictionaryEntry.Key];
                int sum = dictionaryEntry.Value;
                slotItem[i++].GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
                //item.GetComponent<SpriteRenderer>().sprite;
            }
            for(int z = i; z<9; z++)
            {
                slotItem[z].GetComponent<Image>().enabled = false;
            }
            Destroy(mapController);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if(CountItem==0)
        {
            ReturnHomeFlower.SetActive(true);
        }
    }

    public void HideMergeCanvas()
    {
        gameObject.SetActive(false);

    }
    public void ShowMergeCanvas()
    {
        gameObject.SetActive(true);
    }
}
