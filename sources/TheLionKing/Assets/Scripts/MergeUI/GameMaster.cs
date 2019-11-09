﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isMerge = false;
    public int CountItem = 9;
    public GameObject ReturnHomeFlower;

    private GameObject mapController;
    private GameObject[] items;
    private Dictionary<int, int> colectedItems;

    void Start()
    {
        gameObject.SetActive(true);
        ReturnHomeFlower.SetActive(false);
        mapController = GameObject.FindGameObjectWithTag("map_controller");
        if (mapController != null)
        {
            items = mapController.GetComponent<MapController>().items;
            colectedItems = mapController.GetComponent<MapController>().ColectedItems;
            Destroy(mapController);
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
