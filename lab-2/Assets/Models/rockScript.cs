using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockScript : MonoBehaviour
{
    private bool moving = false;
    private Vector3 direction;
    private float speed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(0.0f, 1.0f);
        float z = Random.Range(-1.0f, 1.0f);
        direction = new Vector3(x, y, z);

        speed = Random.Range(1.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            moving = true;
        }

        if (moving)
        {
             transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
