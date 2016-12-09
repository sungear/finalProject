using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StartManager : MonoBehaviour {

    public GameObject dicePrefab;
    public List<GameObject> diceList;
    int[] possibleAngles = { 0, 90, 180, 270 };

    int diceNumber;
    public int goalSum;
    public float timer;

    public Text goalSumText;
    public Text timerText;
    public Text actualSumText;

    public int diceSide;
    public int diceValueSum;
    List<int> diceSides;

    public GameObject selectedDice;    
    public GameObject selectedCam;

	// Use this for initialization
	void Start () {
        diceNumber = PlayerPrefs.GetInt("DiceNumber");

        diceList = new List<GameObject>();
        for (int x = 0; x < diceNumber; x++) {
            // Quaternion randomRotation = Quaternion.Euler(Random.Range(0,4)*90, Random.Range(0,4)*90, 0);
            int randomX = Random.Range(0,4);
            int randomY = Random.Range(0,4);
            print("X Rotation : " + randomX);
            print("Y Rotation : " + randomY);
            // Quaternion randomRotation = Quaternion.Euler(possibleAngles[randomX], possibleAngles[randomY], 0);            
            GameObject newDice = (GameObject)Instantiate(dicePrefab, new Vector3(x, 0f, 0f), Quaternion.Euler(0,0,0));
            newDice.transform.GetChild(0).eulerAngles = new Vector3(possibleAngles[randomX], possibleAngles[randomY], 0);
            diceList.Add(newDice);
        }
        goalSum = PlayerPrefs.GetInt("GoalSum");
        goalSumText.text = "Goal : " + goalSum.ToString();

        timer = PlayerPrefs.GetFloat("Timer");
        timerText.text = "Time : " + timer.ToString();

        diceSides = new List<int>();
	}
	
	// Update is called once per frame
	void Update () {
        calculateDiceValue();
        if ((selectedDice != null && !selectedDice.transform.Find("MyDice00").GetComponent<Dice>().turning) || selectedCam == GameObject.Find("MainCamera")) { 
            actualSumText.text = "Actual : " + diceValueSum;
        }

        goalSumText.text = "Goal : " + goalSum.ToString();

        if (!GetComponent<FinishRound>().finishing) {
            timer -= Time.deltaTime;
            timerText.text = "Time : " + Mathf.Ceil(timer).ToString();
        }
        if (timer <= 0) {
            GetComponent<FinishRound>().timeOut = true;
            timer = 0;
        }

	}

    void calculateDiceValue() {
        if (diceValueSum > 0) {
            diceValueSum = 0;
        }
        if ((selectedDice != null && !selectedDice.transform.Find("MyDice00").GetComponent<Dice>().turning) || selectedCam == GameObject.Find("MainCamera")) {                      
            for (int i = 0; i < diceList.Count; i++) {
                diceSide = diceList[i].GetComponentInChildren<Dice>().upSide;
                diceValueSum += diceSide;
            }
        }
    }

    public void DisplayDices(List<GameObject> diceList, GameObject selectedDice, bool displayStatus) {
        // diceList.Remove(selectedDice);
        for(int i = 0; i < diceList.Count; i++) {
            if (diceList[i] != selectedDice) {
                diceList[i].SetActive(displayStatus); 
            }           
        }
        // diceList.Add(selectedDice);
    }

    public void ReturnToMainCamera() {
        if (!selectedDice.transform.Find("MyDice00").GetComponent<Dice>().turning) {
            DisplayDices(diceList, selectedDice, true);     
            selectedDice.GetComponent<CameraShifting>().selected = false;
            selectedDice.GetComponent<CameraShifting>().thisCam.SetActive(false);
            selectedDice.GetComponent<CameraShifting>().mainCam.SetActive(true);
            selectedDice = null;
            // rayCam = mainCam.GetComponentInChildren<Camera>();
        }
    }
}
