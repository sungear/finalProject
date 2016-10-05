using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiceRotation : MonoBehaviour {
    float oldY = 0;
    float oldX = 0;
    float newY = 0;
    float newX = 0;
    float direction = 0;
    string clickedArrow = "";
    bool isOutOfBound = false;

    int[] possibleAngles = { 0, 90, 180, 270 };
    int index;

	// Use this for initialization
	void Start () {
        print("initial angle = " + transform.eulerAngles.y);
        // oldY = transform.eulerAngles.y;
        // newY = oldY;       
	}
	
	// Update is called once per frame
	void Update () {
        // DiceRotate();
	}

    public void DiceRotate() {

        // print("updated angle = " + transform.eulerAngles.y);
        print("clicked");
        // transform.Rotate(0, direction*Time.deltaTime*80f, 0, Space.World);
        // transform.Rotate(0, direction*Time.deltaTime*80f, 0, Space.World);

        // if (Input.GetKeyUp(KeyCode.LeftArrow)) {  
        //     // direction = -1f;          
        //     oldY = transform.rotation;
        //     transform.rotation = oldY * Quaternion.Euler(0, -90, 0);
        //     // if (newY > oldY) {
        //     //     isOutOfBound = true;
        //     //     if (isOutOfBound) {
        //     //         if (transform.rotation != newY {
        //     //             rotationAnimation(direction);
        //     //             if transform.rotation 
        //     //         }
        //     //     }
        //     // }
        // }

        
        
        // if (Input.GetKeyUp(KeyCode.LeftArrow)) {
        //     clickedArrow = "Left";
        //     oldY = transform.eulerAngles.y;
        //     direction = -1;
        //     newY = oldY-90f;
        //     if (newY <= 0f ) {
        //         newY += 360f;
        //         isOutOfBound = true;
        //     }
        // }

        // else if (Input.GetKeyUp(KeyCode.RightArrow)) {
        //     clickedArrow = "Right";
        //     oldY = transform.eulerAngles.y;
        //     direction = 1;
        //     newY = oldY+90f;
        //     if (newY > 360) {
        //         newY -= 360;
        //         isOutOfBound = true;
        //     }
        // }

        // else if (Input.GetKeyUp(KeyCode.UpArrow)) {
        //     clickedArrow = "Up";
        //     oldX = transform.eulerAngles.x;
        //     direction = -1;
        //     newX = oldX-90f;
        //     if (newX < 0 ) {
        //         newX += 360;
        //         isOutOfBound = true;
        //     }
        // }

        // else if (Input.GetKeyUp(KeyCode.DownArrow)) {
        //     clickedArrow = "Down";
        //     oldX = transform.eulerAngles.x;
        //     direction = 1;
        //     newX = oldX+90f;
        //     if (newX > 360) {
        //         newX -= 360;
        //         isOutOfBound = true;
        //     }
        // }

        // if ((transform.eulerAngles.y > newY && !isOutOfBound)||(transform.eulerAngles.y < newY && isOutOfBound)) {
        //     transform.Rotate(0, direction*Time.deltaTime*80f, 0, Space.World);
        //     if ((transform.eulerAngles.y <= newY&& !isOutOfBound)||(transform.eulerAngles.y >= newY && isOutOfBound)) {
        //         transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, newY, transform.localEulerAngles.z);
        //         oldY = 0;
        //         newY = 0;
        //         direction = 0;
        //         isOutOfBound = false;
        //     }
        // }
    }

    private void rotationAnimation(float direction) {
        transform.Rotate(0, direction*Time.deltaTime*80f, 0, Space.World);
    }

    private int getIndex(float oriPos, int[] posTable) {
        for (int i = 0; i < posTable.Length; i++) {
            if (oriPos == posTable[i]) {
                return i;
            }
        }
        return 0;
    }
}
 