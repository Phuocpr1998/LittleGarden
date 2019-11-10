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
    public GameObject TuiPhan;
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
        mapController = GameObject.FindGameObjectWithTag("map_controller");
        if (mapController != null)
        {
            //all items
            items = new List<GameObject>(mapController.GetComponent<MapController>().goodItems);
            items.AddRange(mapController.GetComponent<MapController>().badItems);
            //Item nhat duoc + length
            colectedItems = mapController.GetComponent<MapController>().ColectedItems;
            int i = 0;
            
            foreach(KeyValuePair<int, int> dictionaryEntry in colectedItems)
            {
                GameObject item = items[dictionaryEntry.Key];
                int soluong = dictionaryEntry.Value;
                if (!item.CompareTag("item_water") && !item.CompareTag("item_sun"))
                {
                    if (PhanBomKemChatLuong() == true)
                    {
                        if(item.GetComponent<ItemController>().Score < 0)
                        {
                            DiemPhanBon += item.GetComponent<ItemController>().Score*soluong;
                        }
                    }
                    else
                    {
                        if (item.GetComponent<ItemController>().Score > 0)
                        {
                            DiemPhanBon += item.GetComponent<ItemController>().Score* soluong;
                        }
                    }
                    slotItem[i++].GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
                }
                else if (item.CompareTag("item_water"))
                {
                }
                else if (item.CompareTag("item_sun"))
                {
                    float sum = GameObject.FindGameObjectWithTag("TTAnhSang").GetComponent<DrawWater>().PhanTramNuoc + soluong * 25;
                    if (sum >= 100)
                    {
                        GameObject.FindGameObjectWithTag("TTAnhSang").GetComponent<DrawWater>().SetPercent(100);
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("TTAnhSang").GetComponent<DrawWater>().SetPercent(sum);
                    }
                }
            }
            for(int z = i; z<9; z++)
            {
                slotItem[z].GetComponent<Image>().enabled = false;
            }
            TuiPhan.SetActive(true);
            Destroy(mapController);
        }
        else
        {
            TuiPhan.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    
    // Update is called once per frame
   

    public void HideMergeCanvas()
    {
        gameObject.SetActive(false);

    }
    public void ShowMergeCanvas()
    {
        gameObject.SetActive(true);
    }
}
