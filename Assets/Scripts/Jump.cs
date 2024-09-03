using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour 
{
    private CharacterController Controller;

    public float verticalVelocity;
    private float gravity=0;
    private float jumpForce=0;

	// Use this for initialization
	void Start ()
    {
        Controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                verticalVelocity = jumpForce;
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }
            Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
            Controller.Move(moveVector * Time.deltaTime);
        }
	}
}
