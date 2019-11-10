﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int slNuoc = 5;
    public int slAnhSang = 5;
    public TextMeshProUGUI textNuoc;
    public TextMeshProUGUI textAnhSang;
    void Start()
    {
        PlayerPrefs.SetInt("slNuoc",1);
    }

    // Update is called once per frame
    void Update()
    {
        slNuoc = PlayerPrefs.GetInt("slNuoc");
        
        textNuoc.text = slNuoc.ToString();
        textAnhSang.text = slAnhSang.ToString();
    }
}
