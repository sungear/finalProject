using UnityEngine;
using System.Collections;

public class FinishRound : MonoBehaviour {

    public int pocketMoney;
    public int betMoney;

    int diceValueSum;
    int goalSum;

    float timer;

    public int diceTurn = 6;

    public GameObject popUpWindows;

    // public Animator popUpWindows;

    void Awake () {            
        pocketMoney = PlayerPrefs.GetInt("PocketMoney");
        betMoney = PlayerPrefs.GetInt("BetMoney");
        popUpWindows = GameObject.Find("PopUpWindows");
    }

	// Use this for initialization
	void Start () {
        popUpWindows.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {        
        if (diceTurn <= 0) {
            popUpWindows.SetActive(true);
            print("Can't turn anymore");            
            popUpWindows.GetComponentInChildren<Animator>().SetBool("NoTurn", true);
            // popUpWindows.GetComponentInChildren<Animator>().ResetTrigger("NoTurn");

        }

        timer = GetComponent<StartManager>().timer;
        if (timer <= 0) {
            popUpWindows.SetActive(true);
            print("TIME OUT");            
            popUpWindows.GetComponentInChildren<Animator>().Play("TimeOutPopUp");
        }
	}

    public void ConfirmGame() {
        diceValueSum = GetComponent<StartManager>().diceValueSum;
        goalSum = GetComponent<StartManager>().goalSum;
        popUpWindows.SetActive(true);
        if (diceValueSum != goalSum) {
            print("YOU LOST");
            popUpWindows.GetComponentInChildren<Animator>().Play("LostPopUp");
        }
        else {
            print("YOU WIN");
            popUpWindows.GetComponentInChildren<Animator>().Play("WinPopUp");
        }
    }
}
