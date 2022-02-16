using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public GameObject scoreText;
    public float timer;
    public float delay;

    private void Awake()
    {
        timer = 0;
        delay = 1;
    }

    public void Update()
    {
        if(Time.timeSinceLevelLoad > delay)
        {
            timer += 1;
            delay += 1;
        }
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + timer.ToString();
        ScoreClass.score = timer;
    }
}
