using UnityEngine;
using System.Collections;

public class CameraShifting : MonoBehaviour {
    public GameObject mainCam;
    public GameObject thisCam;
    public GameObject openDice;
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
	// Use this for initialization
	void Start () {
        mainCam = GameObject.Find("MainCamera");
        thisCam = transform.Find("ThisCamera").gameObject;
        openDice = GameObject.Find("OpenDice");
        dice = transform.Find("MyDice00");
        hideSides = transform.Find("HideDices").gameObject;
        startManager = GameObject.Find("StartManager");
        rotation = GetComponent<Rotation>();
        turning = false;
        rotationSpeed = 0;
        startRot = dice.rotation;
        endRot = dice.rotation;

        thisCam.SetActive(false);
        mainCam.SetActive(true);
        hideSides.SetActive(true);

        rayCam =  mainCam.GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        RaySelectedComputer();      
        if (selected) {
            rotation.Rotate(dice);
        }
        if (mainCam.activeSelf) {
            openDice.SetActive(false);
            hideSides.SetActive(true);
        }
        else {
            openDice.SetActive(true);
            hideSides.SetActive(false);
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
                }
            }
            else if (Input.GetMouseButtonDown(1)) {
                if (!dice.GetComponent<Dice>().turning) {
                    startManager.GetComponent<StartManager>().selectedDice = null;      
                    selected = false;
                    thisCam.SetActive(false);
                    mainCam.SetActive(true);
                    rayCam = mainCam.GetComponentInChildren<Camera>();
                }
            }
        }
        else {            
            startManager.GetComponent<StartManager>().selectedDice = null;      
            selected = false;
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
