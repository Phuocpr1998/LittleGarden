using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isItemMove : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    GameMaster gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("MergeCanvas").GetComponent<GameMaster>();

    }
    private void OnMouseDown()
    {
        gm.isMerge = true;
    }
}
