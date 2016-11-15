using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    private float time;

    private void UpdateTimer () {
        timer -= Time.deltaTime;
    }
}
