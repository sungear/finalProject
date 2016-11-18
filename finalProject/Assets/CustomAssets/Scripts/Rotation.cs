using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    Quaternion actualRot;
    Quaternion startRot;
    Quaternion endRot;
    float rotationSpeed;
    bool click;

	// Use this for initialization
	void Start () {
        click = false;
        rotationSpeed = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            startRot = transform.rotation;
            transform.Rotate(0, 90, 0, Space.World);
            endRot = transform.rotation;
            print("start : " + startRot);
            print("end :" + endRot);
        rotationSpeed = 0;
            // print("startRot : " + startRot);
        }

        else if (Input.GetKeyUp(KeyCode.RightArrow)) {
            startRot = transform.rotation;
            transform.Rotate(0, -90, 0, Space.World);
            endRot = transform.rotation;
        rotationSpeed = 0;
            // print("startRot : " + startRot);
        }

        else if (Input.GetKeyUp(KeyCode.UpArrow)) {
            startRot = transform.rotation;
            transform.Rotate(90, 0, 0, Space.World);
            endRot = transform.rotation;
        rotationSpeed = 0;
            // print("startRot : " + startRot);
        }

        else if (Input.GetKeyUp(KeyCode.DownArrow)) {
            startRot = transform.rotation;
            transform.Rotate(-90, 0, 0, Space.World);
            endRot = transform.rotation;
        rotationSpeed = 0;
            // print("startRot : " + startRot);
        }  

        rotationSpeed += Time.deltaTime*5.0f;      
                 
        transform.rotation = Quaternion.Slerp(startRot, endRot, rotationSpeed * 0.1f);
	}

}
