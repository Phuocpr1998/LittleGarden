using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSupport : MonoBehaviour
{
    // Start is called before the first frame update
    TreeEnum te;

    public int PhanBon;
    public int Nuoc;
    public int AnhSang;

    public int maxNuoc = 25;
    //1% = 0.005
    // 25 % = 0.125
    void Start()
    {
        te = GameObject.FindGameObjectWithTag("TreeCanvas").GetComponent<TreeEnum>();
    }

    // Update is called once per frame
    void Update()
    {
        if(te.isWatering==true)
        {

        }
    }
}
