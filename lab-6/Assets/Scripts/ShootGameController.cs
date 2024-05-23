using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGameController : MonoBehaviour
{
    public bool isScoreMode = false;

    public int totalTargets = 10;
    private int score = 0;

    public void IncrScore()
    {
        if (this.isScoreMode)
        {
            this.score += 1;
        }
        else
        {
            this.totalTargets -= 1;
            if (this.totalTargets <= 0) {
                Debug.Log("Level Cleared");
            }
        }
    }

    public void LevelClear()
    {
        Debug.Log("Level Cleared! Your score: " + this.score);
    }
}
