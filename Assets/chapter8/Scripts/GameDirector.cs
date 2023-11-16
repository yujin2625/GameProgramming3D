using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameDirector : MonoBehaviour
{
    TMP_Text timerText;
    TMP_Text pointText;
    float time = 60.0f;
    int point = 0;
    public void GetApple()
    {
        point += 100;
    }
    public void GetBomb()
    {
        point /= 2;
    }
    private void Start()
    {
        timerText = GameObject.Find("Time").GetComponent<TMP_Text>();
        pointText = GameObject.Find("Point").GetComponent<TMP_Text>();
    }
    private void Update()
    {
        time -= Time.deltaTime;
        timerText.text = time.ToString("F1");
        pointText.text = point.ToString() + " point";
    }
}
