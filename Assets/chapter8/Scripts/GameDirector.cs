using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameDirector : MonoBehaviour
{
    public GameObject itemGenerator;
    bool isPlaying = false;
    TMP_Text timerText;
    TMP_Text pointText;
    float time = 30.0f;
    int point = 0;
    public void GetApple()
    {
        point += 100;
    }
    public void GetBomb()
    {
        point /= 2;
    }
    public void OnStart()
    {
        itemGenerator.SetActive(true);
        isPlaying = true;
    }
    private void Start()
    {
        timerText = GameObject.Find("Time").GetComponent<TMP_Text>();
        pointText = GameObject.Find("Point").GetComponent<TMP_Text>();
    }
    private void Update()
    {
        if (isPlaying)
        {
            time -= Time.fixedDeltaTime;
            timerText.text = time.ToString("F1");
            pointText.text = point.ToString() + " point";
        }
    }
}
