using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablePhysics : MonoBehaviour {

	// Use this for initialization
	Rigidbody rigidbody;

	
	void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	public void EnableHit()
	{
		rigidbody.isKinematic = false;
	}

	
	
}
