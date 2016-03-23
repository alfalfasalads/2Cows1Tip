using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	/* This script will only contain the commands that will control the player.
	 * these commands will not be called here, they will be called in the Input
	 * Manger.
	 * 
	 * For this script we will need to use certain vectors in order to move and rotate the player
	 * 
	 * 
	 * FORWARD
	 * 
	 * gameObject.transform.forward
	 * An object's transform's forward literally this vector:
	 * 
	 * 
	 * RIGHT
	 * 
	 * new Vector3 (0,0,1); 
	 * 
	 * gameObject.transform.right
	 * An object's transform's right literally this vector:
	 * 
	 * new Vector3 (1,0,0); 
	 * 
	 * 
	 * UP
	 * 
	 * gameObject.transform.up
	 * An object's transform's right literally this vector:
	 * 
	 * new Vector3 (1,0,0); 
	 * 
	 */
	
	//this float will determine the player's speed;  We will ultimate multiply this by the final direction;
	public float speed = 1;
	

	
	//a reference to the rigid body of this object
	Rigidbody rigidbody;
	
	//these Vectors will keep track of the players direction
	Vector3 leftRightDirection = new Vector3(0,0,0); //will keep track of movement along the transform right of the player
	Vector3 backFrontDirection = new Vector3(0,0,0); //will keep track of movement along the transform forward of the player
	Vector3 finalDirection = new Vector3(0,0,0); //will keep track of the vertical and horizontal movement combined
	
	
	void Start () {
		
		rigidbody = GetComponent<Rigidbody> (); //getting the rigid body of the object for later use
		
	}
	
	/* We are making the movement function public
	* because we want to call it from the Input Manager.
	* 
	* A public variable/function can be seen by other scripts
	* A private variable/function can only be seen by itself
	*/
	
	public void Move (float horizontalAxis, float verticalAxis) {
		
		/*
		 * VECTOR MULTIPLICATION (It's simple)
		 * 
		 * 1 * (1,1,1) = (1,1,1);
		 * 0 * (1,1,1) = (0,0,0);
		 * -1 * (1,0,0) = (-1,-1,-1);
		 * 
		 */
		
		leftRightDirection = transform.right * horizontalAxis;
		backFrontDirection = transform.forward * verticalAxis;
		
		/* The final step we need to take is to calculate the final direction of the player,
		 * and to do this we will use the very simple property of vector addition.
		 * 
		 * When you add two vectors together, you just add each of the corresponding values together.
		 * 
		 * VECTOR ADDITION (It's simple)
		 * 
		 * (1,1,1) + (1,1,1) = (2,2,2)
		 * (1,1,1) + (0,0,0) = (1,1,1)
		 * (1,1,1) + (-1,-1,-1) = (0,0,0)
		 * 
		 * so if we add the leftRight direction and forwardBack direction, we will get something like this
		 * 
		 * (x, 0, 0) + (0, 0, z) = (x, 0, z)
		 */
		
		finalDirection = leftRightDirection + backFrontDirection;
		
		
		
		//now we use multiplication to get the final speed in the direction we want to go
		finalDirection = finalDirection * speed;
		
		
		
		//now we multiply by Time.deltaTime.. what that is is a lesson for another day but the simple answer is that is will make the player's
		//movement even (multiplying by Time.deltaTime prevents jittering of motion)
		finalDirection = finalDirection * Time.deltaTime;
		
		
		
		/* For basic movement we will use rigidbody.moveposition because this function will take collisions into consideration
		 * 
		 * rigidbody.moveposition takes your current position + your desired direction and moves you based on that.  Once again, 
		 * we can use vector addition for this
		 * 
		 */
		
		rigidbody.MovePosition (transform.position + finalDirection);
		
	}
	
	//mouse sensitivity
	public float mouseSensitivity = 1;
	
	//A reference to the attached camera
	public Camera cam;
	
	
	/* We are making the mouselook function public
	* because we want to call it from the Input Manager.
	* 
	* A public variable/function can be seen by other scripts
	* A private variable/function can only be seen by itself
	*/
	
	public void MouseLook (float mouseXAxis, float mouseYAxis) {
		
	
		
		transform.Rotate (0, mouseXAxis * mouseSensitivity, 0);
		

		
		cam.transform.Rotate (-mouseYAxis * mouseSensitivity, 0, 0);
		
		// The rotation here is negative. If you do not add a negative here, your look will be inverted.
		
	}
}
