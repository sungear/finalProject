using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextManager : MonoBehaviour {

    public Text goalSumText;
    public Text timerText;

    public float timer;

    // Use this for initialization
    void Start () {       
        goalSumText.text = "0";
        timerText.text = timer.ToString(); 
    }
    
    // Update is called once per frame
    void Update () {
       goalSumText.text = "0";

        timer -= Time.deltaTime;
        timerText.text = Mathf.Ceil(timer).ToString();

        if (timer < 0) {
            
        }
    }
}
