using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dice : MonoBehaviour {

    public int side;

	// Use this for initialization
	void Start () {
        side = getDiceFaceValue();

       if (side > 0) {
            print(side);
       }
	}
	
	// Update is called once per frame
	void Update () {
	   
       /*side = getDiceFaceValue();

       if (side > 0) {
            print(side);
       }*/
	}

    int getDiceFaceValue() {
        float threshold = 0.99f;

        float forward = Vector3.Dot(transform.forward, Vector3.back);
        if (forward >= threshold) { return 2; }
        if (forward <= -threshold) { return 5; }

        float right = Vector3.Dot(transform.right, Vector3.back);
        if (right >= threshold) { return 4; }
        if (right <= -threshold) { return 3; }

        float up = Vector3.Dot(transform.up, Vector3.back);
        if (up >= threshold) { return 1; }
        if (up <= -threshold) { return 6; }

        return 0;
    }
}
