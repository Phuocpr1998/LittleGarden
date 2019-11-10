using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMoveToCenter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Center;
    Animator anim;
    GameMaster gm;
    Vector2 Direc;
    
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("MergeCanvas").GetComponent<GameMaster>();
        Center = GameObject.FindGameObjectWithTag("Center");
        anim = GameObject.FindGameObjectWithTag("Center").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (gm.isMerge==true)
        {
            Direc = (Vector2)Center.transform.position - (Vector2)gameObject.transform.position;
            gameObject.transform.position = ((Vector2)gameObject.transform.position + Direc * 5 * Time.deltaTime);
            if (Direc.magnitude < 0.02f)
            {
                gm.CountItem--;
            }
        }

        if(gm.CountItem==0)
        {
            Destroy(gameObject);
            gm.isMerge = false;
            anim.SetBool("isRing", false);
        }
    }



}
