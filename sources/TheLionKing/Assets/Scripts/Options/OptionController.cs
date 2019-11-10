using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionController : MonoBehaviour
{
    public AudioMixer audioMixer;
    private bool isOnMusic, isOnSFX;
    // Start is called before the first frame update
    void Start()
    {
        float value = -1;
        audioMixer.GetFloat("Music", out value);
        isOnMusic = value >= 0;
        audioMixer.GetFloat("SFX", out value);
        isOnSFX = value >= 0;
    }

    // Update is called once per frame
    void Update()
    {}


    public void SwitchAudioMusic()
    {
        isOnMusic = !isOnMusic;
        if (isOnMusic)
        {
            audioMixer.SetFloat("Music", 1f);
        }
        else
        {
            audioMixer.SetFloat("Music", -80);
        }
    }

    public void SwitchAudioSFX()
    {
        isOnSFX = !isOnSFX;
        if (isOnSFX)
        {
            audioMixer.SetFloat("SFX", 1f);
        } else
        {
            audioMixer.SetFloat("SFX", -80);
        }
    }

    public void ButtonAcceptClick()
    {
        gameObject.SetActive(false);
    }
}
