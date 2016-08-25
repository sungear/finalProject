using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour {

    public int side = 0;

	// Use this for initialization
	void Awake () {
        side = getDiceFaceValue();
	}
	
	// Update is called once per frame
	void Update () {	   
       side = getDiceFaceValue();
	}

    int getDiceFaceValue() {
        float threshold = 0.99f;

        float forward = Vector3.Dot(transform.forward, Vector3.back);
        if (forward >= threshold) { return 2; }
        if (forward <= -threshold) { return 5; }

        float right = Vector3.Dot(transform.right, Vector3.back);
        if (right >= threshold) { return 6; }
        if (right <= -threshold) { return 1; }

        float up = Vector3.Dot(transform.up, Vector3.back);
        if (up >= threshold) { return 4; }
        if (up <= -threshold) { return 3; }

        return 0;
    }
}
