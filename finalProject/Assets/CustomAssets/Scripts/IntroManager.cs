using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroManager : MonoBehaviour {

    public float timer = 50;
    public int debtMoney = 1250;
    public int pocketMoney = 200;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetFloat("Timer", timer);
        PlayerPrefs.SetInt("DebtMoney", debtMoney);
        PlayerPrefs.SetInt("PocketMoney", pocketMoney);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
