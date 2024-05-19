using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (gameObject.tag == "BlueBall" && other.gameObject.tag == "BlueBox")
        {
            player.GetComponent<GameController>().IncrScore();
            Destroy(gameObject);
        }
        else if (gameObject.tag == "RedBall" && other.gameObject.tag == "RedBox")
        {
            player.GetComponent<GameController>().IncrScore();
            Destroy(gameObject);
        }
        else if(gameObject.tag == "YellowBall" && other.gameObject.tag == "YellowBox")
        {
            player.GetComponent<GameController>().IncrScore();
            Destroy(gameObject);
        }
    }
}
