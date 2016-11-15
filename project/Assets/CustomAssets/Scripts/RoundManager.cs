using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundManager : MonoBehaviour {

    public int minDiceNumber = 1;
    public int maxDiceNumber = 3;

    public int diceNumber;
    private CalculateGoalSum calculateGoalSum;
    public int goalSum;

    public Text diceNumberText;
    public Text goalSumText;

	// Use this for initialization
	void Start () {
        calculateGoalSum = GetComponent<CalculateGoalSum>();
        diceNumber = Random.Range(minDiceNumber, maxDiceNumber+1);
        goalSum = calculateGoalSum.GetGoalSum(diceNumber);

        diceNumberText.text = "There's " + diceNumber.ToString() + " dices";
        goalSumText.text = "Your goal number is : " + goalSum.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
