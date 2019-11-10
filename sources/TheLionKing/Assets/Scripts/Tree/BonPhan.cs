using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonPhan : MonoBehaviour
{
    Animator anim;
    public ParticleSystem.EmissionModule em;
    public GameObject DrawPhanBon;

    float maxScaley = 0.5f;
    float minScaley = 0.02609334f;
    float sumScale = 0;

    float t;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        em = GameObject.FindGameObjectWithTag("PartBonPhan").GetComponent<ParticleSystem>().emission;
        t = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetBool("BatDauBon")==true && Time.time-t >1)
        {
            em.enabled = true;
            if (DrawPhanBon.transform.localScale.y < maxScaley && sumScale < 0.125f)
            {
                float a = DrawPhanBon.transform.localScale.y;
                sumScale += 0.01f * Time.deltaTime;
                a += 0.01f * Time.deltaTime;
                DrawPhanBon.transform.localScale = new Vector2(DrawPhanBon.transform.localScale.x, a);

                //phanTramWater.color = new Color(phanTramWater.color.r, phanTramWater.color.g, phanTramWater.color.b, 255);
            }
            else
            {

                sumScale = 0;
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        anim.SetBool("BatDauBon", true);
    }
}
