using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {

    ClimbingSystem climbSystem;
    public float jumpspeed = 8;
    public float speed = 6.0f;
    public float gravity = 9.8f;
    private CharacterController charControl;
   private Vector3 moveDirection = Vector3.zero;
    void Start()
    {
        charControl = GetComponent<CharacterController>();
        climbSystem = GetComponent<ClimbingSystem>();
    }


    public void SetGravity(float newGravity)
    {
            gravity = newGravity;
    }
	// Update is called once per frame
	void Update () {
       
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if(Input.GetButton("Jump") && ((charControl.isGrounded) || climbSystem.isClimbing()))
        
                {
                    moveDirection.y = jumpspeed;
                }
            
        if(climbSystem.isClimbing())
        {
            transform.up *= -gravity *Time.deltaTime;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection *= Time.deltaTime;
        charControl.Move(moveDirection);
	}
}
