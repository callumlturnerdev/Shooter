using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour {
	Drone inputScript;
	mouseLook mouseLookScript;
	GameObject cameraObject;
	// Use this for initialization
	void Awake () {
			inputScript = gameObject.GetComponent<Drone>();
			mouseLookScript = gameObject.GetComponent<mouseLook>();
			cameraObject = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	   float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (0.0f, 0.0f, moveVertical);
		if(Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Rigidbody>().AddForce(transform.GetChild(0).transform.forward * 500);
		}
        GetComponent<Rigidbody>().AddForce (transform.forward  * moveVertical * 20);
	}

	public void SetControlsOn(bool t)
	{
		if(t)
		{
			inputScript.enabled =true;
			mouseLookScript.enabled = true;
			cameraObject.SetActive(true);
		}
		else
		{
			inputScript.enabled =false;
			mouseLookScript.enabled = false;
			cameraObject.SetActive(false);
		}
	}
}
