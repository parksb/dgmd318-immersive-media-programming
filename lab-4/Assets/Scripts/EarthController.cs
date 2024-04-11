using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 3.0f * Time.deltaTime);
    }
    
    public void OnTouched(int touchCount)
    {
        if (touchCount == 1)
        {
            audioSource.Play();
        }
    }
}