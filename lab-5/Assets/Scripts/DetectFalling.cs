using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFalling : MonoBehaviour
{
    private GameObject xrorigin;

    void Awake()
    {
        xrorigin = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 30.0f))
        {
            if (hit.transform.gameObject.GetComponent<PlaneController>().IsAttacked())
            {
                xrorigin.GetComponent<TapToPlace>().DestoryObject(gameObject);  
            }         
        }
        else
        {
            xrorigin.GetComponent<TapToPlace>().DestoryObject(gameObject);
        }
    }
}
