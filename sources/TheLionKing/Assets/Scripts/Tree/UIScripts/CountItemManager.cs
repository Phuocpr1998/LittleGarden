using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int slNuoc = 1;
    public int slAnhSang = 1;
    public TextMeshProUGUI textNuoc;
    public TextMeshProUGUI textAnhSang;
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        slNuoc = PlayerPrefs.GetInt("slNuoc");
        textNuoc.text = slNuoc.ToString();
        textAnhSang.text = slAnhSang.ToString();
    }
}
