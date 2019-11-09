using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEnum : MonoBehaviour
{
    // Start is called before the first frame update

     //1 is normal , 2 is Wither , 3 is Death
    public int EnumTree;
    public Sprite TreeNormal;
    public Sprite TreeWither;
    public Sprite TreeDeath;
    SpriteRenderer sr;
    public GameObject statusWater;
    float maxScaleWatery;
    float minScaleWatery = 0;
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        maxScaleWatery = statusWater.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        switch(EnumTree)
        {
            case 1:
               sr.sprite = TreeNormal;
               break;
            case 2:
                sr.sprite = TreeWither;
                break;
            case 3:
                sr.sprite = TreeDeath;
                break;
        }

        //Update Enum of Tree
       // DrawWater();
    }

    void DrawWater()
    {
        if(statusWater.transform.localScale.y>minScaleWatery)
        {
            float a = statusWater.transform.localScale.y;
            a -= Time.deltaTime/3600;
            statusWater.transform.localScale = new Vector3(statusWater.transform.localScale.x, a, statusWater.transform.localScale.z);
        }
    }
}
