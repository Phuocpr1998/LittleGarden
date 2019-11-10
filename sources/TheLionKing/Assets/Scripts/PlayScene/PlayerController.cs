using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public GameObject[] lineTargets;
    public int lineTargetsLength;

    private int lineTargetIndex;
    private Vector3 oldPosition;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        lineTargetsLength = lineTargets.Length;
        lineTargetIndex = 1;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - oldPosition.x > 0)
            {
                if (lineTargetIndex < lineTargetsLength - 1)
                {
                    lineTargetIndex++;
                }
            }
            else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - oldPosition.x < 0)
            {
                if (lineTargetIndex > 0)
                {
                    lineTargetIndex--;
                }
            }
        }
        GameObject target = lineTargets[lineTargetIndex];
        gameObject.transform.Translate((new Vector2(target.transform.position.x, target.transform.position.y) - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)) * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.IndexOf("item") == -1)
            return;
        GameObject mapController =  GameObject.FindGameObjectWithTag("map_controller");
        audioSource.Play();
        if (mapController != null)
        {
            mapController.GetComponent<MapController>().AddColectedItem(collision.gameObject.GetComponent<ItemController>().indexType);
        }
    }
}
