using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawnerScript : MonoBehaviour
{
    public GameObject obj;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            float x = Random.Range(-4.0f, 4.0f);
            float y = Random.Range(0.0f, 3.0f);
            float z = Random.Range(-4.0f, 4.0f);
            
            GameObject rock = Instantiate(obj, new Vector3(x, y, z), Quaternion.Euler(x * 90.0f, y * 90.0f, z * 90.0f));
            rock.transform.parent = transform;
        }
        
         if (Input.GetMouseButtonDown(0))
         {
             for (int i = 0; i < transform.childCount; i += 1)
             {
                 Destroy(transform.GetChild(i).gameObject);
             }
         }       
    }
}
