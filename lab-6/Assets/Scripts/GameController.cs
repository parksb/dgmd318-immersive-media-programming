using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioSource scoreSound;

    private int score = 0;

    public void IncrScore()
    {
        scoreSound.Play();
        this.score += 1;
        Debug.Log("Score: " + score);
    }
}
