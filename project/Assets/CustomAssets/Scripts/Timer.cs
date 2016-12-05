using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    private float time;

    private void UpdateTimer () {
        time -= Time.deltaTime;
    }
}
