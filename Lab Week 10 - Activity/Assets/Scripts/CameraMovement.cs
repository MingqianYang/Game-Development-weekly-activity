using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private float speed = 2.0f;
	private float zoomSpeed = 2.0f;

	public float minX = -360.0f;
	public float maxX = 360.0f;
	
	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 1.0f;
	public float sensY = 1.0f;


	void Update () {

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);


		if (Input.GetKey(KeyCode.J)){
            // ...also rotate around the World's Y axis
            transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
        }
		if (Input.GetKey(KeyCode.L)){
            // ...also rotate around the World's Y axis
            transform.Rotate(Vector3.down * Time.deltaTime, Space.World);
        }



	}
}
