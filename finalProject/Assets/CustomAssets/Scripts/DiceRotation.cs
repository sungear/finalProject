using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiceRotation : MonoBehaviour {
    float oldY;
    float oldX;
    float newY;
    float newX;
    float oldZ;
    string direction = "";
    int orientation = 0;

    int[] possibleAngles = { 0, 90, 180, 270 };
    int indexY;
    int indexX;

    Vector3 targetAngles;
    Vector3 originalAngles;

	// Use this for initialization
	void Start () {
        print("initial angle = " + transform.eulerAngles.x);
        oldZ = 0;
        oldY = transform.localEulerAngles.y;
        newY = oldY;
        oldX = transform.localEulerAngles.x;
        newX = oldX;
        print("OldX = " + oldX);
        indexY = getIndex(oldY, possibleAngles);
        indexX = getIndex(oldX, possibleAngles);
        originalAngles = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        DiceRotate();
	}

    public void DiceRotate() {

        if (Input.GetKeyUp(KeyCode.LeftArrow)) {            
            direction = "horizontal";
            // orientation = -1;
            if (indexY > 0) {
                newY = possibleAngles[indexY - 1];
                indexY--;
            }
            else {
                newY = possibleAngles[possibleAngles.Length-1];
                indexY = possibleAngles.Length-1;
            }
            // oldY = transform.localEulerAngles.y;
            // originalAngles = transform.eulerAngles;

            // targetAngles = newY * Vector3.up;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, newY, transform.eulerAngles.z);
        }

        else if (Input.GetKeyUp(KeyCode.RightArrow)) {            
            direction = "horizontal";
            // orientation = 1;
            if (indexY < possibleAngles.Length-1) {
                newY = possibleAngles[indexY + 1];
                indexY++;
            }
            else {
                newY = possibleAngles[0];
                indexY = 0;
            }
            // oldY = transform.localEulerAngles.y;
            // originalAngles = transform.eulerAngles;
            // targetAngles = newY * Vector3.up;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, newY, transform.eulerAngles.z);
        }

        else if (Input.GetKeyUp(KeyCode.UpArrow)) {                       
            direction = "vertical";
            // orientation = -1;
            if (indexX > 0) {
                newX = possibleAngles[indexX - 1];
                indexX--;
            }
            else {
                newX = possibleAngles[possibleAngles.Length-1];
                indexX = possibleAngles.Length-1;
            }
            // print("NewX = " + newX);  
            // oldX = transform.localEulerAngles.x;
            // print("OldX = " + oldX); 
            // originalAngles = transform.eulerAngles;
            // targetAngles = newX * Vector3.right;
            transform.eulerAngles = new Vector3(newX, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        else if (Input.GetKeyUp(KeyCode.DownArrow)) {                            
            direction = "vertical";
            // orientation = 1;
            if (indexX < possibleAngles.Length-1) {
                newX = possibleAngles[indexX + 1];
                indexX++;
            }
            else {
                newX = possibleAngles[0];
                indexX = 0;
            }
            // print("NewX = " + newX);  
            // oldX = transform.localEulerAngles.x;       
            // print("OldX = " + oldX); 
            // originalAngles = transform.eulerAngles;
            // targetAngles = newX * Vector3.right;
            transform.eulerAngles = new Vector3(newX, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        // if (direction == "horizontal") {            
        //     if (Mathf.Abs(newY-transform.localEulerAngles.y) > 2) {
        //         transform.Rotate(0, orientation*Time.deltaTime*80f, 0, Space.World);
        //     }
        //     else {
        //         transform.localEulerAngles = new Vector3(newX, newY, transform.localEulerAngles.z);
        //         // transform.eulerAngles = Quaternion.Set(transform.eulerAngles.x, newY, transform.eulerAngles.z, transform.eulerAngles.w);
        //         print("angle : " + transform.eulerAngles.y);
        //         direction = "";
        //         orientation = 0;
        //     }       
        // }
        // else if (direction == "vertical"){            
        //     if (Mathf.Abs(newX-transform.localEulerAngles.x) > 2) {
        //         transform.Rotate(orientation*Time.deltaTime*80f, 0, 0, Space.World);
        //         // print("angle : " + transform.eulerAngles.x);
        //     }
        //     else {
        //         print("stop");
        //         transform.localEulerAngles = new Vector3(newX, newY, transform.localEulerAngles.z);
        //         direction = "";
        //         orientation = 0;
        //     }
        // }

        


    }

    private void getRotationKeyInfo () {



        
    }

    private void rotationX (int orientation, string direction, float newX) {
        if (Mathf.Abs(newX-transform.eulerAngles.x) > 2) {
                transform.Rotate(orientation*Time.deltaTime*80f, 0, 0, Space.World);
                // print("angle : " + transform.eulerAngles.x);
        }
        else {
            print("stop");
            transform.eulerAngles = new Vector3(newX, transform.eulerAngles.y, 0);
            direction = "";
            orientation = 0;
        }
    }

    private void rotationY (int orientation, string direction, float newY) {
        if (Mathf.Abs(newY-transform.eulerAngles.y) > 2) {
                transform.Rotate(0, orientation*Time.deltaTime*80f, 0, Space.World);
        }
        else {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, newY, 0);
            // print("angle : " + transform.eulerAngles.y);
            direction = "";
            orientation = 0;
        } 
    }

    private int getIndex(float oriPos, int[] posTable) {
        for (int i = 0; i < posTable.Length; i++) {
            if (Mathf.Abs(oriPos - posTable[i]) < 1) {
                return i;
            }
        }
        return 2;
    }
}
 