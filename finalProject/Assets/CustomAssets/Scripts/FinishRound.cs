using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishRound : MonoBehaviour {

    public int pocketMoney;
    public int betMoney;
    public int debtMoney;

    int diceValueSum;
    int goalSum;

    float timer;

    public int diceTurn = 7;

    public GameObject popUpWindows;

    public bool finishing = false;
    public bool timeOut = false;
    public int state = 0;
    public bool confirmed;
    public bool noTurn;
    public float countDown;

    public Text winPopUpText;
    public Text lostPopUpText;
    public Text turnText;

    int turn;

    // public Animator popUpWindows;

    void Awake () {            
        pocketMoney = PlayerPrefs.GetInt("PocketMoney");
        betMoney = PlayerPrefs.GetInt("BetMoney");
        debtMoney = PlayerPrefs.GetInt("DebtMoney");
        popUpWindows = GameObject.Find("PopUpWindows");
    }

	// Use this for initialization
	void Start () {
        diceTurn = 7;
        popUpWindows.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {        
        if (diceTurn > 0) {
            turnText.text = "Turn : " + (diceTurn-1);
        }
        HandleState();       
	}

    void HandleState() {
        if (countDown > 0) {            
            countDown -= Time.deltaTime;
            if (countDown <= 0) {
                state++;
            }
        }    
        switch (state) {
            case 0 :
                if (timeOut) {
                    state++;
                }
                else if (diceTurn <= 0) {
                    noTurn = true;
                    state++;
                }
                else if (confirmed) {
                    state++;
                }
                break;
            case 1 :
                popUpWindows.SetActive(true);
                finishing = true;
                winPopUpText.text = "You won " + betMoney + " €";
                lostPopUpText.text = "You lost " + betMoney + " €"; 
                timer = GetComponent<StartManager>().timer;               
                PlayerPrefs.SetFloat("Timer", timer);
                if (timeOut) {
                    popUpWindows.GetComponentInChildren<Animator>().Play("TimeOutPopUp");
                }
                else if (noTurn) {
                    popUpWindows.GetComponentInChildren<Animator>().Play("NoTurnPopUp");
                }
                else if (confirmed) {                    
                    Invoke("HandleAnimation", 0);
                    state++;
                    break;
                }
                if (Input.GetMouseButtonDown(0)) {
                    Invoke("HandleAnimation", 0);
                    state++;
                }
                break;
            case 2 :
                if (Input.GetMouseButtonDown(0)) {
                    popUpWindows.GetComponentInChildren<Animator>().SetTrigger("Finish");
                    countDown = 1f;
                }
                break;
            case 3 :
                if (pocketMoney <= 0) {                       
                    SceneManager.LoadScene("GameOver");
                }
                else if (pocketMoney >= debtMoney) {
                    SceneManager.LoadScene("Victory");
                }            
                else if (timeOut) {
                    if (pocketMoney >= debtMoney) {
                        SceneManager.LoadScene("Victory");
                    }                                
                    SceneManager.LoadScene("GameOver");
                }
                else {                        
                    SceneManager.LoadScene("Bet");
                }
                break;
        }
    }

    public void ConfirmGame() {
        confirmed = true;      
    }

    void HandleAnimation() {        
        diceValueSum = GetComponent<StartManager>().diceValueSum;
        goalSum = GetComponent<StartManager>().goalSum;
        if (diceValueSum != goalSum) {
            pocketMoney -= betMoney;
            popUpWindows.GetComponentInChildren<Animator>().Play("LostPopUp");
        }
        else {
            pocketMoney += betMoney;
            popUpWindows.GetComponentInChildren<Animator>().Play("WinPopUp");
        }
        PlayerPrefs.SetInt("PocketMoney", pocketMoney);
    }
}
