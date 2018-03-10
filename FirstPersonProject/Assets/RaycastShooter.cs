﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooter : MonoBehaviour {

 private Camera cam;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}


    void OnGUI()
    {
        int size = 128;
        float posX = cam.pixelWidth / 2 - size / 10;
        float posY = cam.pixelHeight / 2 - size / 10;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitOBJ = hit.transform.gameObject;
                ReactiveTarget target = hitOBJ.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                    Debug.Log("Hit Reactive Target");
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                    Debug.Log("Hit " + hit.point);
                }
            }
        }
	}


    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
