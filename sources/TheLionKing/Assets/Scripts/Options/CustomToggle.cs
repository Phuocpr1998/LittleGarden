using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomToggle: MonoBehaviour
{
    public Image targetGraphic;
    public Image target;

    private bool isOn = false;

    public bool IsOn {
        get => isOn;
        set {
            if (value != isOn)
            {
                changePosition(value);
                isOn = value;
            }
        }
    }

    public void OnTargetClick()
    {
        isOn = !isOn;
        changePosition(isOn);
    }

    void changePosition(bool on)
    {
        Vector3 newPos = target.rectTransform.localPosition;
        if (on)
        {
            newPos.x += target.rectTransform.sizeDelta.x / 2;
        }
        else
        {
            newPos.x -= target.rectTransform.sizeDelta.x / 2;
        }
        target.rectTransform.localPosition = newPos;
    }
}
