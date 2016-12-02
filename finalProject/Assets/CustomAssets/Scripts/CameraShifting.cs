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
	// Use this for initialization
	void Start () {
        mainCam = GameObject.Find("MainCamera");
        thisCam = transform.Find("ThisCamera").gameObject;
        openDice = GameObject.Find("OpenDice");
        dice = transform.Find("MyDice00");
        startManager = GameObject.Find("StartManager");
        rotation = GetComponent<Rotation>();
        turning = false;
        rotationSpeed = 0;
        startRot = dice.rotation;
        endRot = dice.rotation;

        thisCam.SetActive(false);
        mainCam.SetActive(true);

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
        }
        else {
            openDice.SetActive(true);
        }
	}

    void RaySelectedComputer() {

        if (Input.GetMouseButtonDown(0)) {
            if (!dice.GetComponent<Dice>().turning) {                
                RaycastHit hit;
                Ray ray = rayCam.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit)) {
                    rayCam = hit.transform.Find("ThisCamera").GetComponentInChildren<Camera>();
                    dice = hit.transform.Find("MyDice00");
                    if (hit.transform.gameObject == this.gameObject && !selected) {
                        startManager.GetComponent<StartManager>().selectedDice = this.gameObject;
                        selected = true;
                        thisCam.SetActive(true);
                        mainCam.SetActive(false);
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
                selected = false;
                thisCam.SetActive(false);
                mainCam.SetActive(true);
                rayCam = mainCam.GetComponentInChildren<Camera>();
            }
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
                    if (hit.transform.gameObject == this.gameObject && !selected) {
                        startManager.GetComponent<StartManager>().selectedDice = this.gameObject;
                        selected = true;
                        thisCam.SetActive(true);
                        mainCam.SetActive(false);
                    }
                    else {
                        selected = false;
                        thisCam.SetActive(false);                 
                    }
                }
                else {
                    selected = false;
                    mainCam.SetActive(true);
                    rayCam = mainCam.GetComponentInChildren<Camera>();
                    thisCam.SetActive(false);
                }
            }
        }
    }
}
