using UnityEngine;
using System.Collections;

public class ClickTime : MonoBehaviour {
    public float temps = 0;
    public Vector3 initP;
    public bool init;
    public Vector3 finalP;
    public bool final;
    public GameObject dice;
    public float directionX;
    public float directionY;
    public string direction;


    public Rigidbody rb;

	// Use this for initialization
	void Start () {
	   init = false;
       final = false;
        rb = dice.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
            if ( Input.GetMouseButtonDown (0) )
        {
               temps = Time.time ;
               initP = Input.mousePosition;
               // dice.transform.position = new Vector3(initP.x, initP.y, dice.transform.position.z);               
        }
     
        if ( Input.GetMouseButtonUp(0) && (Time.time - temps) < 0.2 )
       {
            print("short");
       }
     
        if ( Input.GetMouseButtonUp(0) && (Time.time - temps) > 0.2 )
       {
            print("long");
       }
       if (Input.GetMouseButtonUp(0)) {
            finalP = Input.mousePosition;
            directionX = finalP.x - initP.x;
            directionY = finalP.y - initP.y;  

       if (directionX != 0 && directionY != 0) {
            if (Mathf.Abs(directionX) > Mathf.Abs(directionY)) {
                if (directionX > 0) {
                    print("right");
                    rb.velocity = new Vector3(temps, 0, 0);
                }
                else {
                    print("left");
                    rb.velocity = new Vector3(-temps, 0, 0);
                }
            }
            else {
                if (directionY > 0) {
                    print("up");
                    rb.velocity = new Vector3(0, 0, temps);
                }
                else {
                    print("down");
                    rb.velocity = new Vector3(0, 0, -temps);
                }
            }
       } 

       temps = 0;
       }
	
	}
}
