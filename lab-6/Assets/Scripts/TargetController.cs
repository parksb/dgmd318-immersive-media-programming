using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private GameObject player;

    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            audio.Play();
            GetComponent<Renderer>().enabled = false;
            player.GetComponent<ShootGameController>().IncrScore();
            Destroy(gameObject, 2);
        }
    }
}
