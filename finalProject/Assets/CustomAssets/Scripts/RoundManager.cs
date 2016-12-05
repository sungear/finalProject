using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundManager : MonoBehaviour {

    public int minDiceNumber = 1;
    public int maxDiceNumber = 3;

    public int diceNumber;
    // private CalculateGoalSum calculateGoalSum;
    public int goalNumber;

    public Text diceNumberText;
    public Text goalSumText;
    public Text timerText;

    public float timer;

    // Use this for initialization
    void Start () {
        timer = 50f;

        // calculateGoalSum = GetComponent<CalculateGoalSum>();
        diceNumber = Random.Range(minDiceNumber, maxDiceNumber+1);
        goalNumber = GetGoalSum(diceNumber);
        // goalSum = calculateGoalSum.GetGoalSum(diceNumber);

        if (diceNumber > 1) {
            diceNumberText.text = "You're playing with " + diceNumber.ToString() + " dice";
        }
        else {
            diceNumberText.text = "You're playing with " + diceNumber.ToString() + " die";
        }
        goalSumText.text = "Your goal number is " + goalNumber.ToString();
    }
    
    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        timerText.text = "Time : " + Mathf.Ceil(timer).ToString();

        if (timer < 0) {
            // print("game over");
        }
    }

    public int GetGoalSum(int diceNumber) {      
        int minSum = diceNumber;
        int maxSum = 6*diceNumber;
        int goalSum = Random.Range(minSum, maxSum);
        return goalSum;
    }
}