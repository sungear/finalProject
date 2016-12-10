using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class changeScene : MonoBehaviour {

    public void GotoNewScene(string name) {
        SceneManager.LoadScene(name);
    }

    public void LeaveApplication() {
        Application.Quit();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
