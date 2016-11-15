using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {
    
    public void SceneChange (string name) {
        SceneManager.LoadScene(name);
    }
}
