using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController : MonoBehaviour
{
    public AudioSource sound;
    private GameObject player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyIt()
    {
        sound.Play();
        Destroy(gameObject);
        player.SendMessage("earnPoints", 1);
    }
}