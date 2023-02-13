using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public PlayerController player;

    void Update()
    {
        scoreText.text = player.score.ToString("0");
    }
}
