using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiceRotation : MonoBehaviour {
    float oldY = 0;
    float oldX = 0;
    float newY = 0;
    float newX = 0;
    string direction = "";
    int orientation = 0;

    int[] possibleAngles = { 0, 90, 180, 270 };
    int indexY;
    int indexX;

	// Use this for initialization
	void Start () {
        print("initial angle = " + transform.eulerAngles.x);
        oldY = transform.eulerAngles.y;
        oldX = transform.eulerAngles.x;
        indexY = getIndex(oldY, possibleAngles);
        indexX = getIndex(oldX, possibleAngles);
	}
	
	// Update is called once per frame
	void Update () {
        DiceRotate();
	}

    public void DiceRotate() {        
        
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {            
            direction = "horizontal";
            orientation = -1;
            if (indexY > 0) {
                newY = possibleAngles[indexY - 1];
                indexY--;
            }
            else {
                newY = possibleAngles[possibleAngles.Length-1];
                indexY = possibleAngles.Length-1;
            }
            oldY = transform.eulerAngles.y;
        }

        else if (Input.GetKeyUp(KeyCode.RightArrow)) {            
            direction = "horizontal";
            orientation = 1;
            if (indexY < possibleAngles.Length-1) {
                newY = possibleAngles[indexY + 1];
                indexY++;
            }
            else {
                newY = possibleAngles[0];
                indexY = 0;
            }
            oldY = transform.eulerAngles.y;
        }

        else if (Input.GetKeyUp(KeyCode.UpArrow)) { 
            print("OldX = " + oldX);                       
            direction = "vertical";
            orientation = -1;
            if (indexX > 0) {
                newX = possibleAngles[indexX - 1];
                indexX--;
            }
            else {
                newX = possibleAngles[possibleAngles.Length-1];
                indexX = possibleAngles.Length-1;
            }
            print("NewX = " + newX);  
            oldX = transform.eulerAngles.x;
        }

        else if (Input.GetKeyUp(KeyCode.DownArrow)) {             
            print("OldX = " + oldX);                       
            direction = "vertical";
            orientation = 1;
            if (indexX < possibleAngles.Length-1) {
                newX = possibleAngles[indexX + 1];
                indexX++;
            }
            else {
                newX = possibleAngles[0];
                indexX = 0;
            }
            print("NewX = " + newX);  
            oldX = transform.eulerAngles.x;
        }

        if (direction == "horizontal") {            
            if (Mathf.Abs(newY-transform.eulerAngles.y) > 2) {
                transform.Rotate(0, orientation*Time.deltaTime*80f, 0, Space.World);
            }
            else {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, newY, transform.localEulerAngles.z);
                // print("angle : " + transform.eulerAngles.y);
                direction = "";
                orientation = 0;
            }        
        }
        else if (direction == "vertical"){            
            if (Mathf.Abs(newX-transform.eulerAngles.x) > 2) {
                transform.Rotate(orientation*Time.deltaTime*80f, 0, 0, Space.World);
                print("angle : " + transform.eulerAngles.x);
            }
            else {
                print("stop");
                transform.localEulerAngles = new Vector3(newX, transform.localEulerAngles.y, transform.localEulerAngles.z);
                direction = "";
                orientation = 0;
            }
        }
    }

    private int getIndex(float oriPos, int[] posTable) {
        for (int i = 0; i < posTable.Length; i++) {
            if (Mathf.Abs(oriPos - posTable[i]) < 1) {
                return i;
            }
        }
        return 0;
    }
}
 