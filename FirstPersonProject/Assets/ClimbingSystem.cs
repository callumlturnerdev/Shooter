using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingSystem : MonoBehaviour {

	private float defaultGravity = 9.8f;
//	CharacterController ccontrol;
	Rigidbody rigidbody;
	FPSInput fpsInput;
	LineRenderer liner;
	public GameObject hitObj;
	Vector3 Grounded;
	private float sphereRadius = 0.5f;
	private float maxDist = 0.4f;
	public LayerMask layerMask;
	public LayerMask noMask;

	private Vector3 origin;
	private Vector3 direction;
	public GameObject grapplePoint;
	private float hitdist;
	[SerializeField]
	private bool currentlyClimbing = false;
	// Use this for initialization
	void Start () {
	//	ccontrol = GetComponent<CharacterController>();
		rigidbody = GetComponent<Rigidbody>();
		fpsInput = GetComponent<FPSInput>();
		liner = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		RaycastForClimbWall();

		if(currentlyClimbing)
		{
			liner.SetPosition(0, this.transform.position);
			liner.SetPosition(1, grapplePoint.transform.position);
			WallCast(transform.forward);
			
		}
		else
		{
			liner.SetPosition(0,this.transform.position);
			liner.SetPosition(1,this.transform.position);
		}
	}



	void RaycastForClimbWall()
	{
		if(!currentlyClimbing)
		{
	
		origin = transform.position;
	//	origin =  new Vector3(transform.position.x,transform.position.y-1 , transform.position.z);
		//origin = transform.position;
		direction = transform.forward;
		RaycastHit hit;
		if(Physics.SphereCast(origin,sphereRadius, direction,out hit, maxDist,layerMask))
		{
			hitObj = hit.transform.gameObject;
			hitdist = hit.distance;
			Climb();
		}
		else
		{
			Grounded = new Vector3(transform.eulerAngles.x , transform.eulerAngles.y, transform.eulerAngles.z);
			if(currentlyClimbing)
			{
				hitdist = maxDist;
				hitObj = null;
			}
		}
		}
	}

	public bool isClimbing(){return currentlyClimbing;}
	void WallCast(Vector3 dir)
	{
	
		origin = transform.position;
		dir = -transform.up;
		RaycastHit hit;
		if(Physics.SphereCast(origin,sphereRadius, dir,out hit, maxDist+ 2,layerMask))
		{
					if(!hit.transform.gameObject)
					{
						
					}
					else
					{Debug.Log(hit.transform.gameObject.name);}
		}
		else
		{
				Debug.Log("ting");
				StopClimb();	
		}
	}

	void Climb()
	{
		
		Debug.Log(transform.rotation.y);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x - 90, transform.eulerAngles.y, transform.eulerAngles.z);
		
		Debug.Log(transform.rotation.y);
		fpsInput.SetGravity(0);
		currentlyClimbing = true;
	}

	void StopClimb()
	{
		transform.rotation = Quaternion.LookRotation(-Vector3.forward, Vector3.up);
		fpsInput.SetGravity(defaultGravity);
		currentlyClimbing = false;
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin+direction*maxDist, sphereRadius);
	
	}

	IEnumerator waitForSeconds(float time)
	{
		yield return new WaitForSeconds(time);
		currentlyClimbing = !currentlyClimbing;
	}
}
