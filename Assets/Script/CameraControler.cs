using UnityEngine;
using System.Collections;

public class CameraControler : MonoBehaviour {
	public GameObject playerControler;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - playerControler.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = playerControler.transform.position + offset;
		Vector3 turn = new Vector3 (0f, Input.GetAxis ("Mouse X"), 0f);
		transform.Rotate (turn*30*Time.deltaTime);
		//rotateCamera ();
	}

	void rotateCamera()
	{
		if (transform.position.z > 0)
		{
			if(! (transform.eulerAngles.y >= 175 && transform.eulerAngles.y<=185))
			{
				transform.Rotate( new Vector3(0,180,0)*Time.deltaTime);
			}
			
		}
		if (transform.position.z <= 0) 
		{
			if( !(transform.eulerAngles.y >= 0 && transform.eulerAngles.y <= 5) ||(transform.eulerAngles.y >= 355 && transform.eulerAngles.y<=360))
			{
			
				transform.Rotate( new Vector3(0,-180,0)*Time.deltaTime);
			}
		}
	}
}
