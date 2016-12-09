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
    public GameObject selectedDice;
    public List<GameObject> sideDisplay;
    // public GameObject side1;
    // public GameObject side2;

	// Use this for initialization
	void Start () {
        sideDisplay.Add(GameObject.Find("SideDisplay").transform.Find("forward").gameObject);
        sideDisplay.Add(GameObject.Find("SideDisplay").transform.Find("back").gameObject);
        sideDisplay.Add(GameObject.Find("SideDisplay").transform.Find("right").gameObject);
        sideDisplay.Add(GameObject.Find("SideDisplay").transform.Find("left").gameObject);
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

            if ((GetComponent<StartManager>().selectedDice != null && 
                !GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().turning) || 
                GetComponent<StartManager>().selectedCam == GameObject.Find("MainCamera")) {
                upSideText.text = "" + up;
                forwardSideText.text = "" + forward;
                backSideText.text = "" + back;
                rightSideText.text = "" + right;
                leftSideText.text = "" + left;
            }
            // else {                
            //     upSideText.text = "";
            //     forwardSideText.text = "";
            //     backSideText.text = "";
            //     rightSideText.text = "";
            //     leftSideText.text = "";
            // }

            if (GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side1 == null 
                && GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side2 == null) {
                DisplayChoosenSides(sideDisplay);
            }
       }
	}

    GameObject ChooseSideToDisplay(List<GameObject> sideDisplay) {
        int rd = Random.Range(0,sideDisplay.Count);        
        return sideDisplay[rd];
    }

    void DisplayChoosenSides(List<GameObject> sideDisplay/*, GameObject side1, GameObject side2*/) {
        print("Truly assigned");
        GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side1 = ChooseSideToDisplay(sideDisplay);
        sideDisplay.Remove(GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side1);
        GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side2 = ChooseSideToDisplay(sideDisplay);
        sideDisplay.Add(GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side1);
        
        GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side1.SetActive(true);
        GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side2.SetActive(true);            
    }

    public void HideSides(List<GameObject> sideDisplay) {
        for(int i = 0; i < sideDisplay.Count; i++) {
        
            GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side1.SetActive(false);
            GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side2.SetActive(false); 
            GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side1 = null;
            GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side2 = null;
        }
    }
}
