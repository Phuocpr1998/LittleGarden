using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DrawWater : MonoBehaviour
{
    // Start is called before the first frame update
    float maxScaley = 0.5f;
    float minScaley = 0.02609334f;
    public TreeEnum te;
    float sumScale = 0;
    WateringButton wt;
    public TextMeshProUGUI phanTramWater;
    public GameObject ButtonTuoiCay;
    public CountItemManager countItem;

  

    void Start()
    {
        ButtonTuoiCay = GameObject.FindGameObjectWithTag("ButtonTuoiCay");
        te = GameObject.FindGameObjectWithTag("TreeCanvas").GetComponent<TreeEnum>();
        phanTramWater = GameObject.FindGameObjectWithTag("TextWater").GetComponent<TextMeshProUGUI>();
        countItem = GameObject.FindGameObjectWithTag("LeftBar").GetComponent<CountItemManager>();
    }

    // Update is called once per frame
    void Update()
    {

        //Set Save Scale

        //Phan tram cua nuoc 
        phanTramWater.text = Mathf.Floor((gameObject.transform.localScale.y*100/50)*100).ToString()+"%";
        
        if (gameObject.transform.localScale.y>minScaley)
        {
            if(gameObject.CompareTag("TTWater"))
            {
                if (te.isWatering == true)
                {
                    ButtonTuoiCay.GetComponent<Button>().enabled = false;

                    wt = GameObject.FindGameObjectWithTag("TuoiCay").GetComponent<WateringButton>();

                    if (gameObject.transform.localScale.y < maxScaley && sumScale<0.125f)
                    {
                        float a = gameObject.transform.localScale.y;
                        sumScale += 0.01f*Time.deltaTime;
                        a += 0.01f * Time.deltaTime;
                        gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x, a);

                         phanTramWater.color = new Color(phanTramWater.color.r, phanTramWater.color.g, phanTramWater.color.b, 255);
                    }
                    else
                    {

                        countItem.slNuoc -= 1;
                        PlayerPrefs.SetInt("slNuoc", countItem.slNuoc);
                        phanTramWater.color = new Color(phanTramWater.color.r, phanTramWater.color.g, phanTramWater.color.b, 0);
                        wt.EndWearing();
                        sumScale = 0;

                    }
                }
                else
                {
                    //Khi không tưới thì  giảm 
                    ButtonTuoiCay.GetComponent<Button>().enabled = true;
                    float y = gameObject.transform.localScale.y;
                    y -= 0.005f * Time.deltaTime;
                    gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x, y);
                }
            }

        }
    }
}
