using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {


	//This is a reference to the playerController script
	PlayerController playerController;

	PauseGame pauseGame;
	
	//These floats will keep track of the values of each axis we are listening to
	float horizontalAxis = 0; //left and right mouvement axis, zero means no input
	float verticalAxis = 0; //front and back mouvement axis, zero means no input
	float mouseXAxis = 0; //horizontal mouse movement tracking axis, zero mouse hasnt moved left or right
	float mouseYAxis = 0; //vertical mouse movement tracking axis, zero mouse hasnt moved up or down

	
	
	void Awake(){

		//getting the playercontroller script
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController> ();

		//getting the pause Game script
		pauseGame = GameObject.FindGameObjectWithTag ("pauseManager").GetComponent<PauseGame> ();

	}
	// Update is called once per frame
	void Update () {
		CaptureInputs();
	}
	
	void CaptureInputs(){

		//pausing the game
		if(Input.GetKeyDown(KeyCode.P)){
			pauseGame.pauseGame();

		}

		mouseXAxis = Input.GetAxis ("Mouse X");
		mouseYAxis = Input.GetAxis ("Mouse Y");
		
		if (mouseXAxis != 0 || mouseYAxis != 0) {
			
		
		
		playerController.MouseLook(mouseXAxis, mouseYAxis);

		}
		
		
	}

	void FixedUpdate () {

		horizontalAxis = Input.GetAxisRaw ("Horizontal"); //will return -1, 0 or 1 ---> -1 = left, 0 = no movement, 1 = right
		verticalAxis = Input.GetAxisRaw ("Vertical"); //will return -1, 0 or 1 ---> -1 = back, 0 = no movement, 1 = forward
		
		//only move if both axis are not equal to zero
		if (horizontalAxis != 0 || verticalAxis != 0) {
			playerController.Move(horizontalAxis, verticalAxis);

		}


	}
}
