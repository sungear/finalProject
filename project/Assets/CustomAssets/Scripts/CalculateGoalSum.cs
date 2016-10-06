using UnityEngine;
using System.Collections;

public class CalculateGoalSum : MonoBehaviour {

    private RoundManager roundManager;

    private int goalSum;
    private int minSum;
    private int maxSum;

	// Use this for initialization
	void Start () {
        roundManager = GetComponent<RoundManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetGoalSum(int diceNumber) {      
        minSum = diceNumber;
        maxSum = 6*diceNumber;
        goalSum = Random.Range(minSum, maxSum);
        return goalSum;
    }
}
