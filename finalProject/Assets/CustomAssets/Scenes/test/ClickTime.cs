using UnityEngine;
using System.Collections;

public class ClickTime : MonoBehaviour {
    public float temps = 0;
    public Vector2 initPos;
    public bool init;
    public Vector2 finalPos;
    public bool final;
    public GameObject dice;

	// Use this for initialization
	void Start () {
	   init = false;
       final = false;
	}
	
	// Update is called once per frame
	void Update () {
            if ( Input.GetMouseButtonDown (0) )
        {
               temps = Time.time ;
        }
     
        if ( Input.GetMouseButtonUp(0) && (Time.time - temps) < 0.2 )
       {
            print("short");
       }
     
        if ( Input.GetMouseButtonUp(0) && (Time.time - temps) > 0.2 )
       {
            print("long");
       }
	
	}
    void OnGUI()
    {    if ( Input.GetMouseButtonDown (0) )
        {
               if (!init) {              

                    Event e = Event.current;
                    initPos = e.mousePosition;

                    dice.transform.position = new Vector3(initPos.x, initPos.y, dice.transform.position.z);
                    init = true;
               }
        }


        if (Input.GetMouseButtonUp(0)) {
 

            Event e = Event.current;
            if (e.isMouse) {
                Vector2 mouseXY = new Vector2 (e.mousePosition.x - Screen.width/2, e.mousePosition.y - Screen.height/2);
               if (!final) {             
                    finalPos = mouseXY;
                    final = true;
               }
            }
        }
    }
}
