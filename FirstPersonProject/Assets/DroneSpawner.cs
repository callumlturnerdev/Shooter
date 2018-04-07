using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	bool currentlyInDrone = false;
	public GameObject droneRef;
	private GameObject currentDrone;
	FPSInput inputScript;
	mouseLook mouseLookScript;
	GameObject cameraObject;
	void Awake () {
			inputScript = gameObject.GetComponent<FPSInput>();
			mouseLookScript = gameObject.GetComponent<mouseLook>();
			cameraObject = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {


		
		if(Input.GetKeyDown(KeyCode.Alpha6))
		{
			if(!currentDrone)
			{
				currentDrone = Instantiate(droneRef, this.transform.position, this.transform.rotation) as GameObject;
				currentDrone.GetComponent<Rigidbody>().AddForce(transform.GetChild(0).transform.forward * 500);
			}

			PossesDrone();
		}
	}


	void PossesDrone()
	{
		currentlyInDrone = !currentlyInDrone;
	
		if(currentlyInDrone)
		{
			currentDrone.GetComponent<Drone>().SetControlsOn(true);
			currentDrone.transform.GetChild(0).GetComponent<Camera>().enabled = true;
			this.gameObject.transform.GetChild(0).GetComponent<Camera>().enabled = false;
			SetControlsOn(false);
		}
		else
		{
			currentDrone.GetComponent<Drone>().SetControlsOn(false);
			currentDrone.transform.GetChild(0).GetComponent<Camera>().enabled = false;
			 this.gameObject.transform.GetChild(0).GetComponent<Camera>().enabled = true;
			 SetControlsOn(true);
		}
	}



	public void SetControlsOn(bool t)
	{
		Debug.Log("things");
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
