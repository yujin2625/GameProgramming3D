using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1.0f;
    float delta = 0;
    int ratio = 2;
    float speed = -0.03f;
    bool[] isFull = new bool[9] { false, false, false, false, false, false, false, false, false };
    Vector3[] Board = new Vector3[9]
    {
        new Vector3(-1,4,-1),
        new Vector3(-1,4,0),
        new Vector3(-1,4,1),
        new Vector3(0,4,-1),
        new Vector3(0,4,0),
        new Vector3(0,4,1),
        new Vector3(1,4,-1),
        new Vector3(1,4,0),
        new Vector3(1,4,1)
    };
    private void Update()
    {
        delta += Time.fixedDeltaTime;
        if (delta > span)
        {
            delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);
            if (dice <= ratio)
            {
                item = Instantiate(bombPrefab);
            }
            else
            {
                item = Instantiate(applePrefab);
            }
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
    }
    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }
    public float RandomTime()
    {
        return Random.Range(-0.05f, -0.01f);
    }
}
