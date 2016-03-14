using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	private bool isPaused;

 void Awake(){
		isPaused = false;

	}




	
	// Update is called once per frame
	public void pauseGame () {
		if (!isPaused) {
			isPaused = true;
			print ("the game has been paused");
			Time.timeScale = 0;

		} 
		else if(isPaused) {
			isPaused = false;
			print ("the game is unpaused");
			Time.timeScale = 1;

		}
	
	}

	void OnGUI() {
		if (isPaused)
			GUI.Label(new Rect(100, 100, 50, 30), "Game paused");
		
	}


}


/* Javascript code from the tutorial: to translate to C#
 * 
 * 
 *  
var paused : boolean = false;
 
function Update () {
 
    if(Input.GetKeyDown("p") && paused == false) {  
        paused = true;  
        Time.timeScale = 0;
        }
        else if(Input.GetKeyDown("p") && paused == true) {
                paused = false;
                Time.timeScale = 1;
       }  
}
*
 */
