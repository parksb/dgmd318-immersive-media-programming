using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerController : MonoBehaviour
{
    public AudioSource simpleEnemyDead;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void PlaySimpleEnemyDead()
    {
        simpleEnemyDead.Play();
    }
}
