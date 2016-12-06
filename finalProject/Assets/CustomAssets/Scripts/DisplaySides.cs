using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DisplaySides : MonoBehaviour {

    public int up;
    public int forward;
    public int back;
    public int right;
    public int left;

    public Text forwardSideText;
    public Text backSideText;
    public Text upSideText;
    public Text leftSideText;
    public Text rightSideText;

    Dice dice;
    GameObject selectedDice;
    public List<GameObject> sideDisplay;
    GameObject side1;
    GameObject side2;

	// Use this for initialization
	void Start () {
        // sideDisplay.Add(GameObject.Find("SideDisplay"));
        // sideDisplay.Add(GameObject.Find("SideDisplay").transform.Find("back").gameObject);
        // sideDisplay.Add(GameObject.Find("SideDisplay").transform.Find("right").gameObject);
        // sideDisplay.Add(GameObject.Find("SideDisplay").transform.Find("left").gameObject);
        for(int i = 0; i < sideDisplay.Count; i++) {
            sideDisplay[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	   if (GetComponent<StartManager>().selectedDice != null){
            dice = GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>();

            up = dice.upSide;
            forward = dice.forwardSide;
            back = dice.backSide;
            right = dice.rightSide;
            left = dice.leftSide;

            upSideText.text = "" + up;
            forwardSideText.text = "" + forward;
            backSideText.text = "" + back;
            rightSideText.text = "" + right;
            leftSideText.text = "" + left;
       }
	}

    void ChooseSideToDisplay(List<GameObject> sideDisplay) {
        int first = Random.Range(0,sideDisplay.Count);
        side1 = sideDisplay[first];
        sideDisplay.Remove(side1);
        int second = Random.Range(0,sideDisplay.Count);
        side2 = sideDisplay[second];
        sideDisplay.Remove(side2);
    }

    void DisplayChoosenSides(List<GameObject> sideDisplay) {
        for(int i = 0; i < sideDisplay.Count; i++) {
            sideDisplay[i].SetActive(true);
        }
    }
}
