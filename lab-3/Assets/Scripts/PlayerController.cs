using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 5.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 0.5f;

    private Vector3 velocity;
    private bool isGrounded;
    private int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
         isGrounded = controller.isGrounded;
         if (isGrounded)
         {
             velocity.y = 0.0f;
         }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 direction = transform.right * x + transform.forward * z;
        controller.Move(direction * speed * Time.deltaTime);
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    
    public void earnPoints(int value)
    {
        points += value;
        Debug.Log("Player earned points. Now points: " + points);
    }
}