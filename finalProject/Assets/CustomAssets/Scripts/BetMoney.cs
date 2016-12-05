using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BetMoney : MonoBehaviour {

    public Text pocketMoneyText;
    public Text betMoneyText;
    public int pocketMoney = 200;
    public int betMoney = 50;
    public int minimalBet = 50;

    public GameObject upBetButton;
    public GameObject downBetButton;

	// Use this for initialization
	void Start () {
        pocketMoneyText.text = "You have " + pocketMoney + " €";
	}
	
	// Update is called once per frame
	void Update () {
        betMoneyText.text = "I'll bet " + betMoney + " €";
        if (betMoney == minimalBet) {
            downBetButton.SetActive(false);
        }
        else if (betMoney == pocketMoney) {
            upBetButton.SetActive(false);
        }
	
	}

    public void AddMoney () {
        if (pocketMoney - minimalBet >= betMoney) {
            if (betMoney == minimalBet * 2) {
                downBetButton.SetActive(true);
            }
            betMoney += minimalBet;
        }
    }

    public void RemoveMoney () {
        if (betMoney >= minimalBet*2) {

            if (betMoney == pocketMoney - minimalBet) {
                upBetButton.SetActive(true);
            }            
            betMoney -= minimalBet;
            betMoneyText.text = "I'll bet " + betMoney + " €";
        }
    }
}
