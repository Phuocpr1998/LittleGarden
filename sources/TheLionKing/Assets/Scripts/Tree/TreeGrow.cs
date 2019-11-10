using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeGrow : MonoBehaviour
{
    private float exp;
    private float basicExp;

    public Text textLevel;
    public Sprite[] spritesLevel;
    private List<GameObject> conditionsLife;

    private int level;
    public int Level { get => level; set => level = value; }

    void Start()
    {
        basicExp = 100;
        conditionsLife = new List<GameObject>();
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

        conditionsLife.Add(GameObject.FindGameObjectWithTag("TTPhanBon"));
        conditionsLife.Add(GameObject.FindGameObjectWithTag("TTAnhSang"));
        conditionsLife.Add(GameObject.FindGameObjectWithTag("TTWater"));
        textLevel.text = level.ToString();
        StartCoroutine(GrowingTree());
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
            textLevel.text = level.ToString();
        }
    }

    IEnumerator GrowingTree()
    {
        while (true)
        {
            bool isGrow = true;
            float sumConditions = 0;
            foreach(GameObject condition in conditionsLife)
            {
                if (condition.GetComponent<DrawWater>().PhanTramNuoc < 50)
                {
                    isGrow = false;
                    break;
                }
                sumConditions += condition.GetComponent<DrawWater>().PhanTramNuoc;
            }
            if (isGrow)
            {
                exp += sumConditions / (conditionsLife.Count * 100);
            }
            yield return new WaitForSeconds(2);
        }
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("tree_level", level);
        PlayerPrefs.SetFloat("tree_exp", exp);
        StopAllCoroutines();
    }
}
