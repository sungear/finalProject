using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    Quaternion actualRot;
    Quaternion startRot;
    Quaternion endRot;
    float rotationSpeed;
    bool click;
    bool turning;

	// Use this for initialization
	void Start () {
        click = false;
        rotationSpeed = 0;
        turning = false;
        startRot = transform.rotation;
        endRot = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void Rotate(Transform dice) {

        if (!turning) {

            if (Input.GetKeyUp(KeyCode.LeftArrow)) {
                startRot = dice.rotation;
                dice.Rotate(0, 90, 0, Space.World);
                endRot = dice.rotation;
                rotationSpeed = 0;
                turning = true;
            }

            else if (Input.GetKeyUp(KeyCode.RightArrow)) {
                startRot = dice.rotation;
                dice.Rotate(0, -90, 0, Space.World);
                endRot = dice.rotation;
                rotationSpeed = 0;
                turning = true;
            }

            else if (Input.GetKeyUp(KeyCode.UpArrow)) {
                startRot = dice.rotation;
                dice.Rotate(90, 0, 0, Space.World);
                endRot = dice.rotation;
                rotationSpeed = 0;
                turning = true;
            }

            else if (Input.GetKeyUp(KeyCode.DownArrow)) {
                startRot = dice.rotation;
                dice.Rotate(-90, 0, 0, Space.World);
                endRot = dice.rotation;
                rotationSpeed = 0;
                turning = true;
            }  
        }

        rotationSpeed += Time.deltaTime*10.0f;      
                 
        dice.rotation = Quaternion.Slerp(startRot, endRot, rotationSpeed * 0.1f);
        if (Quaternion.Angle(endRot, dice.rotation) <= 1.0){
            turning = false;
        }
    }

}
