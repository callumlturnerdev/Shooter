using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {


	public float xRotDifferences;
	public GameObject destrcutionPiece;
	// Use this for initialization

	public void  OnHit()
	{

		Quaternion newtrans = Quaternion.Euler(transform.rotation.x + xRotDifferences, transform.rotation.y, transform.rotation.z);
		Instantiate(destrcutionPiece, transform.position, newtrans);
		Destroy(gameObject);
	} 
	
}
