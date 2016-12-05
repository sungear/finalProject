using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StartManager : MonoBehaviour {

    public GameObject dicePrefab;
    private List<GameObject> diceList;
    int[] possibleAngles = { 0, 90, 180, 270 };

    int diceNumber;
    public int goalSum;
    public float timer;

    public Text goalSumText;
    public Text timerText;

    public int diceSide;
    public int diceValueSum;

    public int pocketMoney;
    public int betMoney;

    public GameObject selectedDice;    
    public GameObject selectedCam;

	// Use this for initialization
	void Start () {
        pocketMoney = PlayerPrefs.GetInt("PocketMoney");
        betMoney = PlayerPrefs.GetInt("BetMoney");
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
	}
	
	// Update is called once per frame
	void Update () {
        calculateDiceValue();

        goalSumText.text = "Goal : " + goalSum.ToString();

        timer -= Time.deltaTime;
        timerText.text = "Time : " + Mathf.Ceil(timer).ToString();

        if (timer < 0) {
            // print("game over");
            timer = 0;
        }

	}

    void calculateDiceValue() {
        if (diceValueSum > 0) {
            diceValueSum = 0;
        }          
        for (int i = 0; i < diceList.Count; i++) {
            diceSide = diceList[i].GetComponentInChildren<Dice>().side;
            diceValueSum += diceSide;
        }
    }
}
