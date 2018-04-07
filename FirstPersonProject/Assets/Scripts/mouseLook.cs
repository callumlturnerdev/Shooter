using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour {
public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotatationX = 0;


    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;


	void Update () {

        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }

        else if (axes == RotationAxes.MouseY)
        {
            _rotatationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotatationX = Mathf.Clamp(_rotatationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotatationX, rotationY, 0);
            // vet rotation here
        }
        else
        {
            _rotatationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotatationX = Mathf.Clamp(_rotatationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityVert;
            float rotationY = transform.localEulerAngles.y + delta;


            transform.localEulerAngles = new Vector3(_rotatationX, rotationY, 0);

        }
	}
}
