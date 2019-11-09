using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWater : MonoBehaviour
{
    // Start is called before the first frame update
    float maxScaley = 0.461692f;
    float minScaley = 0.02615763f;
    public TreeEnum te;
    void Start()
    {
        te = GameObject.FindGameObjectWithTag("TreeCanvas").GetComponent<TreeEnum>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.localScale.y>minScaley)
        {
            float y = gameObject.transform.localScale.y;
            y -= Time.deltaTime / 30;
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x, y);
            if(gameObject.CompareTag("TTWater"))
            {
                if (te.isWatering == true)
                {
                    if (gameObject.transform.localScale.y < maxScaley)
                    {
                        float a = gameObject.transform.localScale.y;
                        a += Time.deltaTime / 20;
                        gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x, a);
                    }
                }
            }

        }
    }
}
