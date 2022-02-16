using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScore : MonoBehaviour
{
    public GameObject scoreText;

    private void Awake()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + ScoreClass.score.ToString();
    }
}
