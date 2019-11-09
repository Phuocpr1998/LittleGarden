using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWater : MonoBehaviour
{
    // Start is called before the first frame update
    float maxScaley = 0.461692f;
    float minScaley = 0.02615763f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.localScale.y>minScaley)
        {
            float a = gameObject.transform.localScale.y;
            a -= Time.deltaTime/1500;
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x,a);
        }
    }
}
