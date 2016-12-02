using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    Quaternion actualRot;
    Quaternion startRot;
    Quaternion endRot;
    float rotationSpeed;
    bool begin;
    bool turning;

	// Use this for initialization
	void Start () {
        // initial = true;
        // rotationSpeed = 0;
        // turning = false;
        // startRot = transform.rotation;
        // endRot = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void Rotate(Transform dice) {
        // if (!begin) {
        //     startRot = dice.GetComponent<Dice>().startRot;
        //     endRot = dice.GetComponent<Dice>().startRot;
        //     begin = true;
        //     // turning = dice.GetComponent<Dice>().turning;
        // }

        if (!dice.GetComponent<Dice>().turning) {

            if (Input.GetKeyUp(KeyCode.LeftArrow)) {
                dice.GetComponent<Dice>().startRot = dice.rotation;
                dice.Rotate(0, 90, 0, Space.World);
                dice.GetComponent<Dice>().endRot = dice.rotation;
                rotationSpeed = 0;
                // turning = true;
                dice.GetComponent<Dice>().turning = true;
            }

            else if (Input.GetKeyUp(KeyCode.RightArrow)) {
                dice.GetComponent<Dice>().startRot = dice.rotation;
                dice.Rotate(0, -90, 0, Space.World);
                dice.GetComponent<Dice>().endRot = dice.rotation;
                rotationSpeed = 0;
                // turning = true;
                dice.GetComponent<Dice>().turning = true;
            }

            else if (Input.GetKeyUp(KeyCode.UpArrow)) {
                dice.GetComponent<Dice>().startRot = dice.rotation;
                dice.Rotate(90, 0, 0, Space.World);
                dice.GetComponent<Dice>().endRot = dice.rotation;
                rotationSpeed = 0;
                // turning = true;
                dice.GetComponent<Dice>().turning = true;
            }

            else if (Input.GetKeyUp(KeyCode.DownArrow)) {
                dice.GetComponent<Dice>().startRot = dice.rotation;
                dice.Rotate(-90, 0, 0, Space.World);
                dice.GetComponent<Dice>().endRot = dice.rotation;
                rotationSpeed = 0;
                // turning = true;
                dice.GetComponent<Dice>().turning = true;
            }  
        }

        rotationSpeed += Time.deltaTime*10.0f;      
                 
        dice.rotation = Quaternion.Slerp(dice.GetComponent<Dice>().startRot, dice.GetComponent<Dice>().endRot, rotationSpeed * 0.1f);
        if (Quaternion.Angle(dice.GetComponent<Dice>().endRot, dice.rotation) <= 1.0){
            // turning = false;
            dice.GetComponent<Dice>().turning = false;
        }
    }
}
