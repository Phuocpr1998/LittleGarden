using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WateringButton : MonoBehaviour
{
    // Start is called before the first frame update
    TreeEnum te;
    TextMeshProUGUI phanTramWater;
    public GameObject ButtonTuoiCay;
    HidLeftBar HideLeft;

    void Start()
    {
        te = GameObject.FindGameObjectWithTag("TreeCanvas").GetComponent<TreeEnum>();
        gameObject.SetActive(false);
        phanTramWater = GameObject.FindGameObjectWithTag("TextWater").GetComponent<TextMeshProUGUI>();
        HideLeft = GameObject.FindGameObjectWithTag("LeftBar").GetComponent<HidLeftBar>();

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButton(0))
        {
            float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            gameObject.transform.position = new Vector3(x, y , -10.25f);
        }

        if(Input.GetMouseButtonUp(0) && te.isWatering==true)
        {
            phanTramWater.color = new Color(phanTramWater.color.r, phanTramWater.color.g, phanTramWater.color.b, 0);
           
            EndWearing();

        }

    }

    public void EndWearing()
    {
        te.isWatering = false;
        gameObject.SetActive(false);
    }

    public void WateringClick()
    {
        HideLeft.ButtonHideClick();
        te.isWatering = true;
        gameObject.SetActive(true);
    }
}
