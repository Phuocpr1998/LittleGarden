using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringButton : MonoBehaviour
{
    // Start is called before the first frame update
    TreeEnum te;
    void Start()
    {
        te = GameObject.FindGameObjectWithTag("TreeCanvas").GetComponent<TreeEnum>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WateringClick()
    {
        te.isWatering = true;
        gameObject.SetActive(true);
    }
}
