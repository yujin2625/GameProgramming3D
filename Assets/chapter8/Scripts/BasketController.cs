using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameDirector director;
    private void Start()
    {
        aud = GetComponent<AudioSource>();
        director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("apple"))
        {
            director.GetApple();
            aud.PlayOneShot(appleSE);
        }
        else
        {
            director.GetBomb();
            aud.PlayOneShot(this.bombSE);
        }
        Destroy(other.gameObject);
    }
}
