using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BetMoney : MonoBehaviour {

    public Text pocketMoneyText;
    public Text betMoneyText;
    public int pocketMoney;
    public int betMoney = 50;
    public int minimalBet = 50;

    public GameObject upBetButton;
    public GameObject downBetButton;

	// Use this for initialization
	void Start () {
        pocketMoney = PlayerPrefs.GetInt("PocketMoney");
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

            // if (betMoney > minimalBet) {
            //     downBetButton.SetActive(true);
            // }

            // else if (betMoney < pocketMoney) {
            //     upBetButton.SetActive(true);
            // }
	
	}

    public void AddMoney () {
        if (pocketMoney - minimalBet >= betMoney) {
            if (betMoney == minimalBet) {
                downBetButton.SetActive(true);
            }
            betMoney += minimalBet;
        }
    }

    public void RemoveMoney () {
        if (betMoney >= minimalBet*2) {

            if (betMoney == pocketMoney) {
                upBetButton.SetActive(true);
            }            
            betMoney -= minimalBet;
            betMoneyText.text = "I'll bet " + betMoney + " €";
        }
    }
}
