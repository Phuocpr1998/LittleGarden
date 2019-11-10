using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private float score;
    public float Score { get => score; set => score = value; }

    public int indexType;
    public Vector3 vecDrirection;

    private float scaleStep = -1;
    private float maxScale = 0.35f;
    private float minScale = 0.1f;
    private Rigidbody2D myRigidbody;



    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        gameObject.transform.localScale = new Vector3(minScale, minScale, gameObject.transform.localScale.z);
        scaleStep = -1;
        StartCoroutine(scaleObject(0.2f));
    }

    // Update is called once per frame
    void Update()
    {
        if (vecDrirection - new Vector3(-100, -100, -100) != Vector3.zero)
        {
            myRigidbody.velocity = vecDrirection * 0.5f;
            if (scaleStep == -1)
            {
                float duration = Mathf.Sqrt(vecDrirection.x * vecDrirection.x + vecDrirection.y * vecDrirection.y);
                scaleStep = (maxScale - minScale) / (10 * duration);
            }
        }
    }

    IEnumerator scaleObject(float second)
    {
        while (true)
        {
            if (gameObject.transform.localScale.x < maxScale && scaleStep != -1)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + scaleStep, gameObject.transform.localScale.y + scaleStep, gameObject.transform.localScale.z);
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }
}
