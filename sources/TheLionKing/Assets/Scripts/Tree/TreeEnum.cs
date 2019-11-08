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
    float maxScalex;
    float minScalex = -6;
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        maxScalex = statusWater.transform.localScale.x;
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
        

    }
}
