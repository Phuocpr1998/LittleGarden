using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonPhan : MonoBehaviour
{
    Animator anim;
    public ParticleSystem.EmissionModule em;
    public GameObject DrawPhanBon;
    public GameMaster gm;
    float maxScaley = 0.5f;
    float minScaley = 0.02603692f;
    float sumScale = 0;

    float t;
    float maxUp;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        em = GameObject.FindGameObjectWithTag("PartBonPhan").GetComponent<ParticleSystem>().emission;
        gm = GameObject.FindGameObjectWithTag("MergeCanvas").GetComponent<GameMaster>();
        t = Time.time;
        maxUp = 0;
        sumScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (maxUp == 0 && gm.DiemPhanBon != 0)
        {
            maxUp = gm.DiemPhanBon;
        }

        if (maxUp < 0)
        {
            maxUp *= -1;
        }

        if(maxUp==0)
        {
            anim.SetBool("KhongCoPhan", true);
        }
        else
        {
            anim.SetBool("KhongCoPhan", false);

        }
        //Debug.Log(anim.GetBool("BatDauBon"));
        if (anim.GetBool("BatDauBon")==true)
        {

            em.enabled = true;
            if (DrawPhanBon.transform.localScale.y <= maxScaley && sumScale <= maxUp*maxScaley/100)
            {
                if(gm.DiemPhanBon<0 && DrawPhanBon.transform.localScale.y >= minScaley)
                {
                    float a = DrawPhanBon.transform.localScale.y;
                    Debug.Log(a);
                    sumScale += 0.02f * Time.deltaTime;
                    a -= 0.02f * Time.deltaTime;
                    DrawPhanBon.transform.localScale = new Vector2(DrawPhanBon.transform.localScale.x, a);
                }

                if (gm.DiemPhanBon > 0)
                {
                    float a = DrawPhanBon.transform.localScale.y;
                    sumScale += 0.02f * Time.deltaTime;
                    a += 0.02f * Time.deltaTime;
                    DrawPhanBon.transform.localScale = new Vector2(DrawPhanBon.transform.localScale.x, a);
                }

            }
            else
            {
                anim.SetBool("HetPhan", true);
                anim.SetBool("BatDauBon", false);
                em.enabled = false;
                sumScale = 0;
            }
        }
    }

    private void OnMouseDown()
    {
        if (anim.GetBool("KhongCoPhan") == true)
            return;
        anim.SetBool("BatDauBon", true);

        

    }
}
