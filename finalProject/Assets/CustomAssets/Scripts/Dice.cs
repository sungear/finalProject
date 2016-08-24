using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour {

    public int side = 0;
    public Vector3 originalSide;
    public Vector3 actualSide;

    private float rotationX;
    private float rotationY;

	// Use this for initialization
	void Awake () {
        side = getDiceFaceValue();

       rotationX = transform.localEulerAngles.x;
       rotationY = transform.localEulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
	   
       side = getDiceFaceValue();
       print (transform.localEulerAngles.x);
       print (transform.localEulerAngles.y);


       // if (side > 0) {
       //      print(side);
       // }

        DiceRotate();
	}

    int getDiceFaceValue() {
        float threshold = 0.99f;

        float forward = Vector3.Dot(transform.forward, Vector3.back);
        if (forward >= threshold) { return 2; }
        if (forward <= -threshold) { return 5; }

        float right = Vector3.Dot(transform.right, Vector3.back);
        if (right >= threshold) { return 4; }
        if (right <= -threshold) { return 3; }

        float up = Vector3.Dot(transform.up, Vector3.back);
        if (up >= threshold) { return 1; }
        if (up <= -threshold) { return 6; }

        return 0;
    }

    void DiceRotate() {
        // if (Input.GetKeyUp(KeyCode.LeftArrow)) {
        //     transform.Rotate(0, -90f, 0, Space.World);
        //     print("Left");
        //     // print("angle : " + transform.rotation.y);
        // }

        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            float newRotationY = rotationY-90f;
            transform.Rotate(0, transform.localEulerAngles.y-90f, 0, Space.World);
            // rotationY = newRotationY;
            print("Left");
            // print("angle : " + transform.rotation.y);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            transform.Rotate(0, 90f, 0, Space.World);
            print("Right");
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            transform.Rotate(-90f, 0, 0, Space.World);
            print("Up");
        }

        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            transform.Rotate(90f, 0, 0, Space.World);
            print("Down");
        }
    }
}
