using UnityEngine;
using System.Collections;

public class CameraShifting : MonoBehaviour {
    public GameObject mainCam;
    public GameObject thisCam;
    public bool selected;
    Rotation rotation;
    Transform dice;
    Quaternion startRot;
    Quaternion endRot;
    bool turning;
    float rotationSpeed;
	// Use this for initialization
	void Start () {
        mainCam = GameObject.Find("MainCamera");
        thisCam = transform.Find("ThisCamera").gameObject;
        rotation = GetComponent<Rotation>();
        dice = transform.Find("MyDice00");

        thisCam.SetActive(false);
        mainCam.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.T)) {
            thisCam.SetActive(true);
            mainCam.SetActive(false);
        }
        if(selected) {
            rotation.Rotate(dice);
            if(Input.GetKeyUp(KeyCode.Escape)) {
                selected = false;
                thisCam.SetActive(false);
                mainCam.SetActive(true);
            }
        }
	}

    void OnMouseUpAsButton() {
        print("selected");    
        thisCam.SetActive(true);
        mainCam.SetActive(false);
        selected = true;
    }
}
