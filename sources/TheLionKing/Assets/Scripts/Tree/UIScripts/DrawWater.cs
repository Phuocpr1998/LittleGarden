using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DrawWater : MonoBehaviour
{
    // Start is called before the first frame update
    float maxScaley = 0.5f;
    float minScaley = 0.02615763f;
    public TreeEnum te;
    float sumScale = 0;
    WateringButton wt;
    public TextMeshProUGUI phanTramWater;
    void Start()
    {
        te = GameObject.FindGameObjectWithTag("TreeCanvas").GetComponent<TreeEnum>();
        phanTramWater = GameObject.FindGameObjectWithTag("TextWater").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.localScale.y>minScaley)
        {
            float y = gameObject.transform.localScale.y;
            y -= 0.005f * Time.deltaTime;
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x, y);
            if(gameObject.CompareTag("TTWater"))
            {
                if (te.isWatering == true)
                {
                    wt = GameObject.FindGameObjectWithTag("TuoiCay").GetComponent<WateringButton>();

                    if (gameObject.transform.localScale.y < maxScaley && sumScale<0.125f)
                    {
                        float a = gameObject.transform.localScale.y;
                        sumScale += 0.01f*Time.deltaTime;
                        Debug.Log(sumScale);
                        a += 0.01f * Time.deltaTime;
                        gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x, a);

                         phanTramWater.color = new Color(phanTramWater.color.r, phanTramWater.color.g, phanTramWater.color.b, 255);
                       // phanTramWater.color = new Color(255, 255,255, 255);

                    }
                    else
                    {
                        wt.EndWearing();
                        sumScale = 0;

                    }
                }
            }

        }
    }
}
