using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitEnemyController : MonoBehaviour
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
    
    void DestroyIt()
    {
        if (transform.localScale.x > 0.5f)
        {
            int count = Random.Range(2, 4);
            for (int i = 0; i < count; i++)
            {
                Vector3 direction = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(0f, 1f), Random.Range(-1.5f, 1.5f));
                GameObject enemy = Instantiate(gameObject, transform.position + direction, Quaternion.identity);
                enemy.transform.localScale = transform.localScale / 1.5f;
            }

            Destroy(gameObject);
        }
        else
        {
            sound.Play();
            Destroy(gameObject);
            player.SendMessage("earnPoints", 5);
        }
    }
}
