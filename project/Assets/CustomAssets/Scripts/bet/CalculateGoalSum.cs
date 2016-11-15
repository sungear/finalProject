using UnityEngine;
using System.Collections;

public class CalculateGoalSum : MonoBehaviour {

    private int goalSum;
    private int minSum;
    private int maxSum;

    public int GetGoalSum(int diceNumber) {      
        minSum = diceNumber;
        maxSum = 6*diceNumber;
        goalSum = Random.Range(minSum, maxSum);
        return goalSum;
    }
}
