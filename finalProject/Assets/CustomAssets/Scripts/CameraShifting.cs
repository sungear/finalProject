using UnityEngine;
using System.Collections;

public class CameraShifting : MonoBehaviour {
    public GameObject mainCam;
    public GameObject thisCam;
    public GameObject sideDisplay;
    public bool selected;
    Rotation rotation;
    Transform dice;
    GameObject startManager;
    public Quaternion startRot;
    public Quaternion endRot;
    public bool turning;
    public float rotationSpeed;

    public Camera rayCam;
    public GameObject hideSides;

    GameObject confirmButton;
    GameObject returnButton;
	// Use this for initialization
	void Start () {
        mainCam = GameObject.Find("MainCamera");
        thisCam = transform.Find("ThisCamera").gameObject;
        sideDisplay = GameObject.Find("SideDisplay");
        dice = transform.Find("MyDice00");
        hideSides = transform.Find("HideDices").gameObject;
        confirmButton = GameObject.Find("ConfirmButtonParent");
        returnButton = GameObject.Find("ReturnButtonParent");
        startManager = GameObject.Find("StartManager");
        rotation = GetComponent<Rotation>();
        turning = false;
        rotationSpeed = 0;
        startRot = dice.rotation;
        endRot = dice.rotation;

        thisCam.SetActive(false);
        mainCam.SetActive(true);
        hideSides.SetActive(true);

        confirmButton.SetActive(true);
        returnButton.SetActive(true);

        rayCam =  mainCam.GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        RaySelectedComputer();      
        if (selected) {
            rotation.Rotate(dice);
        }
        if (mainCam.activeSelf) {
            if (rayCam != mainCam.GetComponentInChildren<Camera>()) {
                rayCam = mainCam.GetComponentInChildren<Camera>();
            }
            sideDisplay.SetActive(false);
            hideSides.SetActive(true);
            confirmButton.SetActive(true);
            returnButton.SetActive(false);
            startManager.GetComponent<StartManager>().selectedCam = mainCam;
        }
        else {
            sideDisplay.SetActive(true);
            hideSides.SetActive(false);
            returnButton.SetActive(true);
            confirmButton.SetActive(false);
            startManager.GetComponent<StartManager>().selectedCam = thisCam;
        }
	}

    void RaySelectedComputer() {
        if (!startManager.GetComponentInChildren<FinishRound>().finishing) {            
            if (Input.GetMouseButtonDown(0)) {
                if (!dice.GetComponent<Dice>().turning) {                
                    RaycastHit hit;
                    Ray ray = rayCam.ScreenPointToRay(Input.mousePosition);
                    if(Physics.Raycast(ray, out hit)) {
                        rayCam = hit.transform.Find("ThisCamera").GetComponentInChildren<Camera>();
                        dice = hit.transform.Find("MyDice00");
                        if (hit.transform.gameObject == this.gameObject) {
                            print("HIT : " + hit.transform.gameObject);
                            if (startManager.GetComponent<StartManager>().selectedDice != this.gameObject) {                            
                                startManager.GetComponent<StartManager>().selectedDice = this.gameObject;
                                startManager.GetComponent<StartManager>().DisplayDices(startManager.GetComponent<StartManager>().diceList,
                                    startManager.GetComponent<StartManager>().selectedDice, false);
                                selected = true;
                                thisCam.SetActive(true);
                                mainCam.SetActive(false);                            
                            }
                        }
                        else {
                            selected = false;
                            thisCam.SetActive(false);
                        }
                    }
                }
            }
            else if (Input.GetMouseButtonDown(1)) {
                if (!dice.GetComponent<Dice>().turning) {
                    ReturnToMain();
                }
            }
        }
        else {            
            startManager.GetComponent<StartManager>().selectedDice = null;      
            selected = false;
        }
    }

    public void ReturnToMain() {
        if (!dice.GetComponent<Dice>().turning) {
            startManager.GetComponent<StartManager>().DisplayDices(startManager.GetComponent<StartManager>().diceList,
                startManager.GetComponent<StartManager>().selectedDice, true);
            startManager.GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side1.SetActive(false);
            startManager.GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side2.SetActive(false); 
            startManager.GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side1 = null;
            startManager.GetComponent<StartManager>().selectedDice.transform.Find("MyDice00").GetComponent<Dice>().side2 = null;
            startManager.GetComponent<StartManager>().selectedDice = null;     
            selected = false;
            thisCam.SetActive(false);
            mainCam.SetActive(true);
            // rayCam = mainCam.GetComponentInChildren<Camera>();
        }
    }
 

    void RaySelectedPhone() {        
        if (Input.GetMouseButtonDown(0)) {
            if (!dice.GetComponent<Dice>().turning) {                
                RaycastHit hit;
                Ray ray = rayCam.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit)) {
                    rayCam = hit.transform.Find("ThisCamera").GetComponentInChildren<Camera>();
                    dice = hit.transform.Find("MyDice00");
                    if (hit.transform.gameObject == this.gameObject) {
                        if (startManager.GetComponent<StartManager>().selectedDice != this.gameObject) {                            
                            startManager.GetComponent<StartManager>().selectedDice = this.gameObject;
                            selected = true;
                            thisCam.SetActive(true);
                            mainCam.SetActive(false);                            
                        }
                    }
                    else {
                        selected = false;
                        thisCam.SetActive(false);                 
                    }
                }
                else {
                    startManager.GetComponent<StartManager>().selectedDice = null;
                    selected = false;
                    mainCam.SetActive(true);
                    rayCam = mainCam.GetComponentInChildren<Camera>();
                    thisCam.SetActive(false);
                }
            }
        }
    }
}
