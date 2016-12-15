using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    Quaternion actualRot;
    Quaternion startRot;
    Quaternion endRot;
    float rotationSpeed;
    bool begin;
    bool turning;
    float rotationBonus;
    public float pressTimer = 0;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void Rotate(Transform dice) {
        if (GameObject.Find("StartManager").GetComponent<FinishRound>().diceTurn >= 0){   
            if (!dice.GetComponent<Dice>().turning) {

                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) ||
                    Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
                {
                    pressTimer += Time.deltaTime;
                }

                if (Input.GetKeyUp(KeyCode.RightArrow)) {
                    ChangeAtRotation(dice, 0, 0, 90);
                    rotationBonus = 0.1f;
                }

                else if (Input.GetKeyUp(KeyCode.LeftArrow)) {
                    ChangeAtRotation(dice, 0, 0, -90);
                    rotationBonus = 0.1f;
                }

                else if (Input.GetKeyUp(KeyCode.UpArrow)) {
                    ChangeAtRotation(dice, -90, 0, 0);
                    rotationBonus = 0.1f;
                }

                else if (Input.GetKeyUp(KeyCode.DownArrow)) {
                    ChangeAtRotation(dice, 90, 0, 0);
                    rotationBonus = 0.1f;
                }  
            }
            else
            {
                pressTimer = 0;
            }

            rotationSpeed += Time.deltaTime*10.0f;
            dice.rotation = Quaternion.Slerp(dice.GetComponent<Dice>().startRot, dice.GetComponent<Dice>().endRot, rotationSpeed * rotationBonus);
            rotationBonus += 0.01f;
            if (Quaternion.Angle(dice.GetComponent<Dice>().endRot, dice.rotation) <= 1.0){
                dice.GetComponent<Dice>().turning = false;
                if (GameObject.Find("StartManager").GetComponent<FinishRound>().diceTurn <= 0 &&
                    GameObject.Find("StartManager").GetComponent<StartManager>().diceValueSum != GameObject.Find("StartManager").GetComponent<StartManager>().goalSum) {
                    GameObject.Find("StartManager").GetComponent<FinishRound>().noTurn = true;
                }
            }
        }
    }

    /*float*/ void RotationAnimation(float t, float b, float c, float d)
    {
        //return c * Mathf.pow(2, 10 * (t / d - 1)) + b;
        //http://gizma.com/easing/#expo1
    }

    void ChangeAtRotation(Transform dice, int x, int y, int z) {
        GameObject.Find("StartManager").GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side1.SetActive(false);
        GameObject.Find("StartManager").GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side2.SetActive(false);
        GameObject.Find("StartManager").GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side1 = null;
        GameObject.Find("StartManager").GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side2 = null;

        dice.GetComponent<Dice>().startRot = dice.rotation;
        dice.Rotate(x, y, z /** pressTimer * 7*/, Space.World);
        dice.GetComponent<Dice>().endRot = dice.rotation;

        rotationSpeed = 0;
        GameObject.Find("StartManager").GetComponent<FinishRound>().diceTurn--;
        dice.GetComponent<Dice>().turning = true;
    }
}
