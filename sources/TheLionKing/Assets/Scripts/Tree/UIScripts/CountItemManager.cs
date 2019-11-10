using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int slNuoc = 5;
    public int slAnhSang = 3;
    public TextMeshProUGUI textNuoc;
    public TextMeshProUGUI textAnhSang;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textNuoc.text = slNuoc.ToString();
        textAnhSang.text = slAnhSang.ToString();
    }
}
