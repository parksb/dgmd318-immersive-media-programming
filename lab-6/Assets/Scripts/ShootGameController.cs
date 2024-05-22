using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGameController : MonoBehaviour
{
    public int totalTargets = 10;

    public void IncrScore()
    {
        this.totalTargets -= 1;
        if (this.totalTargets <= 0) {
            Debug.Log("Level Cleared");
        }
    }
}
