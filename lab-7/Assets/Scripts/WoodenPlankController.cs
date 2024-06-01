using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenPlankController : MonoBehaviour
{
    private AudioSource audiosrc;

    // Start is called before the first frame update
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            audiosrc.Play();
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, 2);
        }
    }
}
