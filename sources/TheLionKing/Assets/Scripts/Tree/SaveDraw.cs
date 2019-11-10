using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDraw : MonoBehaviour
{
    public float ScaleOfWater;
    public float ScaleOfLight;
    public float ScalePhanBon;

    public GameObject DrawWater;
    public GameObject DrawLight;
    public GameObject DrawPhanBon;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("ScaleOfWater"))
            DrawWater.transform.localScale = new Vector2(DrawWater.transform.localScale.x, PlayerPrefs.GetFloat("ScaleOfWater"));
        else
            DrawWater.transform.localScale = new Vector2(DrawWater.transform.localScale.x, 0.5f);

        if(PlayerPrefs.HasKey("ScaleOfLight"))
            DrawLight.transform.localScale = new Vector2(DrawWater.transform.localScale.x, PlayerPrefs.GetFloat("ScaleOfLight"));
        else
            DrawLight.transform.localScale = new Vector2(DrawWater.transform.localScale.x, 0.5f);

        if(PlayerPrefs.HasKey("ScalePhanBon"))
            DrawPhanBon.transform.localScale = new Vector2(DrawWater.transform.localScale.x, PlayerPrefs.GetFloat("ScalePhanBon"));
        else
             DrawPhanBon.transform.localScale = new Vector2(DrawWater.transform.localScale.x, 150);


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerPrefs.HasKey("ScaleOfWater"));
        //set scale

        ScaleOfWater = PlayerPrefs.GetFloat("ScaleOfWater");
        
        ScaleOfLight = PlayerPrefs.GetFloat("ScaleOfLight");

        ScalePhanBon = PlayerPrefs.GetFloat("ScalePhanBon");
    }
}
