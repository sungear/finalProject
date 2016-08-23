using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartManager : MonoBehaviour {

    public GameObject dicePrefab;
    public int minDiceNumber = 1;
    public int maxDiceNumber = 3;

    public int diceNumber;

    public int goalSum;
    private int minSum;
    private int maxSum;

    public Text goalSumText;
    public Text timerText;

    public float timer = 50;

    public int diceValueSum;
	// Use this for initialization
	void Start () {
        diceNumber = Random.Range(minDiceNumber, maxDiceNumber);

        for (int x = 0; x < diceNumber; x++) {
            GameObject newDice = (GameObject)Instantiate(dicePrefab, new Vector3(x, 0f, 0f), Quaternion.identity);
        }

        minSum = diceNumber;
        maxSum = 6*diceNumber;
        goalSum = Random.Range(minSum, maxSum);

        goalSumText.text = "Goal : " + goalSum.ToString();
        timerText.text = "Time : " + timer.ToString(); 
	}
	
	// Update is called once per frame
	void Update () {
	   goalSumText.text = "Goal : " + goalSum.ToString();

        timer -= Time.deltaTime;
        timerText.text = "Time : " + Mathf.Ceil(timer).ToString();

        if (timer < 0) {
            print("game over");
        }

        
	}
}
