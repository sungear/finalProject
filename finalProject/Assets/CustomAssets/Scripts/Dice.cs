﻿using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour {

    public int side = 0;
    public int backSide = 0;
    public int upSide = 0;
    public int downSide = 0;
    public int leftSide = 0;
    public int rightSide = 0;

	// Use this for initialization
	void Awake () {
        side = getDiceFaceValue(Vector3.back);
        backSide = getDiceFaceValue(Vector3.forward);
        upSide = getDiceFaceValue(Vector3.up);
        downSide = getDiceFaceValue(Vector3.down);
        leftSide = getDiceFaceValue(Vector3.left);
        rightSide = getDiceFaceValue(Vector3.right);
	}
	
	// Update is called once per frame
	void Update () {	   
        side = getDiceFaceValue(Vector3.back);
        backSide = getDiceFaceValue(Vector3.forward);
        upSide = getDiceFaceValue(Vector3.up);
        downSide = getDiceFaceValue(Vector3.down);
        leftSide = getDiceFaceValue(Vector3.left);
        rightSide = getDiceFaceValue(Vector3.right);
       // print("side = " + side);
	}

    int getDiceFaceValue(Vector3 vector) {
        float threshold = 0.99f;

        float forward = Vector3.Dot(transform.forward, vector);
        if (forward >= threshold) { return 2; }
        if (forward <= -threshold) { return 5; }

        float right = Vector3.Dot(transform.right, vector);
        if (right >= threshold) { return 6; }
        if (right <= -threshold) { return 1; }

        float up = Vector3.Dot(transform.up, vector);
        if (up >= threshold) { return 4; }
        if (up <= -threshold) { return 3; }

        return 0;
    }
}
