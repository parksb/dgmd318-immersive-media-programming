using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusController : MonoBehaviour
{
    private AudioSource audioSource;
    
    private float rotatingSpeed = 1.0f;
     
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
        if (touchCount == 1 && rotatingSpeed <= 100.0f)
        {
            audioSource.Play();
            rotatingSpeed += 10.0f;
        }
        else if (touchCount == 2 && rotatingSpeed >= 11.0f)
        {
            audioSource.Play();
            rotatingSpeed -= 10.0f;
        }

        Debug.Log("Venus rotating speed: " + rotatingSpeed);
    }
}
