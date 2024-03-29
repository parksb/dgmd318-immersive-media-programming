using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float range = 20f;
    
    public LayerMask shootableMask;
    
    public AudioSource sound;

    private bool mousePressed;
    private Vector3 mousePosition;

    private int ammo = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButtonDown(0))
         {
             mousePressed = true;
             mousePosition = Input.mousePosition;
         }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        
        Debug.DrawRay(ray.origin, ray.direction * range, Color.red);

        if (mousePressed)
        {
            if (ammo > 0)
            {
                ammo -= 1;
                sound.Play();
                Debug.Log("Ammo: " + ammo);

                if (Physics.Raycast(ray, out hit, range, shootableMask))
                {
                    hit.collider.attachedRigidbody.AddForce(ray.direction * 10.0f, ForceMode.Impulse);
                    hit.transform.gameObject.SendMessage("DestroyIt");
                }
            }
            else
            {
                Debug.Log("Out of ammo!");
            }

            mousePressed = false;
        }
    }
}