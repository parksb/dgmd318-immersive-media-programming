using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemyController : MonoBehaviour
{
    public AudioSource sound;
    private GameObject player;

    public float radius = 5.0f;
    public float power = 200.0f;
    public float lift = 30;

    private bool isExploded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isExploded)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(power, transform.position, radius, lift);
                }
            }

            Destroy(gameObject);
            player.SendMessage("earnPoints", 2);
        }
    }
    
    void DestroyIt()
    {
        sound.Play();
        isExploded = true;
    }
}
