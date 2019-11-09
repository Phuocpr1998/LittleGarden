using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject toggleMusic, toggleSFX;
    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {}


    public void SwitchAudioMusic()
    {
        bool isOn = toggleMusic.GetComponent<CustomToggle>().IsOn;
        if (isOn)
        {
            audioMixer.SetFloat("Music", 10);
        }
        else
        {
            audioMixer.SetFloat("Music", -80);
        }
    }

    public void SwitchAudioSFX()
    {
        bool isOn = toggleSFX.GetComponent<CustomToggle>().IsOn;
        if (isOn)
        {
            audioMixer.SetFloat("SFX", 20);
        } else
        {
            audioMixer.SetFloat("SFX", -80);
        }
    }
}
