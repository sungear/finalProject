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
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void Rotate(Transform dice) {
        if (GameObject.Find("StartManager").GetComponent<FinishRound>().diceTurn >= 0){   
            if (!dice.GetComponent<Dice>().turning) {

                if (Input.GetKeyUp(KeyCode.LeftArrow)) {
                    dice.GetComponent<Dice>().startRot = dice.rotation;
                    dice.Rotate(0, 0, 90, Space.World);
                    dice.GetComponent<Dice>().endRot = dice.rotation;
                    rotationSpeed = 0;
                    GameObject.Find("StartManager").GetComponent<FinishRound>().diceTurn--;
                    dice.GetComponent<Dice>().turning = true;
                }

                else if (Input.GetKeyUp(KeyCode.RightArrow)) {
                    dice.GetComponent<Dice>().startRot = dice.rotation;
                    dice.Rotate(0, 0, -90, Space.World);
                    dice.GetComponent<Dice>().endRot = dice.rotation;
                    rotationSpeed = 0;
                    GameObject.Find("StartManager").GetComponent<FinishRound>().diceTurn--;
                    dice.GetComponent<Dice>().turning = true;
                }

                else if (Input.GetKeyUp(KeyCode.UpArrow)) {
                    dice.GetComponent<Dice>().startRot = dice.rotation;
                    dice.Rotate(90, 0, 0, Space.World);
                    dice.GetComponent<Dice>().endRot = dice.rotation;
                    rotationSpeed = 0;
                    GameObject.Find("StartManager").GetComponent<FinishRound>().diceTurn--;
                    dice.GetComponent<Dice>().turning = true;
                }

                else if (Input.GetKeyUp(KeyCode.DownArrow)) {
                    dice.GetComponent<Dice>().startRot = dice.rotation;
                    dice.Rotate(-90, 0, 0, Space.World);
                    dice.GetComponent<Dice>().endRot = dice.rotation;
                    rotationSpeed = 0;
                    GameObject.Find("StartManager").GetComponent<FinishRound>().diceTurn--;
                    dice.GetComponent<Dice>().turning = true;
                }  
            }

            rotationSpeed += Time.deltaTime*10.0f;      
                     
            dice.rotation = Quaternion.Slerp(dice.GetComponent<Dice>().startRot, dice.GetComponent<Dice>().endRot, rotationSpeed * 0.1f);
            if (Quaternion.Angle(dice.GetComponent<Dice>().endRot, dice.rotation) <= 1.0){
                dice.GetComponent<Dice>().turning = false;
            }

        }
    }
}
