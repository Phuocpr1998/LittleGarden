using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomToggle: MonoBehaviour
{
    public Image targetGraphic;
    public Image target;

    public bool IsOn = false;
    
    public void OnTargetClick()
    {
        IsOn = !IsOn;
        Vector3 newPos = target.transform.position;
        if (IsOn)
        {
            newPos.x += target.rectTransform.sizeDelta.x / 2;
        } else
        {
            newPos.x -= target.rectTransform.sizeDelta.x / 2;
        }
        target.transform.position = newPos;
    }
}
