using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class isItemMove : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    GameMaster gm;
    public GameObject PhanBon;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("MergeCanvas").GetComponent<GameMaster>();

    }

    private void Update()
    {
        if(gm.CountItem==0)
        {
            gameObject.GetComponent<Image>().sprite = PhanBon.GetComponent<SpriteRenderer>().sprite;

        }
    }

    public void OnMouseClickButton()
    {
        gm.isMerge = true;
    }
}
