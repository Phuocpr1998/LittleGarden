using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TreeGrow : MonoBehaviour
{
    private float exp;
    private float basicExp;

    public Sprite[] spritesLevel;

    private int level;
    public int Level { get => level; set => level = value; }

    void Start()
    {
        if (PlayerPrefs.HasKey("tree_level"))
        {
            level = PlayerPrefs.GetInt("tree_level");
        } else
        {
            level = 1;
        }

        if (PlayerPrefs.HasKey("tree_exp"))
        {
            exp = PlayerPrefs.GetFloat("tree_exp");
        }
        else
        {
            exp = 0;
        }


        if (level <= spritesLevel.Length)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spritesLevel[level - 1];
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spritesLevel[spritesLevel.Length - 1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (exp >= basicExp * level)
        {
            level++;
            if (level <= spritesLevel.Length)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = spritesLevel[level - 1];
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = spritesLevel[spritesLevel.Length - 1];
            }
        }
    }


    void OnDestroy()
    {
        PlayerPrefs.SetInt("tree_level", level);
        PlayerPrefs.SetFloat("tree_exp", exp);
    }
}
