using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableMesh : MonoBehaviour {
	[SerializeField]
	Camera camRef;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void BreakTri (int index) 
	{
		Destroy(this.gameObject.GetComponent<MeshCollider>());
		Mesh mesh = transform.GetComponent<MeshFilter>().mesh;
		int [] oldTriangles = mesh.triangles;
		int []  newTriangles = new int[mesh.triangles.Length-3];

		int i = 0;
		int j = 0;
		while(j < mesh.triangles.Length)
		{
			if(j != index*3)
			{
				newTriangles[i++] = oldTriangles[j++];
				newTriangles[i++] = oldTriangles[j++];
				newTriangles[i++] = oldTriangles[j++];
			}
			else
			{
				j += 3;
			}
		}
		transform.GetComponent<MeshFilter>().mesh.triangles = newTriangles;
		this.gameObject.AddComponent<MeshCollider>();
	}


	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Vector3 point = new Vector3(camRef.pixelWidth / 2, camRef.pixelHeight / 2, 0);
			Ray ray = camRef.ScreenPointToRay(point);
			if(Physics.Raycast(ray,out hit, 1000.0f))
			{
				Debug.Log("Hit triangle : " + hit.triangleIndex);
				
				BreakTri(hit.triangleIndex);
				
			}

		}
	}
}
