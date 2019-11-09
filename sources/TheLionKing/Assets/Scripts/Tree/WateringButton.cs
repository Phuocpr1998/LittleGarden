using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringButton : MonoBehaviour
{
    // Start is called before the first frame update
    TreeEnum te;
    void Start()
    {
        te = GameObject.FindGameObjectWithTag("TreeCanvas").GetComponent<TreeEnum>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            gameObject.transform.position = new Vector2(x, y);
        }

        if(Input.GetMouseButtonUp(0))
        {
            gameObject.SetActive(false);

        }

    }

 

    public void WateringClick()
    {
        te.isWatering = true;
        gameObject.SetActive(true);
    }
}
