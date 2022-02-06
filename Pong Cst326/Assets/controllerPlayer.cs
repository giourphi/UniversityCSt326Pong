using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem; 
public class controllerPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public Transform cam;
    // void Start()
    // {
        
    // }

    public float moveSpeed  = 8f; 
    public float turnSmoothTime =0.1f; 
    float turnSmoothVelocity;
   // public float runSpeed  = 100f; 
    // Update is called once per frame
    void FixedUpdate()
    {
        // float horizontal  = Input.GetAxisRaw("Horizontal");
        // float vertical  = Input.GetAxisRaw("Vertical");
        // float forward = Input.GetAxisRaw("Vertical");; 

        // Vector3 direction  = new Vector3(horizontal, 0f, vertical).normalized; 
        // Vector3 forwarddirection = new Vector3(0f,vertical,0f).normalized; 
        // float targetAngle = Mathf.Atan2(direction.x,direction.z)* Mathf.Rad2Deg +cam.eulerAngles.y;
        // if(direction.magnitude>=0.1f)

        // {
        //     float angle  = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity,turnSmoothTime);
        //    transform.rotation  = Quaternion.Euler(0f,angle,0f);
            
        //     Vector3 moveDirection  = Quaternion.Euler(0f,targetAngle,0f)* Vector3.forward; 
        //     controller.Move(moveDirection.normalized*moveSpeed*Time.deltaTime);

        // }

       // float movementAxis = Input.GetAxis("Horizontal");
        // Transform transform = GetComponent<Transform>();

        //Vector3 force = Vector3.right * movementAxis * moveSpeed * Time.deltaTime;

     //  Rigidbody rbody = GetComponent<Rigidbody>();
     //   if (rbody)
    //    {
     //       rbody.AddForce(force, ForceMode.VelocityChange);
     //   }
       

        if(Input.GetKey(KeyCode.A)){
            
           Transform transform =  GetComponent<Transform>(); 
           transform.position += -Vector3.right*moveSpeed *Time.deltaTime;

          
        }

        if(Input.GetKey(KeyCode.D)){
           Transform transform =  GetComponent<Transform>(); 
           transform.position += Vector3.right*moveSpeed*Time.deltaTime;

         
        }

          if(Input.GetKey(KeyCode.W)){
           Transform transform =  GetComponent<Transform>(); 
           transform.position += Vector3.up*moveSpeed*Time.deltaTime;

            
        }

         if(Input.GetKey(KeyCode.S)){
           Transform transform =  GetComponent<Transform>(); 
           transform.position += -Vector3.up*moveSpeed*Time.deltaTime;

            
        }
         
        
        

    }
    

    private void OnCollisionEnter(Collision collision)
    {
        BoxCollider bbox = GetComponent<BoxCollider>();
        float xCenter = bbox.bounds.center.x;

        Debug.Log("Center at " + xCenter + "collided object at " + collision.transform.position.x);

        Vector3 newVector = Quaternion.Euler(0f, 0f, 45f) * Vector3.up;

        Debug.DrawLine(transform.position, transform.position + newVector * 10f, Color.red);
        Debug.Break();
    }
}
