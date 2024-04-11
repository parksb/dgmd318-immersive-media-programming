using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttleController : MonoBehaviour
{
     // Start is called before the first frame update
     void Start()
     {
         
     }
 
     // Update is called once per frame
     void Update()
     {
         Transform venus = GameObject.Find("Venus").transform;
         if (transform.position == venus.position)
         {
             Debug.Log("Arrived at Venus");
             Destroy(gameObject);
         }
         else
         {
             transform.LookAt(venus);
             transform.position = Vector3.MoveTowards(transform.position, venus.position, 0.05f * Time.deltaTime);            
         }
     }   
}