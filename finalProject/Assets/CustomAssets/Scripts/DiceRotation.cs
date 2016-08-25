using UnityEngine;
using System.Collections;

public class DiceRotation : MonoBehaviour {
        float oldY = 0;
        float oldX = 0;
        float newY = 0;
        float newX = 0;
        float direction = 0;
        string clickedArrow = "";
        bool isOutOfBound = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	   DiceRotate();
	}

    void DiceRotate() {

        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            clickedArrow = "Left";
            oldY = transform.eulerAngles.y;
            direction = -1;
            newY = oldY-90f;
            if (newY < -0.99f ) {
                newY += 360f;
                isOutOfBound = true;
            }
        }

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

        if ((transform.eulerAngles.y > newY && !isOutOfBound)||(transform.eulerAngles.y < newY && isOutOfBound)) {
            transform.Rotate(0, direction*Time.deltaTime*80f, 0, Space.World);
            if ((transform.eulerAngles.y <= newY&& !isOutOfBound)||(transform.eulerAngles.y >= newY && isOutOfBound)) {
                // transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
                oldY = 0;
                newY = 0;
                direction = 0;
                isOutOfBound = false;
            }
        }
    }
}
