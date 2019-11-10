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
        DrawWater.transform.localScale = new Vector2(DrawWater.transform.localScale.x, PlayerPrefs.GetFloat("ScaleOfWater"));
        DrawLight.transform.localScale = new Vector2(DrawWater.transform.localScale.x, PlayerPrefs.GetFloat("ScaleOfLight"));
        DrawPhanBon.transform.localScale = new Vector2(DrawWater.transform.localScale.x, PlayerPrefs.GetFloat("ScalePhanBon"));


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
