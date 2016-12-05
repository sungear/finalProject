using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BetAndStartGame : MonoBehaviour {

    int diceNumber;
    int goalSum;
    int pocketMoney;
    int betMoney;
    float timer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Bet () {
        diceNumber = GetComponent<RoundManager>().diceNumber;
        PlayerPrefs.SetInt("DiceNumber", diceNumber);

        goalSum = GetComponent<RoundManager>().goalNumber;
        PlayerPrefs.SetInt("GoalSum", goalSum);

        pocketMoney = GetComponent<BetMoney>().pocketMoney;
        PlayerPrefs.SetInt("PocketMoney", pocketMoney);

        betMoney = GetComponent<BetMoney>().betMoney;
        PlayerPrefs.SetInt("BetMoney", betMoney);

        timer = GetComponent<RoundManager>().timer;
        PlayerPrefs.SetFloat("Timer", timer);

        SceneManager.LoadScene("Main");
    }
}
