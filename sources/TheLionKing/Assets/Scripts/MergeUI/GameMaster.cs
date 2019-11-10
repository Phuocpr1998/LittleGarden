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
    private List<GameObject> items;
    private Dictionary<int, int> colectedItems;

    public GameObject[] slotItem;
    public float DiemPhanBon=0;
    bool PhanBomKemChatLuong()
    {
        int i = 0;

        foreach (KeyValuePair<int, int> dictionaryEntry in colectedItems)
        {

            GameObject item = items[dictionaryEntry.Key];
            if (item.GetComponent<ItemController>().Score < 0)
                return true;
            int sum = dictionaryEntry.Value;
            if (!item.CompareTag("item_water") && !item.CompareTag("item_sun"))
            {
                slotItem[i++].GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            }
        }
        return false;
    }
    void Start()
    {
        gameObject.SetActive(true);
        ReturnHomeFlower.SetActive(false);
        mapController = GameObject.FindGameObjectWithTag("map_controller");
        if (mapController != null)
        {
            slotItem = GameObject.FindGameObjectsWithTag("SlotItem");
            //all items
            items = new List<GameObject>(mapController.GetComponent<MapController>().goodItems);
            items.AddRange(mapController.GetComponent<MapController>().badItems);
            //Item nhat duoc + length
            colectedItems = mapController.GetComponent<MapController>().ColectedItems;
            int i = 0;
            
            foreach(KeyValuePair<int, int> dictionaryEntry in colectedItems)
            {
                GameObject item = items[dictionaryEntry.Key];
                int sum = dictionaryEntry.Value;
                if (!item.CompareTag("item_water") && !item.CompareTag("item_sun"))
                {
                    Debug.Log(item.GetComponent<ItemController>().Score);
                    if (PhanBomKemChatLuong() == true)
                    {
                        if(item.GetComponent<ItemController>().Score < 0)
                        {
                            DiemPhanBon += item.GetComponent<ItemController>().Score;
                        }
                    }
                    else
                    {
                        if (item.GetComponent<ItemController>().Score > 0)
                        {
                            DiemPhanBon += item.GetComponent<ItemController>().Score;
                        }
                    }
                    slotItem[i++].GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
                }
                Debug.Log(item.GetComponent<ItemController>().Score);

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
