using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    private AudioSource audioSource;

    public GameObject shuttle;
    
    private float rotatingSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime);
    }
    
    public void OnTouched(int touchCount)
    {
        if (touchCount == 1)
        {
            audioSource.Play();
            Instantiate(shuttle, transform.position, Quaternion.identity);
        }
    }

    public void UpdateSpeed(float speed)
    {
        rotatingSpeed = speed * 2.0f;
    }
}