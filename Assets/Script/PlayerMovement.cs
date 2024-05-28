using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller; 
    public float speed = 12f;
    public float gravity = 9.81f * 2;
    public float jumpHeight = 3f;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    Vector3 velocity; 
    
    bool isGrounded;
    bool isMoving; 
    
    private Vector3 lastPosition = new Vector3(0f,0f,0f);
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //resseting the default v
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        //get inputs 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        //moving v
        Vector3 move = transform.right * x + transform.forward * z; 
        
        //moving player
        controller.Move(move * speed * Time.deltaTime);
        
        //checking for player jumpp
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        //falling
        velocity.y += gravity * Time.deltaTime;
        
        //make the player jump
        controller.Move(velocity * Time.deltaTime);
        if (lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true; 
            //for later use 
        }
        else
        {
            isMoving = false; 
            //for later use 
        }

        lastPosition = gameObject.transform.position;
          
    }
}
