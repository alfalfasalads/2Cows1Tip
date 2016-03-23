using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	

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
	

	
	public void Move (float horizontalAxis, float verticalAxis) {
		

		
		leftRightDirection = transform.right * horizontalAxis;
		backFrontDirection = transform.forward * verticalAxis;
		
		/*
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

	//STEVEN'S SCRIPT
	//When an object is within the player's colider box:
	public void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag ("Cow")) {
			if (Input.GetKeyDown (KeyCode.E)) {
				//other.gameObject.SetActive(false); // makes obj disapear
				//other.transform.Rotate(90, 0, 0); // rotates it 90 degrees on the X
				other.GetComponent<Rigidbody> ().AddForce (0, 5, 2, ForceMode.Impulse); //gets the tag for Cow and access the Rigidbody component which makes them get pushed
				
				Debug.Log ("moo");
			}
		}
	}
}
