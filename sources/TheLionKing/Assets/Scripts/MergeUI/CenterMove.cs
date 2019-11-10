using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMove : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    public GameMaster gm;
    public GameObject ObjGameMaster;
    public GameObject VididiChuyen;

    public GameObject DrawWater;
    public GameObject DrawLight;
    public GameObject DrawPhanBon;

    SaveDraw Save;

    Vector2 Direc;

    // Update is called once per frame
    private void Start()
    {
        Direc = new Vector2(50, 50);
        gm = GameObject.FindGameObjectWithTag("MergeCanvas").GetComponent<GameMaster>();
        ObjGameMaster = GameObject.FindGameObjectWithTag("MergeCanvas");
        Save = GameObject.FindGameObjectWithTag("ManagerDraw").GetComponent<SaveDraw>();
    }
    void Update()
    {
        if (gm.CountItem == 0 && time == 0)
        {
            time = Time.time;
        }

        if(Time.time - time>=1 && gm.CountItem==0)
        {
            Direc = (Vector2)VididiChuyen.transform.position - (Vector2)gameObject.transform.position;
            gameObject.transform.position = ((Vector2)gameObject.transform.position + Direc * 3 * Time.deltaTime);
        }

        if(Direc.magnitude<0.1f && gm.CountItem==0 )
        {
            DrawWater.transform.localScale = new Vector2(DrawWater.transform.localScale.x, Save.ScaleOfWater);
            Debug.Log(Save.ScaleOfWater);
            ObjGameMaster.SetActive(false);
        }
    }

    
}
