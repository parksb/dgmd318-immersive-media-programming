using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip successSound;   
    public AudioClip failSound;
    private AudioSource audioSource;
     
    private float force = 5.0f;
    private int health = 100;
    private int point = 0;
    
    private Vector3 direction = Vector3.zero;
    private Rigidbody rb;
    
    private bool isPaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        direction = new Vector3(moveH, 0.0f, moveV);

        if (Input.GetKeyDown("p"))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    
    void FixedUpdate()
    {
        rb.AddForce(direction * force);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            point += 1;
            audioSource.PlayOneShot(successSound);
            Debug.Log("Yum Yum! I ate: " + other.gameObject.name + ". I've eaten " + point + " items.");
            Destroy(other.gameObject);

            if (point == 20)
            {
                Debug.Log("Congratulations!");
                isPaused = true;
            }
        }
        else if (other.CompareTag("NotFood"))
        {
            health -= 10;
            audioSource.PlayOneShot(failSound);
            Debug.Log("Player takes damage. Health is now: " + health);
        }
    }
}
