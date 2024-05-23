using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTargetController : MonoBehaviour
{
    private GameObject player;

    public AudioSource destroyAudio;
    public AudioSource missAudio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SuperBullet")
        {
            destroyAudio.Play();
            GetComponent<Renderer>().enabled = false;
            player.GetComponent<ShootGameController>().LevelClear();
            Destroy(gameObject, 2);
        }
        else
        {
            missAudio.PlayOneShot(missAudio.clip);
        }
    }
}
