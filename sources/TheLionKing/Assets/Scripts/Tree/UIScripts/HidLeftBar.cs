using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidLeftBar : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isHide = false;
    GameObject HideButton;
    public TreeEnum te;
    int InOut = 0;
    float minHide = -62.5f;
    float maxHide = -43f;
    void Start()
    {
        HideButton = GameObject.FindGameObjectWithTag("TreeHideButton");
        te = GameObject.FindGameObjectWithTag("TreeCanvas").GetComponent<TreeEnum>();

    }

    // Update is called once per frame
    void Update()
    {

        if (isHide==true)
        {
            if(gameObject.transform.localPosition.x>minHide && InOut%2==0)
            {
                float a = gameObject.transform.localPosition.x;
                a -= 2f;
                gameObject.transform.localPosition = new Vector2(a, gameObject.transform.localPosition.y);
            }
            else if(gameObject.transform.localPosition.x < maxHide && InOut % 2 != 0)
            {
                float a = gameObject.transform.localPosition.x;
                a += 2f;
                gameObject.transform.localPosition = new Vector2(a, gameObject.transform.localPosition.y);
            }
            else
            {
                isHide = false;
            }
        }
    }

    public void ButtonHideClick()
    {
        float a = HideButton.transform.localScale.x;
        a *= -1;
        HideButton.transform.localScale = new Vector2(a, HideButton.transform.localScale.y);
        InOut++;
        isHide = true;
    }



}
