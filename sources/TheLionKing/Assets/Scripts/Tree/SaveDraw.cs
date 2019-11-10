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
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerPrefs.HasKey("ScaleOfWater"));
        //set scale

        ScaleOfWater = PlayerPrefs.GetFloat("ScaleOfWater");
        //DrawWater.transform.localScale = new Vector2(DrawWater.transform.localScale.x, ScaleOfWater);
        Debug.Log(ScaleOfWater);
        //float ScaleLight = PlayerPrefs.GetFloat("ScaleOfLight");
        //DrawWater.transform.localScale = new Vector2(DrawWater.transform.localScale.x, ScaleLight);

        //float Scaleypb = PlayerPrefs.GetFloat("ScalePhanBon");
        //DrawWater.transform.localScale = new Vector2(DrawWater.transform.localScale.x, Scaleypb);
    }
}
